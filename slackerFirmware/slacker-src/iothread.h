#ifndef IOTHREAD_H
#define IOTHREAD_H

#include <QThread>
#include "gpio.h"

class IoThread : public QThread
{
    Q_OBJECT
public:
    explicit IoThread(QObject *parent = 0);
    void run();
    void turnOffAutoScroll() {m_isAutoScrollMode = false;}

    enum
    {
        PAGE_UP,
        PAGE_DOWN,
        PREV_SECTION,
        NEXT_SECTION,
        DEC_SPEED,
        INC_SPEED,
        START_AUTOSCROLL,
        STOP_AUTOSCROLL,
        UNK_STATE
    };

    enum
    {
       SWITCH_DOWN,
       SWITCH_UP
    };

signals:
    void stateChanged(int state);


public slots:
    void onUsbDriveFound();

private:
    int m_State;//page up, page down,prev up ,next song
    Gpio m_Gpio;
    bool m_isRunning;
    bool m_isAutoScrollMode;

};

#endif // IOTHREAD_H
