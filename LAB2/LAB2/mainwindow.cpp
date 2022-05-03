#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent): QMainWindow(parent), ui(new Ui::MainWindow){
    ui->setupUi(this);

    colorDialog = new QColorDialog();
    penColor = Qt::green;
    brushColor = Qt::transparent;
    rotateAngle = 0;
    thickness = 1;

    mainScene = new MainScene();
    mainScene -> SetChosedPenColor(penColor);
    mainScene -> SetChosedBrushColor(brushColor);
    mainScene -> SetChosedThickness(thickness);
    ui -> graphicsView -> setScene(mainScene);

    timer = new QTimer();
    connect(timer, &QTimer::timeout, this, &::MainWindow::slotTimer);
    timer -> start(100);

    this->setFixedSize(QSize(800, 500));
}

MainWindow::~MainWindow(){
    delete ui;
}

void MainWindow::Scale(QResizeEvent * event){
    timer -> start(100);
    QWidget::resizeEvent(event);
}

void MainWindow::Error(QString message){
    QMessageBox messageBox = QMessageBox();
    messageBox.setWindowTitle("Error");
    messageBox.setText(message);
    messageBox.addButton("OK", messageBox.AcceptRole);
    messageBox.exec();
}

void MainWindow::slotTimer(){
    timer -> stop();
    mainScene -> setSceneRect(0, 0, ui -> graphicsView -> width() - 20, ui -> graphicsView -> height() - 20);
}

void MainWindow::on_RectangleButton_clicked(){
    Rectangle* rectangle = new Rectangle();
    mainScene -> SetChosedFigure(rectangle);
    QMessageLogger().debug() << "RECTANGLE SELECTED IN MAIN WINDOW";
}

void MainWindow::on_CircleButton_clicked()
{

}

