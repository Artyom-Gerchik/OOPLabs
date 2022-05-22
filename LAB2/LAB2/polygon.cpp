#include "polygon.h"

Polygon::Polygon()
{
    IsContinuous = true;
    countOfAngles = 0;
    polygon = new QGraphicsPolygonItem();
    Start = true;
}

void Polygon::Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor penColor, QColor brushColor, int thickness)
{
    SetBrushColor(brushColor);
    SetPenColor(penColor);
    SetChosedThickness(thickness);

    QPolygonF polygonf = polygon -> polygon();
    SetFigureExternalRepresentation(polygon);

    if(Start){

        polygonf << QPointF(event -> scenePos().x(), event -> scenePos().y());
        chosedPenColor = penColor;
        chosedBrushColor = brushColor;
        chosedPenThickness = thickness;
        Start = false;
    }

    polygonf << QPointF(event -> scenePos().x(), event -> scenePos().y());
    polygon -> setFillRule(Qt::WindingFill); // fix for star problem
    polygon -> setPolygon(polygonf);
    countOfAngles++;


    QPen pen;

    pen.setWidth(thickness);
    pen.setColor(penColor);

    polygon -> setPen(pen);
    polygon -> setBrush(brushColor);
    polygon -> update();

    scene -> addItem(polygon);
    scene -> update();

}

void Polygon::Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene)
{
    QPolygonF polygonf = polygon -> polygon();
    polygonf[countOfAngles] = QPointF(event -> scenePos().x(), event -> scenePos().y());
    polygon -> setPolygon(polygonf);
    scene->update();
}

void Polygon::Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scen)
{
    QPoint point;
    point.setX(polygon -> boundingRect().topLeft().x() + (polygon -> boundingRect().bottomRight().x() - polygon -> boundingRect().topLeft().x()) / 2);
    point.setY(polygon -> boundingRect().topLeft().y() + (polygon -> boundingRect().bottomRight().y() - polygon -> boundingRect().topLeft().y()) / 2);
    SetFigureCenterPoint(point);
    SetBoundingRect(polygon->boundingRect());
    ChosedPolygon = polygon->polygon();
}

Figure *Polygon::CopyItem(){

    Polygon* copiedItem = new Polygon();
    QGraphicsPolygonItem* newPolygonItem = new QGraphicsPolygonItem();

    QPen pen;
    pen.setWidth(GetChosedThickness());
    pen.setColor(GetPenColor());

    newPolygonItem->setBrush(GetBrushColor());
    newPolygonItem->setPen(pen);
    newPolygonItem->setScale(GetFigureExternalRepresentation()->scale());
    newPolygonItem->setRotation((GetFigureExternalRepresentation()->rotation()));
    newPolygonItem->setTransformOriginPoint(GetFigureCenterPoint());
    newPolygonItem->setFillRule(Qt::WindingFill);
    newPolygonItem->setPolygon(ChosedPolygon);

    copiedItem->SetBoundingRect(GetBoundingRect());
    copiedItem->SetFigureCenterPoint(GetFigureCenterPoint());
    copiedItem->SetBrushColor(GetBrushColor());
    copiedItem->SetPenColor(GetPenColor());
    copiedItem->SetFigureExternalRepresentation(newPolygonItem);
    copiedItem->SetChosedThickness(GetChosedThickness());

    return copiedItem;

}
