#include "figurefactory.h"

FigureFactory::FigureFactory()
{

}

Figure *FigureFactory::CreateFigure(QString FigureName){
    if(FigureName == "Ellipse")
        return new Ellipse();
    if(FigureName == "Line")
        return new Line();
    if(FigureName == "Polygon")
        return new Polygon();
    if(FigureName == "Rectangle")
        return new Rectangle();
}

