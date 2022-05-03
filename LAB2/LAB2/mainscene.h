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
#include "floodfill.h"

class MainScene : public QGraphicsScene
{

private:

    enum Tools
    {
        Initial,
        Move,
        Draw,
        Fill,
        DrawFigure
    };

    /*VARS*/
    int ChosedThickness;
    Tools ChosedTool;
    /*VARS*/

    /*COLOR*/
    QColor ChosedPenColor;
    QColor ChosedBrushColor;
    /*COLOR*/

    /* TOOLS */
    Brush Brush;
    FloodFill FloodFill;
    /* TOOLS */

    Figure* ChosedFigure;
    QVector<QPoint> ListOfCenters;

    void mousePressEvent(QGraphicsSceneMouseEvent *event);
    void mouseMoveEvent(QGraphicsSceneMouseEvent *event);
    void mouseReleaseEvent(QGraphicsSceneMouseEvent *event);

public:
    MainScene(QObject *parent = 0);
    ~MainScene();

    void SetChosedThickness(int NewChosedThickness);
    void SetChosedTool(Tools NewChosedTool);
    void SetChosedPenColor(const QColor &NewChosedPenColor);
    void SetChosedBrushColor(const QColor &NewChosedBrushColor);
    void SetChosedFigure(Figure *NewChosedFigure);
    void Rotate(int RotateAngle);
    void Scale (qreal ScaleValue);
    void Undo();
    void Redo();
    int GetChosedThickness() const;

};

#endif // MAINSCENE_H
