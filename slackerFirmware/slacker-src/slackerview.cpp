#include "slackerview.h"
#include <QGraphicsObject>


SlackerView::SlackerView():QQuickView()
{
}

void SlackerView::setModel(QObject* value)
{
 //   qDebug() << "SlackerView::setModel()\n";
    QQmlContext* pQmlContext = this->rootContext() ;
    pQmlContext->setContextProperty("slackerModel", value);
}


void SlackerView::onUpdateView(int state)
{
 //    qDebug() << "SlackerView::onUpdateView()\n";
     QObject *rootObject = this->rootObject();
     QMetaObject::invokeMethod(rootObject, "updateStateChange",Q_ARG(QVariant,state));
}

void SlackerView::onFileStateChanged(int state)
{
 //   qDebug() << "SlackerView::onFileStateChanged()\n";
    QObject *rootObject = this->rootObject();
    QMetaObject::invokeMethod(rootObject, "updateFileStateChange",Q_ARG(QVariant,state));

}
