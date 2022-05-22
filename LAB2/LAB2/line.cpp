#include "line.h"

Line::Line()
{

    IsContinuous = false;

}

void Line::Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor penColor, QColor brushColor, int thickness)
{
    line = new QGraphicsLineItem();
    SetFigureExternalRepresentation(line);

    QPen pen;
    pen.setWidth(thickness);
    pen.setColor(penColor);

    line -> setPen(pen);
    line -> setLine(event -> scenePos().x(), event -> scenePos().y(), event -> scenePos().x(), event -> scenePos().y());
    X = event -> scenePos().x();
    Y = event -> scenePos().y();
    line -> update();

    scene -> addItem(line);
    scene -> update();

}

void Line::Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene)
{
    line -> setLine(X, Y, event->scenePos().x(), event->scenePos().y());
    scene->update();
}

void Line::Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene)
{
    QPoint point;
    point.setX(line -> boundingRect().topLeft().x() + (line -> boundingRect().bottomRight().x() - line -> boundingRect().topLeft().x()) / 2);
    point.setY(line -> boundingRect().topLeft().y() + (line -> boundingRect().bottomRight().y() - line -> boundingRect().topLeft().y()) / 2);
    SetFigureCenterPoint(point);
}
