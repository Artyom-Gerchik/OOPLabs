#ifndef BRUSH_H
#define BRUSH_H

#include <QGraphicsScene>
#include <QGraphicsSceneMouseEvent>
#include <QTimer>
#include <QDebug>

class Brush
{

private:
    QPointF PreviousPoint;
public:
    Brush();
    ~Brush();

    void Press(QGraphicsSceneMouseEvent * event, QGraphicsScene *scene, QColor color, int thickness);
    void Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor color, int thickness);
};

#endif // BRUSH_H
