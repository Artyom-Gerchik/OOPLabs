#ifndef FIGURELIB_GLOBAL_H
#define FIGURELIB_GLOBAL_H

#include <QtCore/qglobal.h>

#if defined(FIGURELIB_LIBRARY)
#  define FIGURELIB_EXPORT Q_DECL_EXPORT
#else
#  define FIGURELIB_EXPORT Q_DECL_IMPORT
#endif

#endif // FIGURELIB_GLOBAL_H
