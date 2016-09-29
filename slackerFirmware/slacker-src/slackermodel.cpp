#include "listmodel.h"
#include "slackermodel.h"
#include <QDebug>
#include "QFile"
#include "QDir"
#include <QDomDocument>
#include <sys/mount.h>
 #include <sched.h>
#include "mountThread.h"


/////////////////////////////////////////
//Method:
/////////////////////////////////////////
SlackerModel::SlackerModel(QObject* parent):ListModel(new LineText,parent )
{
    m_EndOfFileIndex = 0;
}

/////////////////////////////////////////
//Method:
/////////////////////////////////////////
void SlackerModel::onLoadData()
{
    qDebug() << "SlackerModel::onLoadData";
    loadData();
}

/////////////////////////////////////////
//Method:
/////////////////////////////////////////
void SlackerModel::onUsbFound(int state)
{
    if(state==0)
    {
        qDebug() << "SlackerModel::onUsbFound";
        this->clear();
        m_SectionStartLineNums.clear() ;
        emit fileStateChanged(1);
        qDebug() << "SlackerModel::clear";
    }
    else
    {
        loadData();
    }
}

/////////////////////////////////////////
//Method:
/////////////////////////////////////////
bool SlackerModel::loadData()
{
    bool fileFound = false;
    m_EndOfFileIndex = 0;

    emit fileStateChanged(1);//loading

    qDebug() << "SlackerModel::loadData\n";

    qDebug() << "Searching for file...\n";

    QDir usbRootDir("/media/slacker/");

    QString dataFilePath;  
    QStringList filters;
    filters << "*.slk";
    usbRootDir.setNameFilters(filters);

    QFileInfoList usbDriveFileList = usbRootDir.entryInfoList();

    if(usbDriveFileList.length() !=0)
    {
        QFileInfo usbFileInfo = usbDriveFileList.at(0);
        QString usbFilePath = usbFileInfo.absoluteFilePath();
        QFile dataFile( usbFilePath );

         if(dataFile.exists())
         {
             fileFound = true;
             dataFilePath = dataFile.fileName();
             dataFile.close();
         }
    }


    try
    {

        if(fileFound)
        {
            qDebug() << "file found " << dataFilePath;
            if(parseXML(dataFilePath)==true)
            {
                emit fileStateChanged(2);//loaded
            }
            else
            {
                this->clear();
                qDebug() << "error loading file";;
                emit fileStateChanged(3);
            }
        }
        else
        {
            this->clear();
            qDebug() << "no file found ";
            emit fileStateChanged(0);
        }
    }
    catch(...)
    {
        this->clear();
        qDebug() << "error loading file";
        emit fileStateChanged(3);
    }


    return fileFound;
}


