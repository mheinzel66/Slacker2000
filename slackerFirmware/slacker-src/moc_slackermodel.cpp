/****************************************************************************
** Meta object code from reading C++ file 'slackermodel.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.2)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "slackermodel.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'slackermodel.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.2. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_SlackerModel_t {
    QByteArrayData data[11];
    char stringdata0[152];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_SlackerModel_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_SlackerModel_t qt_meta_stringdata_SlackerModel = {
    {
QT_MOC_LITERAL(0, 0, 12), // "SlackerModel"
QT_MOC_LITERAL(1, 13, 16), // "fileStateChanged"
QT_MOC_LITERAL(2, 30, 0), // ""
QT_MOC_LITERAL(3, 31, 5), // "state"
QT_MOC_LITERAL(4, 37, 13), // "usbDriveFound"
QT_MOC_LITERAL(5, 51, 10), // "onLoadData"
QT_MOC_LITERAL(6, 62, 10), // "onUsbFound"
QT_MOC_LITERAL(7, 73, 21), // "getNextSectionLineNum"
QT_MOC_LITERAL(8, 95, 14), // "currentLineNum"
QT_MOC_LITERAL(9, 110, 21), // "getPrevSectionLineNum"
QT_MOC_LITERAL(10, 132, 19) // "getEndofFileLineNum"

    },
    "SlackerModel\0fileStateChanged\0\0state\0"
    "usbDriveFound\0onLoadData\0onUsbFound\0"
    "getNextSectionLineNum\0currentLineNum\0"
    "getPrevSectionLineNum\0getEndofFileLineNum"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_SlackerModel[] = {

 // content:
       7,       // revision
       0,       // classname
       0,    0, // classinfo
       7,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       2,       // signalCount

 // signals: name, argc, parameters, tag, flags
       1,    1,   49,    2, 0x06 /* Public */,
       4,    1,   52,    2, 0x06 /* Public */,

 // slots: name, argc, parameters, tag, flags
       5,    0,   55,    2, 0x0a /* Public */,
       6,    1,   56,    2, 0x0a /* Public */,

 // methods: name, argc, parameters, tag, flags
       7,    1,   59,    2, 0x02 /* Public */,
       9,    1,   62,    2, 0x02 /* Public */,
      10,    0,   65,    2, 0x02 /* Public */,

 // signals: parameters
    QMetaType::Void, QMetaType::Int,    3,
    QMetaType::Void, QMetaType::Int,    3,

 // slots: parameters
    QMetaType::Void,
    QMetaType::Void, QMetaType::Int,    3,

 // methods: parameters
    QMetaType::Int, QMetaType::Int,    8,
    QMetaType::Int, QMetaType::Int,    8,
    QMetaType::Int,

       0        // eod
};

void SlackerModel::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        SlackerModel *_t = static_cast<SlackerModel *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->fileStateChanged((*reinterpret_cast< int(*)>(_a[1]))); break;
        case 1: _t->usbDriveFound((*reinterpret_cast< int(*)>(_a[1]))); break;
        case 2: _t->onLoadData(); break;
        case 3: _t->onUsbFound((*reinterpret_cast< int(*)>(_a[1]))); break;
        case 4: { int _r = _t->getNextSectionLineNum((*reinterpret_cast< const int(*)>(_a[1])));
            if (_a[0]) *reinterpret_cast< int*>(_a[0]) = _r; }  break;
        case 5: { int _r = _t->getPrevSectionLineNum((*reinterpret_cast< const int(*)>(_a[1])));
            if (_a[0]) *reinterpret_cast< int*>(_a[0]) = _r; }  break;
        case 6: { int _r = _t->getEndofFileLineNum();
            if (_a[0]) *reinterpret_cast< int*>(_a[0]) = _r; }  break;
        default: ;
        }
    } else if (_c == QMetaObject::IndexOfMethod) {
        int *result = reinterpret_cast<int *>(_a[0]);
        void **func = reinterpret_cast<void **>(_a[1]);
        {
            typedef void (SlackerModel::*_t)(int );
            if (*reinterpret_cast<_t *>(func) == static_cast<_t>(&SlackerModel::fileStateChanged)) {
                *result = 0;
                return;
            }
        }
        {
            typedef void (SlackerModel::*_t)(int );
            if (*reinterpret_cast<_t *>(func) == static_cast<_t>(&SlackerModel::usbDriveFound)) {
                *result = 1;
                return;
            }
        }
    }
}

const QMetaObject SlackerModel::staticMetaObject = {
    { &ListModel::staticMetaObject, qt_meta_stringdata_SlackerModel.data,
      qt_meta_data_SlackerModel,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *SlackerModel::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *SlackerModel::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_SlackerModel.stringdata0))
        return static_cast<void*>(const_cast< SlackerModel*>(this));
    return ListModel::qt_metacast(_clname);
}

int SlackerModel::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = ListModel::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 7)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 7;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 7)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 7;
    }
    return _id;
}

// SIGNAL 0
void SlackerModel::fileStateChanged(int _t1)
{
    void *_a[] = { Q_NULLPTR, const_cast<void*>(reinterpret_cast<const void*>(&_t1)) };
    QMetaObject::activate(this, &staticMetaObject, 0, _a);
}

// SIGNAL 1
void SlackerModel::usbDriveFound(int _t1)
{
    void *_a[] = { Q_NULLPTR, const_cast<void*>(reinterpret_cast<const void*>(&_t1)) };
    QMetaObject::activate(this, &staticMetaObject, 1, _a);
}
QT_END_MOC_NAMESPACE
