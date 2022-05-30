#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "toolsenum.h"
#include <QMainWindow>
#include <QtWidgets>

QString ellipse = typeid (new Ellipse()).name();
QString rectangle = typeid (new Rectangle()).name();
QString line = typeid (new Line()).name();
QString broken = typeid (new Broken()).name();
QString polygon = typeid (new Polygon()).name();


MainWindow::MainWindow(QWidget *parent): QMainWindow(parent), ui(new Ui::MainWindow){
    ui->setupUi(this);

    ui -> textEdit -> setHorizontalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui -> textEdit -> setVerticalScrollBarPolicy(Qt::ScrollBarAlwaysOff);

    // FIGURES
    figures_draw_rectangle_act = new QAction(tr("&Rectangle"), this);
    figures_draw_rectangle_act -> setShortcut(QKeySequence(tr("Ctrl+R")));

    figures_draw_ellipse_act = new QAction(tr("&Ellipse"), this);
    figures_draw_ellipse_act -> setShortcut(QKeySequence(tr("Ctrl+E")));

    figures_draw_polygon_act = new QAction(tr("&Polygon"), this);
    figures_draw_polygon_act -> setShortcut(QKeySequence(tr("Ctrl+P")));

    figures_draw_line_act = new QAction(tr("&Line"), this);
    figures_draw_line_act -> setShortcut(QKeySequence(tr("Ctrl+L")));

    figures_draw_broken_act = new QAction(tr("&Broken"), this);
    figures_draw_broken_act -> setShortcut(QKeySequence(tr("Ctrl+B")));

    figures_draw_freestyle_act = new QAction(tr("&FreeStyle"), this);
    figures_draw_freestyle_act -> setShortcut(QKeySequence(tr("Ctrl+F")));

    connect(figures_draw_rectangle_act, SIGNAL(triggered()), this, SLOT(figures_draw_rectangle()));
    connect(figures_draw_ellipse_act, SIGNAL(triggered()), this, SLOT(figures_draw_ellipse()));
    connect(figures_draw_polygon_act, SIGNAL(triggered()), this, SLOT(figures_draw_polygon()));
    connect(figures_draw_line_act, SIGNAL(triggered()), this, SLOT(figures_draw_line()));
    connect(figures_draw_broken_act, SIGNAL(triggered()), this, SLOT(figures_draw_broken()));
    connect(figures_draw_freestyle_act, SIGNAL(triggered()), this, SLOT(figures_draw_freestyle()));

    figuresMenu = new QMenu(tr("&Figures"), this);
    figuresMenu -> addAction(figures_draw_rectangle_act);
    figuresMenu -> addAction(figures_draw_ellipse_act);
    figuresMenu -> addAction(figures_draw_polygon_act);
    figuresMenu -> addAction(figures_draw_line_act);
    figuresMenu -> addAction(figures_draw_broken_act);
    figuresMenu -> addAction(figures_draw_freestyle_act);
    // FIGURES

    // TOOLS
    tools_move_act = new QAction(tr("&Move"), this);
    tools_move_act -> setShortcut(QKeySequence(tr("Ctrl+M")));

    tools_choose_pen_color_act = new QAction(tr("&Pen Color"), this);
    tools_choose_pen_color_act -> setShortcut(QKeySequence(tr("Ctrl+Shift+P")));

    tools_choose_floodfill_color_act = new QAction(tr("&Flood Fill"), this);
    tools_choose_floodfill_color_act -> setShortcut(QKeySequence(tr("Ctrl+Shift+F")));

    tools_undo_act = new QAction(tr("&Undo"), this);
    tools_undo_act -> setShortcut(QKeySequence(tr("Ctrl+Z")));

    tools_redo_act = new QAction(tr("&Redo"), this);
    tools_redo_act -> setShortcut(QKeySequence(tr("Ctrl+Shift+Z")));

    tools_scale_up_act = new QAction(tr("&Scale Up"), this);
    tools_scale_up_act -> setShortcut(QKeySequence(tr("Ctrl++")));

    tools_scale_down_act = new QAction(tr("&Scale Down"), this);
    tools_scale_down_act -> setShortcut(QKeySequence(tr("Ctrl+-")));

    tools_rotate_right_act = new QAction(tr("&Rotate Right"), this);
    tools_rotate_right_act -> setShortcut(QKeySequence(tr("Ctrl+]")));

    tools_rotate_left_act = new QAction(tr("&Rotate Left"), this);
    tools_rotate_left_act -> setShortcut(QKeySequence(tr("Ctrl+[")));

    tools_copy_act = new QAction(tr("&Copy"), this);
    tools_copy_act -> setShortcut(QKeySequence(tr("Ctrl+C")));

    tools_paste_act = new QAction(tr("&Paste"), this);
    tools_paste_act -> setShortcut(QKeySequence(tr("Ctrl+V")));

    tools_delete_act = new QAction(tr("&Delete"), this);
    tools_delete_act -> setShortcut(QKeySequence(tr("Ctrl+Shift+X")));

    tools_serialize_act = new QAction(tr("&Serialize"), this);
    tools_serialize_act -> setShortcut(QKeySequence(tr("Ctrl+Shift+S")));

    tools_de_serialize_act = new QAction(tr("&DeSerialize"), this);
    tools_de_serialize_act -> setShortcut(QKeySequence(tr("Ctrl+Shift+D")));



    connect(tools_move_act, SIGNAL(triggered()), this, SLOT(tools_move()));
    connect(tools_choose_pen_color_act, SIGNAL(triggered()), this, SLOT(tools_choose_pen_color()));
    connect(tools_choose_floodfill_color_act, SIGNAL(triggered()), this, SLOT(tools_choose_floodfill_color()));
    connect(tools_undo_act, SIGNAL(triggered()), this, SLOT(tools_undo()));
    connect(tools_redo_act, SIGNAL(triggered()), this, SLOT(tools_redo()));
    connect(tools_scale_up_act, SIGNAL(triggered()), this, SLOT(tools_scale_up()));
    connect(tools_scale_down_act, SIGNAL(triggered()), this, SLOT(tools_scale_down()));
    connect(tools_rotate_right_act, SIGNAL(triggered()), this, SLOT(tools_rotate_right()));
    connect(tools_rotate_left_act, SIGNAL(triggered()), this, SLOT(tools_rotate_left()));
    connect(tools_copy_act, SIGNAL(triggered()), this, SLOT(tools_copy()));
    connect(tools_paste_act, SIGNAL(triggered()), this, SLOT(tools_paste()));
    connect(tools_delete_act, SIGNAL(triggered()), this, SLOT(tools_delete()));
    connect(tools_serialize_act, SIGNAL(triggered()), this, SLOT(tools_serialize()));
    connect(tools_de_serialize_act, SIGNAL(triggered()), this, SLOT(tools_de_serialize()));


    toolsMenu = new QMenu(tr("&Tools"),this);
    toolsMenu -> addAction(tools_move_act);
    toolsMenu -> addAction(tools_choose_pen_color_act);
    toolsMenu -> addAction(tools_choose_floodfill_color_act);
    toolsMenu -> addAction(tools_undo_act);
    toolsMenu -> addAction(tools_redo_act);
    toolsMenu -> addAction(tools_scale_up_act);
    toolsMenu -> addAction(tools_scale_down_act);
    toolsMenu -> addAction(tools_rotate_right_act);
    toolsMenu -> addAction(tools_rotate_left_act);
    toolsMenu -> addAction(tools_copy_act);
    toolsMenu -> addAction(tools_paste_act);
    toolsMenu -> addAction(tools_delete_act);
    toolsMenu -> addAction(tools_serialize_act);
    toolsMenu -> addAction(tools_de_serialize_act);
    // TOOLS

    menuBar() -> addMenu(figuresMenu);
    menuBar() -> addMenu(toolsMenu);

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

    updateFiguresTable();

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

void MainWindow::figures_draw_rectangle(){
    mainScene -> SetChosedFigure(rectangle);
    QMessageLogger().debug() << "rectangle SELECTED IN MAIN WINDOW";
}

void MainWindow::figures_draw_ellipse(){
    mainScene -> SetChosedFigure(ellipse);
    QMessageLogger().debug() << "ellipse SELECTED IN MAIN WINDOW";
}

void MainWindow::figures_draw_polygon(){
    mainScene -> SetChosedFigure(polygon);
    QMessageLogger().debug() << "polygon SELECTED IN MAIN WINDOW";
}

void MainWindow::figures_draw_line(){
    mainScene -> SetChosedFigure(line);
    QMessageLogger().debug() << "line SELECTED IN MAIN WINDOW";
}

void MainWindow::figures_draw_broken(){
    mainScene -> SetChosedFigure(broken);
    QMessageLogger().debug() << "broken SELECTED IN MAIN WINDOW";
}

void MainWindow::figures_draw_freestyle(){
    Tools tool = Draw;
    mainScene -> SetChosedTool(tool);
    QMessageLogger().debug() << "freestyle SELECTED IN MAIN WINDOW";
}

void MainWindow::tools_move(){
    Tools tool = Move;
    mainScene -> SetChosedTool(tool);
}

void MainWindow::tools_choose_pen_color(){
    penColor = colorDialog -> getColor(penColor, colorDialog);
    if(penColor.isValid()){
        QString hexRgb = QString("#%1").arg(QColor(brushColor).rgba(), 8, 16);
        QString hexInput = "border-radius: 1px; background-color: ";
        hexInput.append(hexRgb);
        mainScene -> SetChosedPenColor(penColor);
    }
}

void MainWindow::tools_choose_floodfill_color(){
    Tools tool = Fill;
    mainScene -> SetChosedTool(tool);

    brushColor = colorDialog -> getColor(brushColor, colorDialog);
    if(brushColor.isValid()){
        QString hexRgb = QString("#%1").arg(QColor(brushColor).rgba(), 8, 16);
        QString hexInput = "border-radius: 1px; background-color: ";
        hexInput.append(hexRgb);
        mainScene -> SetChosedBrushColor(brushColor);
    }
}

void MainWindow::tools_undo(){
    mainScene -> Undo();
}

void MainWindow::tools_redo(){
    mainScene -> Redo();
}

void MainWindow::tools_scale_up(){
    mainScene -> Scale(0.1);
}

void MainWindow::tools_scale_down(){
    mainScene -> Scale(-0.1);
}

void MainWindow::tools_rotate_right(){
    mainScene -> Rotate(1);
}

void MainWindow::tools_rotate_left(){
    mainScene -> Rotate(-1);
}

void MainWindow::tools_copy(){
    Tools tool = Copy;
    mainScene -> SetChosedTool(tool);
}

void MainWindow::tools_paste(){
    //    Tools tool = Paste;
    //    mainScene -> SetChosedTool(tool);
}

void MainWindow::tools_delete(){
    mainScene -> DeleteItem();
}

void MainWindow::tools_serialize(){
    QString filePath = QFileDialog::getSaveFileName(
                this,
                tr("Save File"),
                "Untitled",
                tr("JSON (*.json)" )
                );
    mainScene->Dump(filePath);
    mainScene->SetChosedTool(Initial);


}

void MainWindow::tools_de_serialize(){
    QString filePath = QFileDialog::getOpenFileName(
                this,
                tr("Open File"),
                "",
                tr("JSON (*.json)" )
                );
    mainScene->Load(filePath);
    if(mainScene->Load(filePath) == 0){
        QMessageBox msg = QMessageBox();
        msg.setWindowTitle("PIZDEC");
        msg.setIcon(msg.Critical);
        msg.setText("PIZDEC");
        msg.addButton("OK", msg.AcceptRole);
        msg.exec();
    }

    // mainScene->SetChosedTool(Initial);

}

void MainWindow::on_penWidthBox_valueChanged(int arg1)
{
    thickness = ui ->penWidthBox ->value();
    mainScene ->SetChosedThickness(thickness);
}

void MainWindow::updateFiguresTable(){
    ui->figureTable->setColumnCount(1);

    ui->figureTable->setRowCount(mainScene->ImportedFigures->count());
    ui->figureTable->setHorizontalHeaderLabels(QStringList()<< "Figure");

    for(int row = 0; row < mainScene->ImportedFigures->count(); row++)
    {
        QTableWidgetItem *index = new QTableWidgetItem(tr("%1").arg(mainScene->ImportedFigures->at(row)));
        ui->figureTable->setItem(row, 0, index);
        ui->figureTable->item(row, 0)->setFlags(Qt::ItemIsDragEnabled|Qt::ItemIsUserCheckable|Qt::ItemIsSelectable);

        //        QTableWidgetItem *BIK = new QTableWidgetItem(tr("%1").arg("Активна"));
        //        ui->CustomTable->setItem(row, 1, BIK);
        //        ui->CustomTable->item(row, 1)->setFlags(Qt::ItemIsDragEnabled|Qt::ItemIsUserCheckable|Qt::ItemIsSelectable);
    }
    ui->choseSpinBox->setMaximum(ui->figureTable->rowCount());

}

void MainWindow::on_choseButton_clicked(){
    int choose = ui->choseSpinBox->value();
    if(choose != 0){
        mainScene->SetChosedFigure(mainScene->ImportedFigures->at(choose - 1));
    }
}

