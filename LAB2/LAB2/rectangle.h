#ifndef RECTANGLE_H
#define RECTANGLE_H

#include "figurelib.h"
#include <QJsonObject>

class Rectangle : public Figure
{

private:
    int X;
    int Y;
    QGraphicsRectItem* rectangle;

public:
    Rectangle();

    Figure *CreateFigure() final;
    QString GetFigureClassName() final;

    void Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor colorPen, QColor colorBrush, int thickness) final;
    void Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene) final;
    void Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene) final;

    Figure *CopyItem() final;
    QJsonObject SerializeFigure() final;
    Figure *DeSerializeFigure(QJsonObject inObj) final;
};

#endif // RECTANGLE_H
