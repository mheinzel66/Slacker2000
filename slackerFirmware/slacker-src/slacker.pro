#-------------------------------------------------
#
# Project created by QtCreator 2012-07-03T13:17:28
#
#-------------------------------------------------

QT += core widgets quick  gui xml

TARGET = slacker
TEMPLATE = app
target.path = /etc/slacker
INSTALLS += target

SOURCES += main.cpp \
    gpio.cpp \
    iothread.cpp \
    listmodel.cpp \
    linetext.cpp \
    slackermodel.cpp \
    slackerview.cpp \
    usbthread.cpp

HEADERS  += \
    gpio.h \
    iothread.h \
    usbthread.h \
    listmodel.h \
    linetext.h \
    slackermodel.h \
    slackerview.h \
    mountThread.h

FORMS    +=


qml_folder.source =  /$${TARGET}/qml
DEPLOYMENTFOLDERS =  qml_folder

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

installPrefix = /$${TARGET}

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
    qml/*


unix:!macx: LIBS += -L$$PWD/../../../../mnt/rasp-pi-rootfs/lib/arm-linux-gnueabihf/ -ludev

INCLUDEPATH += $$PWD/../../../../mnt/rasp-pi-rootfs/lib/arm-linux-gnueabihf
DEPENDPATH += $$PWD/../../../../mnt/rasp-pi-rootfs/lib/arm-linux-gnueabihf
