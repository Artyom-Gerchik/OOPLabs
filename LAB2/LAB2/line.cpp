#include "line.h"

Line::Line()
{

    IsContinuous = false;

}

void Line::Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor penColor, QColor brushColor, int thickness)
{
    SetBrushColor(brushColor);
    SetPenColor(penColor);
    SetChosedThickness(thickness);

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

Figure *Line::CopyItem(){

    Line* copiedItem = new Line();
    QGraphicsLineItem* newLineItem = new QGraphicsLineItem();

    QPen pen;
    pen.setWidth(GetChosedThickness());
    pen.setColor(GetPenColor());

    QRectF rect = GetFigureExternalRepresentation()->boundingRect();

    newLineItem->setPen(pen);
    newLineItem->setLine(rect.topLeft().x(), rect.topLeft().y(), rect.bottomRight().x(), rect.bottomRight().y());
    newLineItem->setScale(GetFigureExternalRepresentation()->scale());
    newLineItem->setRotation((GetFigureExternalRepresentation()->rotation()));
    newLineItem->setTransformOriginPoint(GetFigureCenterPoint());

    copiedItem->SetBoundingRect(GetBoundingRect());
    copiedItem->SetFigureCenterPoint(GetFigureCenterPoint());
    copiedItem->SetBrushColor(GetBrushColor());
    copiedItem->SetPenColor(GetPenColor());
    copiedItem->SetFigureExternalRepresentation(newLineItem);
    copiedItem->SetChosedThickness(GetChosedThickness());

    return copiedItem;

}
