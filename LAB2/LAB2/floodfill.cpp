#include "floodfill.h"

FloodFill::FloodFill()
{

}

void FloodFill::SetChosedColor(const QColor &ChosedColorToSet)
{
    ChosedColor = ChosedColorToSet;
}

void FloodFill::Fill(QGraphicsItem* ItemToFill, QColor FloodFillColor)
{

    QGraphicsColorizeEffect* effect = new QGraphicsColorizeEffect;

    effect -> setColor(FloodFillColor);
    ItemToFill -> setGraphicsEffect(effect);
    ItemToFill -> update();

}
