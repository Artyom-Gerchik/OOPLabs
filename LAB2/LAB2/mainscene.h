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
#include "toolsenum.h"
#include "figureserializer.h"

class MainScene : public QGraphicsScene
{

private:


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
    FigureSerializer serializer;
    /* TOOLS */

    Figure* ChosedFigure;
    QVector<QPoint> ListOfCenters;
    QVector<Figure*> ListOfFigures;

    Figure* loadedFigure;

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

    void DeleteItem();
    void CopyItem(QGraphicsSceneMouseEvent *event);
    void Dump(QString filePath);
    void Load(QString filePath);


};

#endif // MAINSCENE_H