/////////////////////////////////////////
//Method:
/////////////////////////////////////////
bool SlackerModel::parseXML(QString szPath)
{  
    bool statusOk = true;

    try
    {
        this->clear();

        /* We'll parse the example.xml */
        QFile* file = new QFile(szPath);

        /* If we can't open it, let's show an error message. */
        if (!file->open(QIODevice::ReadOnly | QIODevice::Text))
        {
             qDebug() << "Error opening file: " << szPath;
             return false;
        }

        /* QDomDocument takes any QIODevice. as well as QString buffer*/
        QDomDocument doc("mydocument");
        if (!doc.setContent(file))
        {
            qDebug() << "setContent failed";
            return false;
        }

        //Get the root element
        QDomElement docElem = doc.documentElement();

        // you could check the root tag name here if it matters
        //QString rootTag = docElem.tagName();

        // get the node's interested in
        QDomNodeList nodeList = docElem.elementsByTagName("song");

        int lineNum = 0;

        //Check each node one by one.
        for(int ii = 0;ii < nodeList.count(); ii++)
        {
            // get the current one as QDomElement
            QDomElement el = nodeList.at(ii).toElement();

            QString title = el.attribute("title"); // get and set the attribute ID
            m_SectionStartLineNums.append(lineNum);

            QString szTitleText = "<P STYLE='font-family:Arial;font-size:52px;'>" + title + "</P>";
            this->appendRow(new LineText(QString::number(lineNum),szTitleText , this,"yellow","AlignHCenter"));

            lineNum++;

            //get all data for the element, by looping through all child elements
            QDomNode pEntries = el.firstChild();

            while(!pEntries.isNull())
            {
                QDomElement peData = pEntries.toElement();

                QString lyric = peData.text();
               // qDebug() << "Line: " << lyric;

                QString lineTextAlignment = "AlignLeft";

                if(lyric.indexOf("text-align:Center")>=0)
                {
                    lineTextAlignment = "AlignHCenter" ;
                }
                else if(lyric.indexOf("text-align:Right")>=0)
                {
                    lineTextAlignment ="AlignLeft";
                }

                this->appendRow(new LineText(QString::number(lineNum),lyric,this,"white",lineTextAlignment));
                pEntries = pEntries.nextSibling();
                lineNum++;
            }


            QString szBlankRowText = "<P STYLE='font-family:Arial;font-size:52px;'> </P>";

            //add end of song text
            this->appendRow(new LineText(QString::number(lineNum),szBlankRowText,this,"yellow","AlignHCenter" ));
            lineNum++;

            QString szEndText = "<P STYLE='font-family:Arial;font-size:52px;'>--------------------------------------------------------</P>";
            this->appendRow(new LineText("",szEndText,this,"yellow","AlignHCenter" ));
            lineNum++;

            for(int j = 0;j < 5; j++)
            {
                this->appendRow(new LineText("",szBlankRowText,this,"white","AlignHCenter" ));
                lineNum++;
            }
         }

        if(file)
        {
            file->close();
        }

        m_EndOfFileIndex = lineNum++;

        //add items so the screen will scroll at the end
        for(int j = 0;j < 10; j++)
        {
           // this->appendRow(new LineText(QString::number(j),"",this,"red","AlignHCenter" ));
            this->appendRow(new LineText("","",this,"red","AlignHCenter" ));
        }

        //add end title
        QString szEndText = "<P STYLE='font-family:Arial;font-size:82px;'>END OF FILE</P>";
        this->appendRow(new LineText("",szEndText,this,"red","AlignHCenter" ));

        //add image
        this->appendRow( new LineText("","",this,"red","AlignHCenter","image" ) );


        //add items so the screen will scroll at the end
        for(int j = 0;j < 40; j++)
        {
            this->appendRow(new LineText("","",this,"red","AlignHCenter" ));
        }
    }
    catch(...)
    {
        statusOk = false;
    }

    return statusOk;

}

/////////////////////////////////////////
//Method:
/////////////////////////////////////////
int SlackerModel::getEndofFileLineNum()
{
    return m_EndOfFileIndex ;
}

/////////////////////////////////////////
//Method:
/////////////////////////////////////////
int SlackerModel::getNextSectionLineNum(int currentLineNum)
{
    int sectionLineNum = -1;

    for(int i=0;i<m_SectionStartLineNums.size(); i++)
    {
        if( m_SectionStartLineNums.at(i) > currentLineNum)
        {
            sectionLineNum = m_SectionStartLineNums.at(i);
            break;
        }
    }

    return sectionLineNum;
}

/////////////////////////////////////////
//Method:
/////////////////////////////////////////
int SlackerModel::getPrevSectionLineNum(int currentLineNum)
{
    int sectionLineNum = 0;

    for(int i=0;i<m_SectionStartLineNums.size(); i++)
    {
       // qDebug() << "m_SectionStartLineNums:@ " << i << "val:" << m_SectionStartLineNums.at(i);

        if( m_SectionStartLineNums.at(i) >= currentLineNum)
        {
            if( (i-1) >= 0 )
            {
               sectionLineNum = m_SectionStartLineNums.at(i-1) ;
               break;
            }
        }
    }

    return sectionLineNum;

}
