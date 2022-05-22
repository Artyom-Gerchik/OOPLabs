#include "ellipse.h"

#define KEY_TYPE "Type"
#define KEY_TOPLEFT_X "TopLeft_X"
#define KEY_TOPLEFT_Y "TopLeft_Y"
#define KEY_BOTRIGHT_X "BottomRight_X"
#define KEY_BOTRIGHT_Y "BottomRight_Y"
#define KEY_CENTERPOINT_X "CenterPoint_X"
#define KEY_CENTERPOINT_Y "CenterPoint_Y"
#define KEY_COLORBRUSH "ColorBrush"
#define KEY_COLORPEN "ColorPen"
#define KEY_THICKNESS "Thickness"
#define KEY_ROTATE "Rotate"
#define KEY_SCALE "Scale"

Ellipse::Ellipse()
{
    IsContinuous = false;
}

Figure *Ellipse::CreateFigure(){
    return new Ellipse();
}

QString Ellipse::GetFigureClassName(){
    return typeid(this).name();
}

void Ellipse::Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor penColor, QColor brushColor, int thickness)
{

    SetBrushColor(brushColor);
    SetPenColor(penColor);
    SetChosedThickness(thickness);

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
    SetBoundingRect(ellipse->boundingRect());
}

Figure *Ellipse::CopyItem(){
    Ellipse* copiedItem = new Ellipse();
    QGraphicsEllipseItem* newEllipseItem = new QGraphicsEllipseItem();

    QPen pen;
    pen.setWidth(GetChosedThickness());
    pen.setColor(GetPenColor());

    newEllipseItem->setBrush(GetBrushColor());
    newEllipseItem->setPen(pen);
    newEllipseItem->setRect(GetBoundingRect());
    newEllipseItem->setScale(GetFigureExternalRepresentation()->scale());
    newEllipseItem->setRotation((GetFigureExternalRepresentation()->rotation()));
    newEllipseItem->setTransformOriginPoint(GetFigureCenterPoint());

    copiedItem->SetBoundingRect(GetBoundingRect());
    copiedItem->SetFigureCenterPoint(GetFigureCenterPoint());
    copiedItem->SetBrushColor(GetBrushColor());
    copiedItem->SetPenColor(GetPenColor());
    copiedItem->SetFigureExternalRepresentation(newEllipseItem);
    copiedItem->SetChosedThickness(GetChosedThickness());

    return copiedItem;
}

QJsonObject Ellipse::SerializeFigure()
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
    serialized.insert(KEY_COLORBRUSH, QJsonValue::fromVariant(GetBrushColor()));
    serialized.insert(KEY_COLORPEN, QJsonValue::fromVariant(GetPenColor()));
    serialized.insert(KEY_THICKNESS, QJsonValue::fromVariant(GetChosedThickness()));
    serialized.insert(KEY_ROTATE, QJsonValue::fromVariant(rotate));
    serialized.insert(KEY_SCALE, QJsonValue::fromVariant(scale));

    return serialized;
}

Figure *Ellipse::DeSerializeFigure(QJsonObject inObj)
{
    Ellipse* deSerializedItem = new Ellipse();
    QGraphicsEllipseItem* newEllipseItem = new QGraphicsEllipseItem();

    QPen pen;
    pen.setWidth(inObj.value(KEY_THICKNESS).toInt());
    pen.setColor(inObj.value(KEY_COLORPEN).toString());

    QRectF rect;
    rect.setTopLeft(QPointF(inObj.value(KEY_TOPLEFT_X).toInt(), inObj.value(KEY_TOPLEFT_Y).toInt()));
    rect.setBottomRight(QPointF(inObj.value(KEY_BOTRIGHT_X).toInt(), inObj.value(KEY_BOTRIGHT_Y).toInt()));

    newEllipseItem->setRect(rect);
    newEllipseItem->setBrush(QColor(inObj.value(KEY_COLORBRUSH).toString()));
    newEllipseItem->setPen(pen);
    newEllipseItem->setScale(inObj.value(KEY_SCALE).toInt());
    newEllipseItem->setRotation(inObj.value(KEY_ROTATE).toInt());
    newEllipseItem->setTransformOriginPoint(inObj.value(KEY_CENTERPOINT_X).toInt(), inObj.value(KEY_CENTERPOINT_Y).toInt());

    deSerializedItem->SetBoundingRect(rect);
    deSerializedItem->SetFigureCenterPoint(QPoint(inObj.value(KEY_CENTERPOINT_X).toInt(), inObj.value(KEY_CENTERPOINT_Y).toInt()));
    deSerializedItem->SetBrushColor(inObj.value(KEY_COLORBRUSH).toString());
    deSerializedItem->SetPenColor(inObj.value(KEY_COLORPEN).toString());
    deSerializedItem->SetFigureExternalRepresentation(newEllipseItem);
    deSerializedItem->SetChosedThickness(inObj.value(KEY_THICKNESS).toInt());

    return deSerializedItem;
}

