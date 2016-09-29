#ifndef SLACKERVIEW_H
#define SLACKERVIEW_H

#include <QtQuick>

class SlackerView : public QQuickView
{

Q_OBJECT

public:
    explicit SlackerView();
    void setModel(QObject * value);

public slots:
    void onUpdateView(int state);
    void onFileStateChanged(int state);

signals:

};

#endif // SLACKERVIEW_H

