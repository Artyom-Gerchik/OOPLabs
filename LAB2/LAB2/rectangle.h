#ifndef RECTANGLE_H
#define RECTANGLE_H

#include "forfigureheirs.h"

class Rectangle : public Figure
{

private:
    int X;
    int Y;
    QGraphicsRectItem* rectangle;

public:
    Rectangle();
    void Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor colorPen, QColor colorBrush, int thickness);
    void Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene);
    void Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene);
};

#endif // RECTANGLE_H
