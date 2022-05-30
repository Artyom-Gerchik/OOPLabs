#include "figureserializer.h"


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

Figure* FigureSerializer::load(QString filePath, FigureFactory* Factory){
    QFile inFile(filePath);

    if(!inFile.open(QIODevice::ReadOnly))
        return nullptr;

    QJsonDocument file = QJsonDocument().fromJson(inFile.readAll());
    QJsonObject jsonObj = file.object();

    QMessageLogger().debug() << "Deserializing:" + jsonObj.value("Type").toString();

    Figure* figure = Factory->CreateFigure(jsonObj.value("Type").toString());\
    if(figure != NULL){
        return figure -> DeSerializeFigure(jsonObj);
    }
    return 0;

}
