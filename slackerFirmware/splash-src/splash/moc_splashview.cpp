/****************************************************************************
** Meta object code from reading C++ file 'splashview.h'
**
** Created: Tue Feb 26 19:06:24 2013
**      by: The Qt Meta Object Compiler version 64 (Qt 5.0.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "splashview.h"
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'splashview.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 64
#error "This file was generated using the moc from 5.0.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
static const uint qt_meta_data_SplashView[] = {

 // content:
       6,       // revision
       0,       // classname
       0,    0, // classinfo
       0,    0, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       0,       // signalCount

       0        // eod
};

static const char qt_meta_stringdata_SplashView[] = {
    "SplashView\0"
};

void SplashView::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    Q_UNUSED(_o);
    Q_UNUSED(_id);
    Q_UNUSED(_c);
    Q_UNUSED(_a);
}

const QMetaObjectExtraData SplashView::staticMetaObjectExtraData = {
    0,  qt_static_metacall 
};

const QMetaObject SplashView::staticMetaObject = {
    { &QQuickView::staticMetaObject, qt_meta_stringdata_SplashView,
      qt_meta_data_SplashView, &staticMetaObjectExtraData }
};

const QMetaObject *SplashView::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->metaObject : &staticMetaObject;
}

void *SplashView::qt_metacast(const char *_clname)
{
    if (!_clname) return 0;
    if (!strcmp(_clname, qt_meta_stringdata_SplashView))
        return static_cast<void*>(const_cast< SplashView*>(this));
    return QQuickView::qt_metacast(_clname);
}

int SplashView::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QQuickView::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    return _id;
}
QT_END_MOC_NAMESPACE
