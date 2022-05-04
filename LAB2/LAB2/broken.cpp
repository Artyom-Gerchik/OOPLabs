#include "broken.h"

Broken::Broken()
{
    start = true;
}

void Broken::Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor penColor, QColor brushColor, int thickness)
{
    if(start){
        chosedPenColor = penColor;
        chosedPenThickness = thickness;
    }


    broken = new QGraphicsLineItem();
    SetFigureExternalRepresentation(broken);

    QPen pen;

    pen.setWidth(thickness);
    pen.setColor(penColor);

    broken -> setPen(pen);

    if(start){
        X = event -> scenePos().x();
        Y = event -> scenePos().y();
        broken -> setLine(X, Y, X, Y);
    }
    else{
        broken -> setLine(X, Y, event -> scenePos().x(), event -> scenePos().y());
    }

    broken -> update();

    scene -> addItem(broken);
    scene -> update();

}

void Broken::Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene)
{
    broken -> setLine(X, Y, event->scenePos().x(), event->scenePos().y());
    scene -> update();
}

void Broken::Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene)
{
    X = event -> scenePos().x();
    Y = event -> scenePos().y();

    start = false;

    QPoint point;
    point.setX(broken -> boundingRect().topLeft().x() + (broken -> boundingRect().bottomRight().x() - broken -> boundingRect().topLeft().x()) / 2);
    point.setY(broken -> boundingRect().topLeft().y() + (broken -> boundingRect().bottomRight().y() - broken -> boundingRect().topLeft().y()) / 2);
    SetFigureCenterPoint(point);
}
