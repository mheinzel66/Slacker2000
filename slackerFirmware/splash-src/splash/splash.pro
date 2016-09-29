#-------------------------------------------------
#
# Project created by QtCreator 2013-02-06T19:11:09
#
#-------------------------------------------------

QT += core  widgets  quick  gui xml

TARGET = splash
TEMPLATE = app
target.path = /etc/slacker/splash

SOURCES += main.cpp\
    splashview.cpp

HEADERS  += \
    splashview.h

FORMS    +=


INSTALLS += target

qml_folder.source = qml
DEPLOYMENTFOLDERS = qml_folder

for(deploymentfolder, DEPLOYMENTFOLDERS) {
    item = item$${deploymentfolder}
    itemsources = $${item}.sources
    $$itemsources = $$eval($${deploymentfolder}.source)
    itempath = $${item}.path
    $$itempath= $$eval($${deploymentfolder}.target)
    export($$itemsources)
    export($$itempath)
    DEPLOYMENT += $$item
}

installPrefix = /root/$${TARGET}

for(deploymentfolder, DEPLOYMENTFOLDERS) {
    item = item$${deploymentfolder}
    itemfiles = $${item}.files
    $$itemfiles = $$eval($${deploymentfolder}.source)
    itempath = $${item}.path
    $$itempath = $${installPrefix}/$$eval($${deploymentfolder}.target)
    export($$itemfiles)
    export($$itempath)
    INSTALLS += $$item
}


OTHER_FILES += \
    qml/* \
    splash.png \
    animation.gif \
    bootsplash.png \
    qml/main.qml
