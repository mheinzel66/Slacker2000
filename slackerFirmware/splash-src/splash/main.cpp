


#include <stdio.h>
#include <stdlib.h>
#include <locale.h>
#include <unistd.h>

#include <QApplication>
#include <QtGui>
#include "splashview.h"

int main(int argc, char *argv[])
{
    qDebug() << "Starting...\n";
    QApplication a(argc, argv);

    SplashView splashView;
    splashView.setResizeMode(QQuickView::SizeRootObjectToView);
    splashView.setSource(QUrl::fromLocalFile("/etc/slacker/splash/qml/main.qml"));

    splashView.show();


    return a.exec();
}
