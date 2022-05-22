#include "figureserializer.h"

#define KEY_CENTERPOINT "CenterPoint"
#define KEY_EXTERNALIMAGEOFFIGURE "ExternalImageOfFigure"

FigureSerializer::FigureSerializer()
{

}

bool FigureSerializer::dump(Figure* figure, QString filePath){
    QFile outFile(filePath);

    if(!outFile.open(QIODevice::WriteOnly))
        return false;

    QJsonObject serialized = figure->SerializeFigure();
    if(serialized.isEmpty())
        return false;
    QJsonDocument document = QJsonDocument(serialized);


    outFile.write(document.toJson());
    outFile.flush();
    outFile.close();

    return true;
}

Figure* FigureSerializer::load(QString filePath){
    QFile inFile(filePath);

    if(!inFile.open(QIODevice::ReadOnly))
        return nullptr;

    QJsonDocument document = QJsonDocument().fromJson(inFile.readAll());
    QJsonObject jsonObj = document.object();
    Rectangle* rect = new Rectangle();
    return rect -> DeSerializeFigure(jsonObj);


}
