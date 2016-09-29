#include "gpio.h"
#include "usbthread.h"
#include "iothread.h"
#include "slackermodel.h"

#include <libudev.h>
#include <stdio.h>
#include <stdlib.h>
#include <locale.h>
#include <unistd.h>

#include <QApplication>
#include <QtGui>
#include "slackerview.h"

int main(int argc, char *argv[])
{
    qDebug() << "Starting...\n";
    QApplication app(argc, argv);

    UsbThread usbThread;   
    usbThread.start();

    IoThread ioThread;
    ioThread.start();

    SlackerView slackerView;
    slackerView.setResizeMode(QQuickView::SizeRootObjectToView);

    SlackerModel slackerModel(qApp);
    slackerView.setModel(&slackerModel);

    QObject::connect(&ioThread, SIGNAL(stateChanged(int)), &slackerView, SLOT(onUpdateView(int)));

    QObject::connect(&usbThread, SIGNAL(usbDriveFound(int)), &slackerModel, SLOT( onUsbFound(int) ) );
    QObject::connect(&slackerModel, SIGNAL(fileStateChanged(int)), &slackerView, SLOT(onFileStateChanged(int)));
     //mounting
    //loading
    //loaded

    slackerView.setSource(QUrl::fromLocalFile("/etc/slacker/qml/main.qml"));

    slackerView.show();

    slackerModel.loadData();

    sleep(3);
    qDebug() << "killing splash...\n";
    system("killall 'splash'");

    return app.exec();
}

