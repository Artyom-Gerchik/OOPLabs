#ifndef MAINSCENE_H
#define MAINSCENE_H

#include <QGraphicsScene>
#include <QGraphicsSceneMouseEvent>
#include <QGraphicsItem>
#include <QPainter>
#include <QTimer>
#include <QDebug>
#include <QCursor>

#include "figure.h"
#include "brush.h"
#include "floodfill.h""

class MainScene
{

private:

    /*VARS*/
    int ChosedThickness;
    int ChosedTool;
    /*VARS*/

    /*COLOR*/
    QColor ChosedPenColor;
    QColor ChosedBrushColor;
    /*COLOR*/

    /* TOOLS */
    Brush Brush;
    FloodFill FloodFill;
    /* TOOLS */

    void MouseDownEvent(QGraphicsSceneMouseEvent *event);
    void MouseMoveEvent(QGraphicsSceneMouseEvent *event);
    void MouseUpEvent(QGraphicsSceneMouseEvent *event);

public:
    MainScene();
    ~MainScene();

    void SetChosedThickness(int NewChosedThickness);
    void SetChosedTool(int NewChosedTool);
    void SetChosedPenColor(const QColor &NewChosedPenColor);
    void SetChosedBrushColor(const QColor &NewChosedBrushColor);
    void SetChosedFigure(Figure *NewChosedFigure);
    void Rotate(int Rotate);
    void Zoom (qreal Scale);
    void Undo();
    void Redo();
    int GetChosedThickness() const;

};

#endif // MAINSCENE_H
