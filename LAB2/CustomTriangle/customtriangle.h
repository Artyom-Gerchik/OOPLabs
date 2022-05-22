#ifndef CUSTOMTRIANGLE_H
#define CUSTOMTRIANGLE_H

#include "CustomTriangle_global.h"

#include <QGraphicsScene>
#include <QGraphicsRectItem>
#include <QGraphicsSceneMouseEvent>

#include "figurelib.h"

extern "C" CUSTOMTRIANGLE_EXPORT Figure* extractFromLibrary();

class CustomTriangle : public Figure
{
private:
    int X;
    int Y;
    QGraphicsPolygonItem* customTriangle;

    QColor chosedPenColor;
    QColor chosedBrushColor;
    int chosedThickness;
    QPolygonF currentPolygon;

public:
    CustomTriangle();

    Figure *CreateFigure() final;
    QString GetFigureClassName() final;

    void Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor colorPen, QColor colorBrush, int thickness) final;
    void Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene) final;
    void Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene) final;

    Figure *CopyItem() final;
    QJsonObject SerializeFigure() final;
    Figure *DeSerializeFigure(QJsonObject inObj) final;
};

#endif // CUSTOMTRIANGLE_H
