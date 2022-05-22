#ifndef FIGUREFACTORY_H
#define FIGUREFACTORY_H

#include "rectangle.h"
#include "ellipse.h"
#include "polygon.h"
#include "line.h"


class FigureFactory
{
public:
    FigureFactory();
    Figure *CreateFigure(QString FigureName);
    void RegistrateNewFigure(Figure* figure);

private:
    QMap<QString, Figure*> FiguresMap;
};

#endif // FIGUREFACTORY_H
