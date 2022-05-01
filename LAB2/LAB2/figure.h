#ifndef FIGURE_H
#define FIGURE_H

#include <QGraphicsScene>
#include <QGraphicsItem>
#include <QGraphicsSceneMouseEvent>

class Figure
{
private:

    QGraphicsItem* FigureExternalRepresentation;
    QPoint FigureCenterPoint;

public:

    Figure();

    QGraphicsItem *GetFigureExternalRepresentation() const;
    void SetFigureExternalRepresentation(QGraphicsItem *FigureExternalRepresentationToSet);

    QPoint GetFigureCenterPoint() const;
    void SetFigureCenterPoint(QPoint FigureCenterPointToSet);

    virtual void Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor colorPen, QColor colorBrush, int thickness);
    virtual void Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene);
    virtual void Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene);

};

#endif // FIGURE_H
