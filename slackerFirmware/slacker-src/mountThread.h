#ifndef MOUNT_H
#define MOUNT_H


#include <QThread>

class MountThread : public QThread
{
    Q_OBJECT
public:
    explicit MountThread(QObject *parent = 0);

signals:
     void mountUsb();

public slots:

private:




};

#endif // MOUNT_H
