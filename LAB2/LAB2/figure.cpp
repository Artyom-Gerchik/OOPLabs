#include "figure.h"

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
