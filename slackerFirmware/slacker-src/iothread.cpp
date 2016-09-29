#include "iothread.h"
#include "gpio.h"
#include <QDebug>
#include <QString>
#include <QTime>


#define SWITCH_ONE GPIO_2
#define SWITCH_TWO GPIO_3
#define NEXT_SONG_PRESS_TIME 1100
#define POLLING_INTERVAL 120



IoThread::IoThread(QObject *parent) : QThread(parent)
{
    m_Gpio.init_gpio();
    m_isRunning = false;
    m_isAutoScrollMode = false;
}

void IoThread::onUsbDriveFound()
{
   m_isAutoScrollMode = false;
}


void IoThread::run()
{   

    m_isRunning=true;
    m_isAutoScrollMode = false;
    bool fStateChanged = false;

    short currentSwitchOneState = SWITCH_UP;
    short currentSwitchTwoState = SWITCH_UP;
    short newState = UNK_STATE;

    QTime* pSwitchOneStateTimer = 0;
    QTime* pSwitchTwoStateTimer = 0;
    int nSwitchOnePressMilliseconds = 0;
    int nSwitchTwoPressMilliseconds = 0;

    while(m_isRunning==true)
    {
        newState = UNK_STATE;
        msleep(POLLING_INTERVAL);

     //-----------------
    //Switch one
    //-----------------
        int newSwitchOneState = m_Gpio.read_gpio(SWITCH_ONE);

        if(newSwitchOneState != currentSwitchOneState)
        {
             fStateChanged = true;
             currentSwitchOneState = newSwitchOneState;

             if(newSwitchOneState==SWITCH_DOWN)
             {
                 qDebug() << "SWITCH_DOWN1";
                 if(pSwitchOneStateTimer==0)
                 {
                     pSwitchOneStateTimer = new QTime();                     
                 }

                 nSwitchOnePressMilliseconds = 0;
                 pSwitchOneStateTimer->start();
             }
             else//SWITCH_UP
             {                 

                 qDebug() << "SWITCH_UP1";

                 //stop "pressed" timer
                 if(pSwitchOneStateTimer != 0)
                 {
                     nSwitchOnePressMilliseconds = pSwitchOneStateTimer->elapsed();
                     delete pSwitchOneStateTimer;
                     pSwitchOneStateTimer = 0;
                 }

                 if(nSwitchOnePressMilliseconds<NEXT_SONG_PRESS_TIME)
                 {
                     if(m_isAutoScrollMode==false)
                     {
                          newState = PAGE_DOWN;
                          qDebug() << "PAGE_DOWN";
                     }
                     else
                     {
                          newState = DEC_SPEED;
                          qDebug() << "DEC_SPEED";
                     }
                  }

             }//end   elseSWITCH_UP

        }//end  if(newSwitchOneState != currentSwitchOneState)
    //-----------------
    //End Switch one
    //----------------


    //---------
    //switch 2
    //---------
        int newSwitchTwoState = m_Gpio.read_gpio(SWITCH_TWO);

        if(newSwitchTwoState != currentSwitchTwoState)
        {
           // qDebug() << "newSwitchTwoState:" << newSwitchTwoState;

            fStateChanged = true;
            currentSwitchTwoState = newSwitchTwoState;

            if(newSwitchTwoState==SWITCH_DOWN)
            {
                qDebug() << "SWITCH_DOWN2";
                if(pSwitchTwoStateTimer==0)
                {
                    pSwitchTwoStateTimer = new QTime();
                }

                nSwitchTwoPressMilliseconds = 0;
                pSwitchTwoStateTimer->start();
            }
            else//SWITCH_UP
            {
                qDebug() << "SWITCH_UP2";
                if(pSwitchTwoStateTimer != 0)
                {
                     nSwitchTwoPressMilliseconds = pSwitchTwoStateTimer->elapsed();
                     delete pSwitchTwoStateTimer;
                     pSwitchTwoStateTimer = 0;
                }

                if(nSwitchTwoPressMilliseconds<NEXT_SONG_PRESS_TIME)
                {
                    if(m_isAutoScrollMode==false)
                     {
                          newState = PAGE_UP;
                          qDebug() << "PAGE_UP";
                     }
                     else
                     {
                         newState = INC_SPEED;
                         qDebug() << "INC_SPEED";
                     }


                }//end  if(nSwitchTwoPressMilliseconds<NEXT_SONG_PRESS_TIME)

            }//end   if(newSwitchTwoState==SWITCH_DOWN)

        }//  if(newSwitchTwoState != currentSwitchTwoState)



    //------------------------
    //next/previous section
    //------------------------
        if(pSwitchOneStateTimer != 0)
        {
            nSwitchOnePressMilliseconds = pSwitchOneStateTimer->elapsed();            

            if(nSwitchOnePressMilliseconds>=NEXT_SONG_PRESS_TIME && newSwitchTwoState != SWITCH_DOWN)
            {
                delete pSwitchOneStateTimer;
                pSwitchOneStateTimer = 0;

                //don't allow sections changes durring autoscroll
                if( m_isAutoScrollMode != true)
                {
                    newState = NEXT_SECTION;
                    qDebug() << "NEXT_SECTION";
                }
            }
        }

        if(pSwitchTwoStateTimer != 0)
        {
            nSwitchTwoPressMilliseconds = pSwitchTwoStateTimer->elapsed();

            if(nSwitchTwoPressMilliseconds>=NEXT_SONG_PRESS_TIME && newSwitchOneState != SWITCH_DOWN)
            {
                  delete pSwitchTwoStateTimer;                  
                  pSwitchTwoStateTimer = 0;

                  //don't allow sections changes durring autoscroll
                  if( m_isAutoScrollMode != true)
                  {
                    qDebug() << "PREV_SECTION";
                    newState = PREV_SECTION;
                  }
            }
            else if(nSwitchTwoPressMilliseconds>=NEXT_SONG_PRESS_TIME && newSwitchOneState == SWITCH_DOWN)
            {

                if( m_isAutoScrollMode == true)
                {
                    m_isAutoScrollMode = false;
                    newState = STOP_AUTOSCROLL;
                    qDebug() << "m_isAutoScrollMode false";
                }
                else
                {
                    m_isAutoScrollMode = true;
                    newState = START_AUTOSCROLL;
                    qDebug() << "m_isAutoScrollMode true";
                }

                delete pSwitchTwoStateTimer;
                pSwitchTwoStateTimer = 0;
            }

        }


    //------------------------
    //send event
    //------------------------
        if( fStateChanged == true )
        {
             emit stateChanged(newState);
        }

    }


}
