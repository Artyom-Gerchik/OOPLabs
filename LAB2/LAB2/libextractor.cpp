#include "libextractor.h"

LibExtractor::LibExtractor()
{

}

void LibExtractor::UpdateImportedLibs(QStringList *ImportedFigures, FigureFactory* Factory){

    QDir Directory;
    Directory = Directory.absolutePath() + "/Plugins";
    QStringList LibrariesDirectory = Directory.entryList();

    if(!LibrariesDirectory.isEmpty()){

        LibrariesDirectory.pop_front();
        LibrariesDirectory.pop_front();

        foreach(QString LibraryPath, LibrariesDirectory){

            QLibrary Library(Directory.absoluteFilePath(LibraryPath));

            if(Library.load()){

                typedef Figure* (*ExtractFunction)();
                ExtractFunction ExtractFromLibrary = (ExtractFunction) Library.resolve("extractFromLibrary");

                if(ExtractFromLibrary){
                    Figure* ExtFigure = ExtractFromLibrary();
                    Factory->RegistrateNewFigure(ExtFigure);
                    ImportedFigures->push_back(ExtFigure->GetFigureClassName());
                }
            }
        }
    }
}
