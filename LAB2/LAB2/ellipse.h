#ifndef ELLIPSE_H
#define ELLIPSE_H

#include "figurelib.h"

class Ellipse : public Figure
{
    int X;
    int Y;
    QGraphicsEllipseItem* ellipse;

public:
    Ellipse();
    void Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor colorPen, QColor colorBrush, int thickness) final;
    void Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene) final;
    void Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene) final;

    Figure *CopyItem() final;
    QJsonObject SerializeFigure() final;
    Figure *DeSerializeFigure(QJsonObject inObj) final;
};

#endif // ELLIPSE_H
