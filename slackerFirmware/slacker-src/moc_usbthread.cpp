/****************************************************************************
** Meta object code from reading C++ file 'usbthread.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.2)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "usbthread.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'usbthread.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.2. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_UsbThread_t {
    QByteArrayData data[5];
    char stringdata0[48];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_UsbThread_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_UsbThread_t qt_meta_stringdata_UsbThread = {
    {
QT_MOC_LITERAL(0, 0, 9), // "UsbThread"
QT_MOC_LITERAL(1, 10, 13), // "usbDriveFound"
QT_MOC_LITERAL(2, 24, 0), // ""
QT_MOC_LITERAL(3, 25, 5), // "state"
QT_MOC_LITERAL(4, 31, 16) // "fileStateChanged"

    },
    "UsbThread\0usbDriveFound\0\0state\0"
    "fileStateChanged"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_UsbThread[] = {

 // content:
       7,       // revision
       0,       // classname
       0,    0, // classinfo
       2,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       2,       // signalCount

 // signals: name, argc, parameters, tag, flags
       1,    1,   24,    2, 0x06 /* Public */,
       4,    1,   27,    2, 0x06 /* Public */,

 // signals: parameters
    QMetaType::Void, QMetaType::Int,    3,
    QMetaType::Void, QMetaType::Int,    3,

       0        // eod
};

void UsbThread::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        UsbThread *_t = static_cast<UsbThread *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->usbDriveFound((*reinterpret_cast< int(*)>(_a[1]))); break;
        case 1: _t->fileStateChanged((*reinterpret_cast< int(*)>(_a[1]))); break;
        default: ;
        }
    } else if (_c == QMetaObject::IndexOfMethod) {
        int *result = reinterpret_cast<int *>(_a[0]);
        void **func = reinterpret_cast<void **>(_a[1]);
        {
            typedef void (UsbThread::*_t)(int );
            if (*reinterpret_cast<_t *>(func) == static_cast<_t>(&UsbThread::usbDriveFound)) {
                *result = 0;
                return;
            }
        }
        {
            typedef void (UsbThread::*_t)(int );
            if (*reinterpret_cast<_t *>(func) == static_cast<_t>(&UsbThread::fileStateChanged)) {
                *result = 1;
                return;
            }
        }
    }
}

const QMetaObject UsbThread::staticMetaObject = {
    { &QThread::staticMetaObject, qt_meta_stringdata_UsbThread.data,
      qt_meta_data_UsbThread,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *UsbThread::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *UsbThread::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_UsbThread.stringdata0))
        return static_cast<void*>(const_cast< UsbThread*>(this));
    return QThread::qt_metacast(_clname);
}

int UsbThread::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QThread::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 2)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 2;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 2)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 2;
    }
    return _id;
}

// SIGNAL 0
void UsbThread::usbDriveFound(int _t1)
{
    void *_a[] = { Q_NULLPTR, const_cast<void*>(reinterpret_cast<const void*>(&_t1)) };
    QMetaObject::activate(this, &staticMetaObject, 0, _a);
}

// SIGNAL 1
void UsbThread::fileStateChanged(int _t1)
{
    void *_a[] = { Q_NULLPTR, const_cast<void*>(reinterpret_cast<const void*>(&_t1)) };
    QMetaObject::activate(this, &staticMetaObject, 1, _a);
}
QT_END_MOC_NAMESPACE
