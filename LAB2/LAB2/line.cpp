#include "line.h"

#define KEY_TYPE "Type"
#define KEY_TOPLEFT_X "TopLeft_X"
#define KEY_TOPLEFT_Y "TopLeft_Y"
#define KEY_BOTRIGHT_X "BottomRight_X"
#define KEY_BOTRIGHT_Y "BottomRight_Y"
#define KEY_CENTERPOINT_X "CenterPoint_X"
#define KEY_CENTERPOINT_Y "CenterPoint_Y"
#define KEY_COLORPEN "ColorPen"
#define KEY_THICKNESS "Thickness"
#define KEY_ROTATE "Rotate"
#define KEY_SCALE "Scale"

Line::Line()
{
    IsContinuous = false;
}

Figure *Line::CreateFigure(){
    return new Line();
}

QString Line::GetFigureClassName(){
    return typeid(this).name();
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
    SetBoundingRect(line -> boundingRect());
}

Figure *Line::CopyItem(){

    Line* copiedItem = new Line();
    QGraphicsLineItem* newLineItem = new QGraphicsLineItem();

    QPen pen;
    pen.setWidth(GetChosedThickness());
    pen.setColor(GetPenColor());

    QRectF rect = GetBoundingRect();

    newLineItem -> setPen(pen);
    newLineItem -> setLine(rect.topLeft().x(), rect.topLeft().y(), rect.bottomRight().x(), rect.bottomRight().y());
    newLineItem -> setScale(GetFigureExternalRepresentation()->scale());
    newLineItem -> setRotation((GetFigureExternalRepresentation()->rotation()));
    newLineItem -> setTransformOriginPoint(GetFigureCenterPoint());

    copiedItem -> SetBoundingRect(GetBoundingRect());
    copiedItem -> SetFigureCenterPoint(GetFigureCenterPoint());
    copiedItem -> SetBrushColor(GetBrushColor());
    copiedItem -> SetPenColor(GetPenColor());
    copiedItem -> SetFigureExternalRepresentation(newLineItem);
    copiedItem -> SetChosedThickness(GetChosedThickness());

    return copiedItem;

}

QJsonObject Line::SerializeFigure()
{
    qreal rotate = GetFigureExternalRepresentation()->rotation();
    qreal scale = GetFigureExternalRepresentation()->scale();

    QJsonObject serialized;
    serialized.insert(KEY_TYPE, QJsonValue::fromVariant(GetFigureClassName()));
    serialized.insert(KEY_TOPLEFT_X, QJsonValue::fromVariant((int)GetBoundingRect().topLeft().x()));
    serialized.insert(KEY_TOPLEFT_Y, QJsonValue::fromVariant((int)GetBoundingRect().topLeft().y()));
    serialized.insert(KEY_BOTRIGHT_X, QJsonValue::fromVariant((int)GetBoundingRect().bottomRight().x()));
    serialized.insert(KEY_BOTRIGHT_Y, QJsonValue::fromVariant((int)GetBoundingRect().bottomRight().y()));
    serialized.insert(KEY_CENTERPOINT_X, QJsonValue::fromVariant((int)GetFigureCenterPoint().x()));
    serialized.insert(KEY_CENTERPOINT_Y, QJsonValue::fromVariant((int)GetFigureCenterPoint().y()));
    serialized.insert(KEY_COLORPEN, QJsonValue::fromVariant(GetPenColor()));
    serialized.insert(KEY_THICKNESS, QJsonValue::fromVariant(GetChosedThickness()));
    serialized.insert(KEY_ROTATE, QJsonValue::fromVariant(rotate));
    serialized.insert(KEY_SCALE, QJsonValue::fromVariant(scale));

    return serialized;
}

Figure *Line::DeSerializeFigure(QJsonObject inObj)
{
    Line* result = new Line();
    QGraphicsLineItem* newLineItem = new QGraphicsLineItem();

    QPen pen;
    pen.setWidth(inObj.value(KEY_THICKNESS).toInt());
    pen.setColor(inObj.value(KEY_COLORPEN).toString());

    QRectF rect;
    rect.setTopLeft(QPointF(inObj.value(KEY_TOPLEFT_X).toInt(), inObj.value(KEY_TOPLEFT_Y).toInt()));
    rect.setBottomRight(QPointF(inObj.value(KEY_BOTRIGHT_X).toInt(), inObj.value(KEY_BOTRIGHT_Y).toInt()));

    newLineItem->setPen(pen);
    newLineItem->setScale(inObj.value(KEY_SCALE).toInt());
    newLineItem->setRotation(inObj.value(KEY_ROTATE).toInt());
    newLineItem->setTransformOriginPoint(inObj.value(KEY_CENTERPOINT_X).toInt(), inObj.value(KEY_CENTERPOINT_Y).toInt());
    newLineItem->setLine(rect.topLeft().x(), rect.topLeft().y(), rect.bottomRight().x(), rect.bottomRight().y());

    result->SetBoundingRect(rect);
    result->SetFigureCenterPoint(QPoint(inObj.value(KEY_CENTERPOINT_X).toInt(), inObj.value(KEY_CENTERPOINT_Y).toInt()));
    result->SetPenColor(inObj.value(KEY_COLORPEN).toString());
    result->SetFigureExternalRepresentation(newLineItem);
    result->SetChosedThickness(inObj.value(KEY_THICKNESS).toInt());

    return result;
}
