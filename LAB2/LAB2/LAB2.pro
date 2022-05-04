QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

CONFIG += c++17

# You can make your code fail to compile if it uses deprecated APIs.
# In order to do so, uncomment the following line.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0

SOURCES += \
    broken.cpp \
    brush.cpp \
    ellipse.cpp \
    figure.cpp \
    floodfill.cpp \
    line.cpp \
    main.cpp \
    mainscene.cpp \
    mainwindow.cpp \
    polygon.cpp \
    rectangle.cpp

HEADERS += \
    broken.h \
    brush.h \
    ellipse.h \
    figure.h \
    floodfill.h \
    forfigureheirs.h \
    formainwindow.h \
    line.h \
    mainscene.h \
    mainwindow.h \
    polygon.h \
    rectangle.h \
    toolsenum.h

FORMS += \
    mainwindow.ui

# Default rules for deployment.
qnx: target.path = /tmp/$${TARGET}/bin
else: unix:!android: target.path = /opt/$${TARGET}/bin
!isEmpty(target.path): INSTALLS += target
