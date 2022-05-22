#include "polygon.h"

#define KEY_TYPE "Type"
#define KEY_POLYGON_X "Polygon_point_X_"
#define KEY_POLYGON_Y "Polygon_point_Y_"
#define KEY_CENTERPOINT_X "CenterPoint_X"
#define KEY_CENTERPOINT_Y "CenterPoint_Y"
#define KEY_TOPLEFT_X "TopLeft_X"
#define KEY_TOPLEFT_Y "TopLeft_Y"
#define KEY_BOTRIGHT_X "BottomRight_X"
#define KEY_BOTRIGHT_Y "BottomRight_Y"
#define KEY_COLORBRUSH "ColorBrush"
#define KEY_COLORPEN "ColorPen"
#define KEY_THICKNESS "Thickness"
#define KEY_ROTATE "Rotate"
#define KEY_SCALE "Scale"

Polygon::Polygon()
{
    IsContinuous = true;
    countOfAngles = 0;
    polygon = new QGraphicsPolygonItem();
    Start = true;
}

Figure *Polygon::CreateFigure(){
    return new Polygon();
}

QString Polygon::GetFigureClassName(){
    return typeid(this).name();
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

QJsonObject Polygon::SerializeFigure()
{
    qreal rotate = GetFigureExternalRepresentation()->rotation();
    qreal scale = GetFigureExternalRepresentation()->scale();

    QJsonObject serializeObj;
    serializeObj.insert(KEY_TYPE, QJsonValue::fromVariant(GetFigureClassName()));

    int i = 0;
    foreach(QPointF point, ChosedPolygon)
    {
        serializeObj.insert(KEY_POLYGON_X + QString::number(i), QJsonValue::fromVariant(point.x()));
        serializeObj.insert(KEY_POLYGON_Y + QString::number(i), QJsonValue::fromVariant(point.y()));
        i++;
    }
    serializeObj.insert(KEY_TOPLEFT_X, QJsonValue::fromVariant((int)GetBoundingRect().topLeft().x()));
    serializeObj.insert(KEY_TOPLEFT_Y, QJsonValue::fromVariant((int)GetBoundingRect().topLeft().y()));
    serializeObj.insert(KEY_BOTRIGHT_X, QJsonValue::fromVariant((int)GetBoundingRect().bottomRight().x()));
    serializeObj.insert(KEY_BOTRIGHT_Y, QJsonValue::fromVariant((int)GetBoundingRect().bottomRight().y()));
    serializeObj.insert(KEY_CENTERPOINT_X, QJsonValue::fromVariant((int)GetFigureCenterPoint().x()));
    serializeObj.insert(KEY_CENTERPOINT_Y, QJsonValue::fromVariant((int)GetFigureCenterPoint().y()));
    serializeObj.insert(KEY_COLORBRUSH, QJsonValue::fromVariant(GetBrushColor()));
    serializeObj.insert(KEY_COLORPEN, QJsonValue::fromVariant(GetPenColor()));
    serializeObj.insert(KEY_THICKNESS, QJsonValue::fromVariant(GetChosedThickness()));
    serializeObj.insert(KEY_ROTATE, QJsonValue::fromVariant(rotate));
    serializeObj.insert(KEY_SCALE, QJsonValue::fromVariant(scale));

    return serializeObj;
}

Figure *Polygon::DeSerializeFigure(QJsonObject inObj)
{
    Polygon* result = new Polygon();
    QGraphicsPolygonItem* newPolygonItem = new QGraphicsPolygonItem();

    QPen pen;
    pen.setWidth(inObj.value(KEY_THICKNESS).toInt());
    pen.setColor(inObj.value(KEY_COLORPEN).toString());

    QPolygonF polygon;
    for(int i = 0; i < inObj.length(); i++)
    {
        if(inObj.value(KEY_POLYGON_X + QString::number(i)).toInt() == 0)
            break;
        polygon << QPoint(inObj.value(KEY_POLYGON_X + QString::number(i)).toInt(), inObj.value(KEY_POLYGON_Y + QString::number(i)).toInt());
    }

    QRectF rect;
    rect.setTopLeft(QPointF(inObj.value(KEY_TOPLEFT_X).toInt(), inObj.value(KEY_TOPLEFT_Y).toInt()));
    rect.setBottomRight(QPointF(inObj.value(KEY_BOTRIGHT_X).toInt(), inObj.value(KEY_BOTRIGHT_Y).toInt()));

    newPolygonItem->setBrush(QColor(inObj.value(KEY_COLORBRUSH).toString()));
    newPolygonItem->setPen(pen);
    newPolygonItem->setScale(inObj.value(KEY_SCALE).toInt());
    newPolygonItem->setRotation(inObj.value(KEY_ROTATE).toInt());
    newPolygonItem->setTransformOriginPoint(QPoint(inObj.value(KEY_CENTERPOINT_X).toInt(), inObj.value(KEY_CENTERPOINT_Y).toInt()));
    newPolygonItem->setFillRule(Qt::WindingFill);
    newPolygonItem->setPolygon(polygon);

    result->SetBoundingRect(rect);
    result->SetFigureCenterPoint(QPoint(inObj.value(KEY_CENTERPOINT_X).toInt(), inObj.value(KEY_CENTERPOINT_Y).toInt()));
    result->SetBrushColor(QColor(inObj.value(KEY_COLORBRUSH).toString()));
    result->SetPenColor(inObj.value(KEY_COLORPEN).toString());
    result->SetFigureExternalRepresentation(newPolygonItem);
    result->SetChosedThickness(inObj.value(KEY_THICKNESS).toInt());
    result->ChosedPolygon = polygon;

    return result;
}
