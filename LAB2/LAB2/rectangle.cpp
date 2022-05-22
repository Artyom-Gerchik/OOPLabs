#include "rectangle.h"

#define KEY_BOUNDINGRECT "BoundingRect"
#define KEY_CENTERPOINT "CenterPoint"
#define KEY_COLORBRUSH "BrushColor"
#define KEY_COLORPEN "PenColor"
#define KEY_THICKNESS "ChosedThickness"
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

QJsonObject Rectangle::SerializeFigure(){
    qreal rotate = GetFigureExternalRepresentation()->rotation();
    qreal scale = GetFigureExternalRepresentation()->scale();

    QJsonObject serializedRect;
    serializedRect.insert(KEY_BOUNDINGRECT, QJsonValue::fromVariant(GetBoundingRect()));
    serializedRect.insert(KEY_CENTERPOINT, QJsonValue::fromVariant(GetFigureCenterPoint()));
    serializedRect.insert(KEY_COLORBRUSH, QJsonValue::fromVariant(GetBrushColor()));
    serializedRect.insert(KEY_COLORPEN, QJsonValue::fromVariant(GetPenColor()));
    serializedRect.insert(KEY_THICKNESS, QJsonValue::fromVariant(GetChosedThickness()));
    serializedRect.insert(KEY_ROTATE, QJsonValue::fromVariant(rotate));
    serializedRect.insert(KEY_SCALE, QJsonValue::fromVariant(scale));

    return serializedRect;
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

    copiedItem->SetBoundingRect(GetBoundingRect());
    copiedItem->SetFigureCenterPoint(GetFigureCenterPoint());
    copiedItem->SetBrushColor(GetBrushColor());
    copiedItem->SetPenColor(GetPenColor());
    copiedItem->SetFigureExternalRepresentation(newRectItem);
    copiedItem->SetChosedThickness(GetChosedThickness());

    return copiedItem;

}



