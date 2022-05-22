#ifndef BROKEN_H
#define BROKEN_H

#include "forfigureheirs.h"

class Broken : public Figure
{
private:
    int X;
    int Y;
    QGraphicsLineItem* broken;

    QColor chosedPenColor;

    int chosedPenThickness;

public:
    Broken();
    void Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor penColor, QColor brushColor, int thickness) final;
    void Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene) final;
    void Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene) final;

    QJsonObject SerializeFigure() final;
    Figure *CopyItem() final;
};

#endif // BROKEN_H
