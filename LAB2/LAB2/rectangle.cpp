#include "rectangle.h"

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


Rectangle::Rectangle()
{
    IsContinuous = false;
}

void Rectangle::Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor penColor, QColor brushColor, int thickness)
{
    SetBrushColor(brushColor);
    SetPenColor(penColor);
    SetChosedThickness(thickness);

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
    SetBoundingRect(rectangle->boundingRect());
}

Figure *Rectangle::CopyItem(){

    Rectangle* copiedItem = new Rectangle();
    QGraphicsRectItem* newRectItem = new QGraphicsRectItem();

    QPen pen;
    pen.setWidth(GetChosedThickness());
    pen.setColor(GetPenColor());

    newRectItem->setBrush(GetBrushColor());
    newRectItem->setPen(pen);
    newRectItem->setRect(GetBoundingRect());
    newRectItem->setScale(GetFigureExternalRepresentation()->scale());
    newRectItem->setRotation((GetFigureExternalRepresentation()->rotation()));
    newRectItem->setTransformOriginPoint(GetFigureCenterPoint());
    newRectItem->setGraphicsEffect(GetFigureExternalRepresentation()->graphicsEffect());

    copiedItem->SetBoundingRect(GetBoundingRect());
    copiedItem->SetFigureCenterPoint(GetFigureCenterPoint());
    copiedItem->SetBrushColor(GetBrushColor());
    copiedItem->SetPenColor(GetPenColor());
    copiedItem->SetFigureExternalRepresentation(newRectItem);
    copiedItem->SetChosedThickness(GetChosedThickness());

    return copiedItem;

}

QJsonObject Rectangle::SerializeFigure(){
    qreal rotate = GetFigureExternalRepresentation()->rotation();
    qreal scale = GetFigureExternalRepresentation()->scale();

    QJsonObject serializedRect;

    serializedRect.insert(KEY_TYPE, QJsonValue::fromVariant("Rectangle"));
    serializedRect.insert(KEY_TOPLEFT_X, QJsonValue::fromVariant(GetBoundingRect().topLeft().x()));
    serializedRect.insert(KEY_TOPLEFT_Y, QJsonValue::fromVariant(GetBoundingRect().topLeft().y()));
    serializedRect.insert(KEY_BOTRIGHT_X, QJsonValue::fromVariant(GetBoundingRect().bottomRight().x()));
    serializedRect.insert(KEY_BOTRIGHT_Y, QJsonValue::fromVariant(GetBoundingRect().bottomRight().y()));
    serializedRect.insert(KEY_CENTERPOINT_X, QJsonValue::fromVariant(GetFigureCenterPoint().x()));
    serializedRect.insert(KEY_CENTERPOINT_Y, QJsonValue::fromVariant(GetFigureCenterPoint().y()));
    serializedRect.insert(KEY_COLORBRUSH, QJsonValue::fromVariant(GetBrushColor()));
    serializedRect.insert(KEY_COLORPEN, QJsonValue::fromVariant(GetPenColor()));
    serializedRect.insert(KEY_THICKNESS, QJsonValue::fromVariant(GetChosedThickness()));
    serializedRect.insert(KEY_ROTATE, QJsonValue::fromVariant(rotate));
    serializedRect.insert(KEY_SCALE, QJsonValue::fromVariant(scale));

    return serializedRect;
}

Figure *Rectangle::DeSerializeFigure(QJsonObject inObj)
{
    Rectangle* result = new Rectangle();
    QGraphicsRectItem* newRectangleItem = new QGraphicsRectItem();

    QPen pen;
    pen.setWidth(inObj.value(KEY_THICKNESS).toInt());
    pen.setColor(inObj.value(KEY_COLORPEN).toString());

    QRectF rect;
    rect.setTopLeft(QPointF(inObj.value(KEY_TOPLEFT_X).toInt(), inObj.value(KEY_TOPLEFT_Y).toInt()));
    rect.setBottomRight(QPointF(inObj.value(KEY_BOTRIGHT_X).toInt(), inObj.value(KEY_BOTRIGHT_Y).toInt()));

    newRectangleItem->setRect(rect);
    newRectangleItem->setBrush(QColor(inObj.value(KEY_COLORBRUSH).toString()));
    newRectangleItem->setPen(pen);
    newRectangleItem->setScale(inObj.value(KEY_SCALE).toInt());
    newRectangleItem->setRotation(inObj.value(KEY_ROTATE).toInt());
    newRectangleItem->setTransformOriginPoint(inObj.value(KEY_CENTERPOINT_X).toInt(), inObj.value(KEY_CENTERPOINT_Y).toInt());

    result->SetBoundingRect(rect);
    result->SetFigureCenterPoint(QPoint(inObj.value(KEY_CENTERPOINT_X).toInt(), inObj.value(KEY_CENTERPOINT_Y).toInt()));
    result->SetBrushColor(inObj.value(KEY_COLORBRUSH).toString());
    result->SetPenColor(inObj.value(KEY_COLORPEN).toString());
    result->SetFigureExternalRepresentation(newRectangleItem);
    result->SetChosedThickness(inObj.value(KEY_THICKNESS).toInt());

    return result;
}
