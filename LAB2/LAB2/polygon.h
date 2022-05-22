#ifndef POLYGON_H
#define POLYGON_H

#include "figurelib.h"

class Polygon : public Figure
{
private:
    int countOfAngles;
    bool Start;
    QGraphicsPolygonItem* polygon;
    QPolygonF ChosedPolygon;


    QColor chosedPenColor;
    QColor chosedBrushColor;
    int chosedPenThickness;

public:
    Polygon();
    void Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor colorPen, QColor colorBrush, int thickness) final;
    void Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene) final;
    void Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene) final;

    Figure *CopyItem() final;
    QJsonObject SerializeFigure() final;
    Figure *DeSerializeFigure(QJsonObject inObj) final;
};

#endif // POLYGON_H
