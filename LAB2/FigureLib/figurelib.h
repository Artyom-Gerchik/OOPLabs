#ifndef FIGURE_H
#define FIGURE_H

#include "FigureLib_global.h"
#include <QGraphicsScene>
#include <QGraphicsItem>
#include <QGraphicsSceneMouseEvent>
#include <QDataStream>
#include <QJsonObject>

class FIGURELIB_EXPORT Figure
{
private:

    QGraphicsItem* FigureExternalRepresentation;
    QPoint FigureCenterPoint;
    QColor PenColor;
    QColor BrushColor;
    QRectF BoundingRect;
    int ChosedThickness;

public:
    bool IsContinuous;
    bool Start;

    Figure();

    QGraphicsItem *GetFigureExternalRepresentation() const;
    void SetFigureExternalRepresentation(QGraphicsItem *FigureExternalRepresentationToSet);

    QPoint GetFigureCenterPoint() const;
    void SetFigureCenterPoint(QPoint FigureCenterPointToSet);

    virtual void Press(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene, QColor colorPen, QColor colorBrush, int thickness);
    virtual void Move(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene);
    virtual void Release(QGraphicsSceneMouseEvent *event, QGraphicsScene *scene);

    virtual Figure* CopyItem();
    virtual QJsonObject SerializeFigure();
    virtual Figure* DeSerializeFigure(QJsonObject inObj);

    const QColor &GetBrushColor() const;
    void SetBrushColor(const QColor &NewBrushColor);

    int GetChosedThickness() const;
    void SetChosedThickness(int NewThickness);

    const QColor &GetPenColor() const;
    void SetPenColor(const QColor &NewPenColor);

    const QRectF &GetBoundingRect() const;
    void SetBoundingRect(const QRectF &NewBoundingRect);

};

#endif // FIGURE_H
