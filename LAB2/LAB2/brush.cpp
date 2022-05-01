#include "brush.h"

Brush::Brush()
{

}

Brush::~Brush()
{

}

void Brush::Press(QGraphicsSceneMouseEvent * event, QGraphicsScene *scene, QColor color, int thickness)
{
    scene->addEllipse(event->scenePos().x() - 5,
                      event->scenePos().y() - 5,
                      thickness,
                      thickness,
                      QPen(Qt::NoPen),
                      QBrush(color));

    PreviousPoint = event->scenePos();
}

void Brush::Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor color, int thickness)
{
    scene->addLine(PreviousPoint.x(),
                   PreviousPoint.y(),
                   event->scenePos().x(),
                   event->scenePos().y(),
                   QPen(color, thickness, Qt::SolidLine, Qt::RoundCap));

    PreviousPoint = event->scenePos();
}
