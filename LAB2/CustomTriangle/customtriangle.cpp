#include "customtriangle.h"
#include <QGraphicsPolygonItem>
#include <QPolygonF>

#define KEY_TYPE "Type"
#define KEY_POLYGON_X "Polygon_Point_X_"
#define KEY_POLYGON_Y "Polygon_Point_Y_"
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

extern "C" CUSTOMTRIANGLE_EXPORT Figure* extractFromLibrary()
{
    return new CustomTriangle();
}

CustomTriangle::CustomTriangle()
{
    IsContinuous = false;
    customTriangle = new QGraphicsPolygonItem();
}

Figure *CustomTriangle::CreateFigure()
{
    return new CustomTriangle();
}

QString CustomTriangle::GetFigureClassName()
{
    return typeid (this).name();
}

void CustomTriangle::Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor colorPen, QColor colorBrush, int thickness)
{
    SetBrushColor(colorBrush);
    SetPenColor(colorPen);
    SetChosedThickness(thickness);

    chosedPenColor = colorPen;
    chosedBrushColor = colorBrush;
    chosedThickness = thickness;

    QPolygonF polig = customTriangle->polygon();
    SetFigureExternalRepresentation(customTriangle);
    polig << QPointF(event->scenePos()) << QPointF(event->scenePos()) << QPointF(event->scenePos());
    customTriangle->setFillRule(Qt::WindingFill);
    customTriangle->setPolygon(polig);

    QPen pen;
    pen.setWidth(chosedThickness);
    pen.setColor(chosedPenColor);
    customTriangle->setPen(pen);
    customTriangle->setBrush(chosedBrushColor);

    customTriangle->update();
    scene->addItem(customTriangle);
    scene->update();

    X = event->scenePos().x();
    Y = event->scenePos().y();
}

void CustomTriangle::Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene)
{
    QPolygonF polig;
    polig << QPointF(X, event->scenePos().y()) << QPointF(event->scenePos().x(), Y/5) << QPointF(event->scenePos().y(), Y/3) << QPointF(event->scenePos().x(), X/6);

    customTriangle->setPolygon(polig);
    scene->update();
}

void CustomTriangle::Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene)
{
    QPoint point;
    point.setX(customTriangle->boundingRect().topLeft().x() + (customTriangle->boundingRect().bottomRight().x() - customTriangle->boundingRect().topLeft().x())/2);
    point.setY(customTriangle->boundingRect().topLeft().y() + (customTriangle->boundingRect().bottomRight().y() - customTriangle->boundingRect().topLeft().y())/2);
    SetFigureCenterPoint(point);
    SetBoundingRect(customTriangle->boundingRect());
    currentPolygon = customTriangle->polygon();
}

QJsonObject CustomTriangle::SerializeFigure()
{
    qreal rotate = GetFigureExternalRepresentation()->rotation();
    qreal scale = GetFigureExternalRepresentation()->scale();

    QJsonObject serializeObj;
    serializeObj.insert(KEY_TYPE, QJsonValue::fromVariant(GetFigureClassName()));

    int i = 0;
    foreach(QPointF point, currentPolygon)
    {
        serializeObj.insert(KEY_POLYGON_X + QString::number(i), QJsonValue::fromVariant(point.x()));
        serializeObj.insert(KEY_POLYGON_Y + QString::number(i), QJsonValue::fromVariant(point.y()));
        i++;
    }
    serializeObj.insert(KEY_TOPLEFT_X, QJsonValue::fromVariant(GetBoundingRect().topLeft().x()));
    serializeObj.insert(KEY_TOPLEFT_Y, QJsonValue::fromVariant(GetBoundingRect().topLeft().y()));
    serializeObj.insert(KEY_BOTRIGHT_X, QJsonValue::fromVariant(GetBoundingRect().bottomRight().x()));
    serializeObj.insert(KEY_BOTRIGHT_Y, QJsonValue::fromVariant(GetBoundingRect().bottomRight().y()));
    serializeObj.insert(KEY_CENTERPOINT_X, QJsonValue::fromVariant(GetFigureCenterPoint().x()));
    serializeObj.insert(KEY_CENTERPOINT_Y, QJsonValue::fromVariant(GetFigureCenterPoint().y()));
    serializeObj.insert(KEY_COLORBRUSH, QJsonValue::fromVariant(GetBrushColor()));
    serializeObj.insert(KEY_COLORPEN, QJsonValue::fromVariant(GetPenColor()));
    serializeObj.insert(KEY_THICKNESS, QJsonValue::fromVariant(GetChosedThickness()));
    serializeObj.insert(KEY_ROTATE, QJsonValue::fromVariant(rotate));
    serializeObj.insert(KEY_SCALE, QJsonValue::fromVariant(scale));

    return serializeObj;
}

Figure *CustomTriangle::DeSerializeFigure(QJsonObject inObj)
{
    CustomTriangle* result = new CustomTriangle();
    QGraphicsPolygonItem *newCustomTriangle = new QGraphicsPolygonItem();

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

    newCustomTriangle->setBrush(QColor(inObj.value(KEY_COLORBRUSH).toString()));
    newCustomTriangle->setPen(pen);
    newCustomTriangle->setScale(inObj.value(KEY_SCALE).toInt());
    newCustomTriangle->setRotation(inObj.value(KEY_ROTATE).toInt());
    newCustomTriangle->setTransformOriginPoint(QPoint(inObj.value(KEY_CENTERPOINT_X).toInt(), inObj.value(KEY_CENTERPOINT_Y).toInt()));
    newCustomTriangle->setFillRule(Qt::WindingFill);
    newCustomTriangle->setPolygon(polygon);

    result->SetBoundingRect(rect);
    result->SetFigureCenterPoint(QPoint(inObj.value(KEY_CENTERPOINT_X).toInt(), inObj.value(KEY_CENTERPOINT_Y).toInt()));
    result->SetBrushColor(QColor(inObj.value(KEY_COLORBRUSH).toString()));
    result->SetPenColor(inObj.value(KEY_COLORPEN).toString());
    result->SetFigureExternalRepresentation(newCustomTriangle);
    result->SetChosedThickness(inObj.value(KEY_THICKNESS).toInt());
    result->currentPolygon = polygon;

    return result;
}

Figure *CustomTriangle::CopyItem()
{
    CustomTriangle *result = new CustomTriangle();
    QGraphicsPolygonItem *newCustomTriangle = new QGraphicsPolygonItem();

    QPen pen;
    pen.setWidth(GetChosedThickness());
    pen.setColor(GetPenColor());

    newCustomTriangle->setBrush(GetBrushColor());
    newCustomTriangle->setPen(pen);
    newCustomTriangle->setScale(GetFigureExternalRepresentation()->scale());
    newCustomTriangle->setRotation((GetFigureExternalRepresentation()->rotation()));
    newCustomTriangle->setTransformOriginPoint(GetFigureCenterPoint());
    newCustomTriangle->setFillRule(Qt::WindingFill);
    newCustomTriangle->setPolygon(currentPolygon);

    result->SetBoundingRect(GetBoundingRect());
    result->SetFigureCenterPoint(GetFigureCenterPoint());
    result->SetBrushColor(GetBrushColor());
    result->SetPenColor(GetPenColor());
    result->SetFigureExternalRepresentation(newCustomTriangle);
    result->SetChosedThickness(GetChosedThickness());

    return result;
}
