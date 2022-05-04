#include "rectangle.h"

Rectangle::Rectangle()
{

}

void Rectangle::Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor penColor, QColor brushColor, int thickness)
{
    rectangle = new QGraphicsRectItem();
    SetFigureExternalRepresentation(rectangle);

    QPen pen;

    pen.setWidth(thickness);
    pen.setColor(penColor);

    rectangle -> setPen(pen);
    rectangle -> setBrush(brushColor);
    rectangle -> setRect(event -> scenePos().x(), event -> scenePos().y(), 1, 1);
    X = event -> scenePos().x();
    Y = event -> scenePos().y();
    rectangle -> update();

    scene -> addItem(rectangle);
    scene -> update();

}

void Rectangle::Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene)
{
    rectangle->setRect(X, Y, event->scenePos().x() - X, event->scenePos().y() - Y);
    rectangle->setTransformOriginPoint(X, Y);
    scene->update();
}

void Rectangle::Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene)
{
    QPoint point;
    point.setX(rectangle -> boundingRect().topLeft().x() + (rectangle -> boundingRect().bottomRight().x() - rectangle -> boundingRect().topLeft().x()) / 2);
    point.setY(rectangle -> boundingRect().topLeft().y() + (rectangle -> boundingRect().bottomRight().y() - rectangle -> boundingRect().topLeft().y()) / 2);
    SetFigureCenterPoint(point);
}
