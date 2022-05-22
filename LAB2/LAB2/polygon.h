#ifndef POLYGON_H
#define POLYGON_H

#include "forfigureheirs.h"

class Polygon : public Figure
{
private:
    int countOfAngles;
    bool Start;
    QGraphicsPolygonItem* polygon;

    QColor chosedPenColor;
    QColor chosedBrushColor;
    int chosedPenThickness;

public:
    Polygon();
    void Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor colorPen, QColor colorBrush, int thickness);
    void Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene);
    void Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene);
};

#endif // POLYGON_H
