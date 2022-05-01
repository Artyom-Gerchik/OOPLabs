#ifndef FLOODFILL_H
#define FLOODFILL_H

#include <QColor>
#include <QGraphicsItem>
#include <QGraphicsEffect>

class FloodFill
{

private:
    QColor ChosedColor;

public:
    FloodFill();

    void SetChosedColor(const QColor &ChosedColorToSet);
    void Fill(QGraphicsItem* ItemToFill, QColor FloodFillColor);
};

#endif // FLOODFILL_H
