#ifndef RECTANGLE_H
#define RECTANGLE_H

#include "forfigureheirs.h"
#include <QJsonObject>

class Rectangle : public Figure
{

private:
    int X;
    int Y;
    QGraphicsRectItem* rectangle;

public:
    Rectangle();
    void Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor colorPen, QColor colorBrush, int thickness) final;
    void Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene) final;
    void Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene) final;

    QJsonObject SerializeFigure() final;
    Figure *CopyItem() final;
};

#endif // RECTANGLE_H
