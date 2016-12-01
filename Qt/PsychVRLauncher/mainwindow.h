#ifndef MAINWINDOW_H
#define MAINWINDOW_H
#define NUM_MAPS 3

#include <QMainWindow>
#include <cunitymap.h>
#include <cunityobject.h>
#include "editdialog.h"
#include "settings.h"

#include <QSlider>
#include <QButtonGroup>
#include <QFile>
#include <QJsonDocument>
#include <QJsonObject>
#include <QSignalMapper>
#include <QJsonValue>
#include <QByteArray>
#include <QJsonArray>

#include <QColor>
#include <QColorDialog>
#include <qcustomplot.h>




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
    void SaveData();
    void changeUser(int userName);
    void initButtons();
    void readIn();
    void showSettings();
    void tabChanged(int tab);
    void axisRangeChanged( const QCPRange &newRange, const QCPRange &oldRange);
    void axisRangeChanged2( const QCPRange &newRange, const QCPRange &oldRange);
    void axisRangeChanged3( const QCPRange &newRange, const QCPRange &oldRange);
    QString createRun();
    QJsonArray makeJson();
    void changeSettings();
    void changeColor();
    void changeFile();
    void changeSong();
    void switchTabs(int index);
    void switchScene(int index);

private:
    Ui::MainWindow *ui;
    CUnityMap ** m_map_list;
    EditDialog * m_obj_settings;
    CUnityMap * getMap();
    std::vector <QButtonGroup*> radioQs;
    settings * m_settings;
    QColorDialog setSkin;
    QColor curCol;
    QString powerpoint;
    QString song;
};

#endif // MAINWINDOW_H
