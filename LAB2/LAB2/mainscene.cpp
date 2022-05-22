#include "mainscene.h"

MainScene::MainScene(QObject *parent) : QGraphicsScene(parent)
{
    ChosedTool = Initial;
    ChosedFigure = NULL;
}

MainScene::~MainScene()
{

}

void MainScene::mousePressEvent(QGraphicsSceneMouseEvent *event)
{
    QMessageLogger().debug() << "MOUSE DOWN";
    QPoint point;
    point.setX(0);

    switch(ChosedTool)
    {

    case(Initial):{ // nothing to do here
        break;
    }

    case(Move):{ // moving figure
        QPointF PointToFind;
        PointToFind.setX(event->scenePos().x());
        PointToFind.setY(event->scenePos().y());
        QList<QGraphicsItem *> FiguresList = items(PointToFind); // getting all figures, wich on this point

        if(!FiguresList.isEmpty()){
            int centerPoint = 0;

            for(int i = 0; i < items().length(); i++){
                centerPoint = ListOfCenters.at(i).x();

                if(items().at(i) == FiguresList.at(0) && items().at(i) -> isVisible() && centerPoint != 0){ // FiguresList(0) because we need only upper figure
                    /*ChosedFigure = new Figure();
                    ChosedFigure -> SetFigureExternalRepresentation(items().at(i));
                    ChosedFigure -> SetFigureCenterPoint(ListOfCenters.at(i));
                    ChosedFigure -> GetFigureExternalRepresentation() -> setPos(event -> scenePos().x() - ChosedFigure -> GetFigureCenterPoint().x(),
                                                                                event -> scenePos().y() - ChosedFigure -> GetFigureCenterPoint().y());*/
                    // break;
                    ChosedFigure = ListOfFigures.at(i);
                }
                update();
            }
            if(centerPoint == 0){
                ChosedFigure = NULL;
            }
        }
        break;
    }

    case(Draw):{ // simple drawing
        Brush.Press(event, this, ChosedPenColor, ChosedThickness);
        ListOfCenters.push_front(point);
        break;
    }

    case(Fill):{ // floodfill
        QPointF PointToFind;
        PointToFind.setX(event->scenePos().x());
        PointToFind.setY(event->scenePos().y());
        QList<QGraphicsItem *> FiguresList = items(PointToFind); // getting all figures, wich on this point

        if(!FiguresList.isEmpty()){
            for(int i = 0; i < items().length(); i++){
                if(items().at(i) == FiguresList.at(0) && items().at(i) -> isVisible() && ListOfCenters.at(i).x() != 0){
                    FloodFill.Fill(items().at(i), ChosedBrushColor);
                    break;
                }
                update();
            }
        }
        break;
    }

    case(DrawFigure):{
        QMessageLogger().debug() << "CASE DRAW FIGURE IN MOUSE DOWN EVENT IN SCENE";

        ChosedFigure -> Press(event, this, ChosedPenColor, ChosedBrushColor, ChosedThickness);
        update();
        break;
    }
    case(Copy):{
        CopyItem(event);
        break;
    }
    case(Paste):{

        ListOfFigures.push_front(loadedFigure);
        loadedFigure -> GetFigureExternalRepresentation()->setPos(event->scenePos().x() - loadedFigure->GetFigureCenterPoint().x(),
                                                                  event->scenePos().y() - loadedFigure->GetFigureCenterPoint().y());

        ListOfCenters.push_front(loadedFigure -> GetFigureCenterPoint());
        this -> addItem(loadedFigure -> GetFigureExternalRepresentation());
        this -> update();
        ChosedFigure = loadedFigure;
        ChosedTool = Move;
        break;
    }

    }

}

void MainScene::mouseMoveEvent(QGraphicsSceneMouseEvent *event){
    QPoint point;

    switch(ChosedTool)
    {

    case(Initial):{ // nothing to do here
        break;
    }

    case(Move):{ // moving figure
        ChosedFigure -> GetFigureExternalRepresentation() -> setPos(event -> scenePos().x() - ChosedFigure -> GetFigureCenterPoint().x(),
                                                                    event -> scenePos().y() - ChosedFigure -> GetFigureCenterPoint().y());
        update();
        break;
    }

    case(Draw):{ // simple drawing
        Brush.Move(event, this, ChosedPenColor, ChosedThickness);
        ListOfCenters.push_front(point); // when painting dots adds to items(), but not adds to ListOfCenters
        break;
    }

    case(Fill):{ // floodfill
        break;
    }

    case(DrawFigure):{ // draw a figure
        QMessageLogger().debug() << "CASE DRAW FIGURE IN MOUSE MOVE EVENT IN SCENE";

        ChosedFigure -> Move(event, this);
        break;
    }

    }
}

