#include "figurefactory.h"
//#include "broken.h"

FigureFactory::FigureFactory()
{
    RegistrateNewFigure(new Ellipse());
    RegistrateNewFigure(new Line());
    RegistrateNewFigure(new Polygon());
    RegistrateNewFigure(new Rectangle());
}

void FigureFactory::RegistrateNewFigure(Figure *figure)
{
    const QString FigureName = figure->GetFigureClassName();
    FiguresMap.insert(FigureName, figure->CreateFigure());
}

Figure *FigureFactory::CreateFigure(QString FigureName){

    if(FiguresMap.find(FigureName).value() != NULL){
        return FiguresMap.find(FigureName).value()->CreateFigure();
    }

}


