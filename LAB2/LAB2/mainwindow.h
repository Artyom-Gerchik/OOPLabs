#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QMessageBox>
#include <QWidget>
#include <QTimer>
#include <QResizeEvent>
#include <QColorDialog>
#include <QFileDialog>
#include <QGraphicsRectItem>

#include "mainscene.h"
#include "rectangle.h"


QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

private:
    Ui::MainWindow *ui;
    QTimer *timer;

    MainScene *mainScene;
    QColorDialog *colorDialog;
    QColor penColor;
    QColor brushColor;
    int rotateAngle;
    int thickness;

    void Scale(QResizeEvent * event);
    void Error(QString message);

private slots:
    void slotTimer();
    void on_RectangleButton_clicked();

};
#endif // MAINWINDOW_H
