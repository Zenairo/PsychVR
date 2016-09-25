#ifndef MAINWINDOW_H
#define MAINWINDOW_H
#define NUM_MAPS 3

#include <QMainWindow>
#include <cunitymap.h>
#include <cunityobject.h>
#include "editdialog.h"
namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT
public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();
   enum scene_idx_t {FEAR_OF_HEIGHTS,SPEECH_ANXIETY,TERRAIN_GENERATION};
public slots:
    void saveFiles();
    void loadFiles();
    void editModel();
    void saveModel();
    void newModel();
    void launchScene();

private:
    Ui::MainWindow *ui;
    CUnityMap ** m_map_list;
    EditDialog * m_obj_settings;
    CUnityMap * getMap();


};

#endif // MAINWINDOW_H
