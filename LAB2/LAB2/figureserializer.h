#ifndef FIGURESERIALIZER_H
#define FIGURESERIALIZER_H

#include <QFile>
#include <QJsonObject>
#include <QJsonValue>
#include <QJsonDocument>
#include "figure.h"

class FigureSerializer
{
public:
    FigureSerializer();

    bool dump(Figure* fugure, QString filePath);
    Figure* load(QString filePath);
};

#endif // FIGURESERIALIZER_H