void MainScene::mouseReleaseEvent(QGraphicsSceneMouseEvent *event){

    switch(ChosedTool)
    {

    case(Initial):{ // nothing to do here
        break;
    }

    case(Move):{ // moving figure
        break;
    }

    case(Draw):{ // simple drawing
        break;
    }

    case(Fill):{ // floodfill
        break;
    }

    case(DrawFigure):{ // draw a figure
        QMessageLogger().debug() << "CASE DRAW FIGURE IN MOUSE UP EVENT IN SCENE";

        ChosedFigure -> Release(event, this);
        ListOfCenters.push_front(ChosedFigure -> GetFigureCenterPoint());
        if(!ChosedFigure->IsContinuous){
            ChosedTool = Move;
        }
        update();
        break;
    }

    }
}


void MainScene::SetChosedThickness(int NewChosedThickness){
    ChosedThickness = NewChosedThickness;
}

void MainScene::SetChosedTool(Tools NewChosedTool){
    ChosedTool = NewChosedTool;
}

void MainScene::SetChosedPenColor(const QColor &NewChosedPenColor){
    ChosedPenColor = NewChosedPenColor;
}

void MainScene::SetChosedBrushColor(const QColor &NewChosedBrushColor){
    ChosedBrushColor = NewChosedBrushColor;
}

void MainScene::SetChosedFigure(Figure *NewChosedFigure){
    ListOfFigures.push_front(NewChosedFigure);
    ChosedFigure = NewChosedFigure;
    ChosedTool = DrawFigure;
}

void MainScene::Rotate(int RotateAngle){
    if(ChosedFigure != NULL && ChosedFigure -> GetFigureExternalRepresentation() != NULL){
        ChosedFigure -> GetFigureExternalRepresentation() -> setTransformOriginPoint(ChosedFigure -> GetFigureCenterPoint());
        ChosedFigure -> GetFigureExternalRepresentation() -> setRotation(ChosedFigure -> GetFigureExternalRepresentation() -> rotation() + RotateAngle);
        update();
    }
}

void MainScene::Scale (qreal ScaleValue){
    if(ChosedFigure != NULL && ChosedFigure -> GetFigureExternalRepresentation() != NULL){
        ChosedFigure -> GetFigureExternalRepresentation() -> setTransformOriginPoint(ChosedFigure -> GetFigureCenterPoint());
        qreal scale = ChosedFigure -> GetFigureExternalRepresentation() -> scale() + ScaleValue;
        ChosedFigure -> GetFigureExternalRepresentation() -> setScale(scale);
        update();
    }
}

void MainScene::Undo(){
    foreach(QGraphicsItem* item, items()){
        if(item -> isVisible()){
            item -> setVisible(false);
            if(ChosedFigure != NULL && !ChosedFigure -> GetFigureExternalRepresentation() -> isVisible()){
                ChosedFigure = NULL;
            }
            break;
        }
    }
}

void MainScene::Redo(){
    for(int i = items().length() - 1; i > -1; i--){
        if(!items().at(i)->isVisible()){
            items().at(i)->setVisible(true);
            break;
        }
    }
}

int MainScene::GetChosedThickness() const{
    return ChosedThickness;
}

void MainScene::DeleteItem(){
    if(ChosedFigure != NULL && ChosedFigure->GetFigureExternalRepresentation()->isVisible()){
        ChosedFigure->GetFigureExternalRepresentation()->setVisible(false);
    }
}

void MainScene::CopyItem(QGraphicsSceneMouseEvent *event){
    Figure* Figure = ChosedFigure->CopyItem();
    ListOfFigures.push_front(Figure);
    Figure->GetFigureExternalRepresentation()->setPos(event->scenePos().x() - ChosedFigure->GetFigureCenterPoint().x(),
                                                      event->scenePos().y() - ChosedFigure->GetFigureCenterPoint().y());
    ListOfCenters.push_front(Figure->GetFigureCenterPoint());
    this->addItem(Figure->GetFigureExternalRepresentation());
    this->update();
}

void MainScene::Dump(QString FilePath){
    serializer.dump(ChosedFigure, FilePath);
}

void MainScene::Load(QString FilePath){
    Figure* figure = serializer.load(FilePath);
    loadedFigure = figure;
    ChosedTool = Paste;
}
