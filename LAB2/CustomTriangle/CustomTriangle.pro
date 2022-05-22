QT += widgets

TEMPLATE = lib
DEFINES += CUSTOMTRIANGLE_LIBRARY

CONFIG += c++17

# You can make your code fail to compile if it uses deprecated APIs.
# In order to do so, uncomment the following line.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0

SOURCES += \
    customtriangle.cpp

HEADERS += \
    CustomTriangle_global.h \
    customtriangle.h

# Default rules for deployment.
unix {
    target.path = /usr/lib
}
!isEmpty(target.path): INSTALLS += target

macx: LIBS += -L$$PWD/../Figure/lib/ -lFigureLib.1.0.0

INCLUDEPATH += $$PWD/../Figure/include
DEPENDPATH += $$PWD/../Figure/include
