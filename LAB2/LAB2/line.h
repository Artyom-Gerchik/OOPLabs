#ifndef LINE_H
#define LINE_H

#include "figurelib.h"

class Line : public Figure
{

private:
    int X;
    int Y;
    QGraphicsLineItem* line;

public:
    Line();

    Figure *CreateFigure() final;
    QString GetFigureClassName() final;

    void Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor colorPen, QColor colorBrush, int thickness) final;
    void Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene) final;
    void Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene) final;

    Figure *CopyItem() final;
    QJsonObject SerializeFigure() final;
    Figure *DeSerializeFigure(QJsonObject inObj) final;

};

#endif // LINE_H
