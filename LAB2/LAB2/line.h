#ifndef LINE_H
#define LINE_H

#include "forfigureheirs.h"

class Line : public Figure
{

private:
    int X;
    int Y;
    QGraphicsLineItem* line;

public:
    Line();
    void Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor colorPen, QColor colorBrush, int thickness);
    void Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene);
    void Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene);

};

#endif // LINE_H
