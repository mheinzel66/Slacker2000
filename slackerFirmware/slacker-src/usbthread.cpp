#include "usbthread.h"
#include <QDebug>
#include <QFile>
#include <QDir>

#include <libudev.h>


#include <stdio.h>
#include <stdlib.h>
#include <locale.h>
#include <unistd.h>
#include <string.h>
#include <sys/mount.h>
#include  <errno.h>


UsbThread::UsbThread(QObject *parent) :  QThread(parent)
{
    m_isRunning = false;

}


void UsbThread::monitorUsb()
{
    qDebug() << "UsbThread::monitorUsb()- Monitoring usb...\n";

    struct udev *udev;
    struct udev_device *dev;

    /* Create the udev object */
    udev = udev_new();
    if (!udev)
    {
        qDebug() << "UsbThread::monitorUsb()- Error creating udev\n";
        return;
    }

    /* Set up a monitor to monitor usb devices */
    udev_monitor* mon = udev_monitor_new_from_netlink(udev, "udev");
    udev_monitor_filter_add_match_subsystem_devtype(mon, "usb", NULL);
    udev_monitor_enable_receiving(mon);

    /* Get the file descriptor (fd) for the monitor.
       This fd will get passed to select() */
    int fd = udev_monitor_get_fd(mon);

    enum mountType
    {
        INACTIVE,
        MOUNT,
        UNMOUNT

    };

    /* This section will run continuously, calling usleep() at
       the end of each pass. This is to demonstrate how to use
       a udev_monitor in a non-blocking way. */
    while( m_isRunning )
    {
        /* Set up the call to select(). In this case, select() will
           only operate on a single file descriptor, the one
           associated with our udev_monitor. Note that the timeval
           object is set to 0, which will cause select() to not
           block. */
        fd_set fds;
        struct timeval tv;
        int ret;

        FD_ZERO(&fds);
        FD_SET(fd, &fds);
        tv.tv_sec = 0;
        tv.tv_usec = 0;

        mountType mountState = INACTIVE;

        ret = select(fd+1, &fds, NULL, NULL, &tv);

        /* Check if our file descriptor has received data. */
        if (ret > 0 && FD_ISSET(fd, &fds))
        {

            /* Make the call to receive the device.
               select() ensured that this will not block. */
            dev = udev_monitor_receive_device(mon);
            if (dev)
            {

                //const char* pAction = udev_device_get_action(dev);

                if( strcmp("add",udev_device_get_action(dev))==0 && strcmp("usb_device",udev_device_get_devtype(dev))==0   )
                {
                    printf("   Node: %s\n",  udev_device_get_devnode (dev));
                    qDebug() << "UsbThread::monitorUsb()- USB Device found\n";
                    mountState = MOUNT;
                }
                else if( strcmp("remove",udev_device_get_action(dev))==0 && strcmp("usb_device",udev_device_get_devtype(dev))==0   )
                {
                     qDebug() << "unmountnd\n";
                     mountState = UNMOUNT;
                }

                udev_device_unref(dev);

                int nStatus = 0;

                if (mountState == MOUNT)
                {
                    qDebug() << "Mounting..."  ;
                    emit usbDriveFound(0);

                    sleep(4);
                    nStatus = mount("/dev/slacker", "/media/slacker", "vfat", MS_NOATIME|MS_RDONLY, NULL);

                    qDebug() << "Mounting...Done"  ;

                    emit usbDriveFound(1);
                }
                else if (mountState == UNMOUNT)
                {
                   nStatus = umount("/media/slacker");
                }

                if (nStatus == -1)
                {
                     qDebug() <<  " error:" <<   strerror(errno);
                }
                else
                {
                     qDebug() <<  "Success";
                }

            }
            else
            {
                 qDebug() << "No Device from receive_device(). An error occured.\n";
            }

        }

        usleep(250*1000);
        fflush(stdout);
    }
}




void UsbThread::run()
{
    m_isRunning = true;

    qDebug() << "UsbThread::run()\n";

    QFile devPath("/dev/slacker");

    if( devPath.exists() )
    {
        emit usbDriveFound(0);
        qDebug() <<"Mounting "  ;
        mount("/dev/slacker", "/media/slacker", "vfat", MS_NOATIME|MS_RDONLY, NULL);
        emit usbDriveFound(1);
    }

    //look for usb drive
    monitorUsb();

    m_isRunning = false;

    qDebug() << "UsbThread::run() - ended\n";
}

