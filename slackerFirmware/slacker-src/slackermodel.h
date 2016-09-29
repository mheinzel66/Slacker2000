#ifndef SLACKERMODEL_H
#define SLACKERMODEL_H

#include "listmodel.h"
#include "linetext.h"

class SlackerModel : public ListModel
{
    Q_OBJECT

public:
   explicit SlackerModel(QObject* parent = 0);

public:
    bool loadData();

   Q_INVOKABLE int getNextSectionLineNum(const int currentLineNum);
   Q_INVOKABLE int getPrevSectionLineNum(const int currentLineNum);
   Q_INVOKABLE int getEndofFileLineNum();

public slots:
    void onLoadData();
    void onUsbFound(int state);

signals:
    void fileStateChanged(int state);
       void usbDriveFound(int state);

private:
    bool parseXML(QString szPath);
    QList<int> m_SectionStartLineNums;
    int m_EndOfFileIndex ;

};

#endif // SLACKERMODEL_H
