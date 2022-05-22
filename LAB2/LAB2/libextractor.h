#ifndef LIBEXTRACTOR_H
#define LIBEXTRACTOR_H

#include <QString>
#include <QDir>
#include <QLibrary>
#include <QCoreApplication>
#include <QDebug>
#include "figurefactory.h"

class LibExtractor
{
public:
    LibExtractor();

    void UpdateImportedLibs(QStringList *ImportedFigures, FigureFactory* Factory);
};

#endif // LIBEXTRACTOR_H
