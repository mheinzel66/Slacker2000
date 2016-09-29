#ifndef USBTHREAD_H
#define USBTHREAD_H

#include <QThread>

class UsbThread : public QThread
{
    Q_OBJECT

public:
    explicit UsbThread(QObject *parent = 0);
    void run();
    void monitorUsb();


signals:
    void usbDriveFound(int state);
    void fileStateChanged(int state);

public slots:

private:
     bool m_isRunning;



};

#endif // USBTHREAD_H
