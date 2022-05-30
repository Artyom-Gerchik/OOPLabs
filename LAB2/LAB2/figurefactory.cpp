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


    if(FiguresMap.contains(FigureName)){
        if(FiguresMap.find(FigureName).value() != NULL){
            QMessageLogger().debug() << "FigureName" << FigureName;
            QMessageLogger().debug() << "FiguresMap.find(FigureName).value()" << FiguresMap.find(FigureName).value();
            return FiguresMap.find(FigureName).value()->CreateFigure();
        }
    }
    return 0;
}
