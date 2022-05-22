#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include "formainwindow.h"

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

    QMenu *figuresMenu;
    QMenu *toolsMenu;

    QAction *figures_draw_rectangle_act;
    QAction *figures_draw_ellipse_act;
    QAction *figures_draw_polygon_act;
    QAction *figures_draw_line_act;
    QAction *figures_draw_broken_act;
    QAction *figures_draw_freestyle_act;

    QAction *tools_move_act;
    QAction *tools_choose_pen_color_act;
    QAction *tools_choose_floodfill_color_act;
    QAction *tools_undo_act;
    QAction *tools_redo_act;
    QAction *tools_scale_up_act;
    QAction *tools_scale_down_act;
    QAction *tools_rotate_right_act;
    QAction *tools_rotate_left_act;
    QAction *tools_copy_act;
    QAction *tools_paste_act;
    QAction *tools_delete_act;
    QAction *tools_serialize_act;

private slots:
    void slotTimer();

    void figures_draw_rectangle();
    void figures_draw_ellipse();
    void figures_draw_polygon();
    void figures_draw_line();
    void figures_draw_broken();
    void figures_draw_freestyle();

    void tools_move();
    void tools_choose_pen_color();
    void tools_choose_floodfill_color();
    void tools_undo();
    void tools_redo();
    void tools_scale_up();
    void tools_scale_down();
    void tools_rotate_right();
    void tools_rotate_left();
    void tools_copy();
    void tools_paste();
    void tools_delete();
    void tools_serialize();

    void on_penWidthBox_valueChanged(int arg1);
};
#endif // MAINWINDOW_H
