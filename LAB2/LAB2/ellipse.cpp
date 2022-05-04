#include "ellipse.h"

Ellipse::Ellipse()
{

}

void Ellipse::Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor penColor, QColor brushColor, int thickness)
{
    ellipse = new QGraphicsEllipseItem();
    SetFigureExternalRepresentation(ellipse);

    QPen pen;
    pen.setWidth(thickness);
    pen.setColor(penColor);

    ellipse -> setPen(pen);
    ellipse -> setBrush(brushColor);
    ellipse -> setRect(event -> scenePos().x(), event -> scenePos().y(), 0, 0);
    X = event -> scenePos().x();
    Y = event -> scenePos().y();
    ellipse -> update();

    scene -> addItem(ellipse);
    scene -> update();

}

void Ellipse::Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene)
{
    ellipse->setRect(X, Y, event->scenePos().x() - X, event->scenePos().y() - Y);
    scene->update();

    QPoint point;
    point.setX((event -> scenePos().x() - X) / 2 + X);
    point.setY(abs((Y + event -> scenePos().y()) / 2));
    SetFigureCenterPoint(point);
}

void Ellipse::Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene)
{
    QPoint point;
    point.setX(ellipse -> boundingRect().topLeft().x() + (ellipse -> boundingRect().bottomRight().x() - ellipse -> boundingRect().topLeft().x()) / 2);
    point.setY(ellipse -> boundingRect().topLeft().y() + (ellipse -> boundingRect().bottomRight().y() - ellipse -> boundingRect().topLeft().y()) / 2);
    SetFigureCenterPoint(point);
}
