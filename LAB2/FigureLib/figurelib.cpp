#include "figurelib.h"

Figure::Figure()
{
    FigureExternalRepresentation = NULL;
}

QGraphicsItem *Figure::GetFigureExternalRepresentation() const
{
    return FigureExternalRepresentation;
}

void Figure::SetFigureExternalRepresentation(QGraphicsItem *FigureExternalRepresentationToSet)
{
    FigureExternalRepresentation = FigureExternalRepresentationToSet;
}

QPoint Figure::GetFigureCenterPoint() const
{
    return FigureCenterPoint;
}

void Figure::SetFigureCenterPoint(QPoint FigureCenterPointToSet)
{
    FigureCenterPoint = FigureCenterPointToSet;
}

void Figure::Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor colorPen, QColor colorBrush, int thickness)
{

}

void Figure::Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene)
{

}

void Figure::Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene)
{

}

QJsonObject Figure::SerializeFigure(){

}

Figure* Figure::DeSerializeFigure(QJsonObject inObj){

}

Figure* Figure::CopyItem(){

}

const QColor &Figure::GetBrushColor() const{
    return BrushColor;
}

void Figure::SetBrushColor(const QColor &NewBrushColor){
    BrushColor = NewBrushColor;
}

int Figure::GetChosedThickness() const{
    return ChosedThickness;
}

void Figure::SetChosedThickness(int NewThickness){
    ChosedThickness = NewThickness;
}

const QColor &Figure::GetPenColor() const{
    return PenColor;
}

void Figure::SetPenColor(const QColor &NewPenColor){
    PenColor = NewPenColor;
}

const QRectF &Figure::GetBoundingRect() const{
    return BoundingRect;
}

void Figure::SetBoundingRect(const QRectF &NewBoundingRect){
    BoundingRect = NewBoundingRect;
}

Figure *Figure::CreateFigure(){

}

QString Figure::GetFigureClassName(){

}

