#ifndef ELLIPSE_H
#define ELLIPSE_H

#include "forfigureheirs.h"

class Ellipse : public Figure
{
    int X;
    int Y;
    QGraphicsEllipseItem* ellipse;

public:
    Ellipse();
    void Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor colorPen, QColor colorBrush, int thickness);
    void Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene);
    void Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene);
};

#endif // ELLIPSE_H
