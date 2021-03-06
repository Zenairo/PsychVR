﻿using UnityEngine;
using System.Collections;
using SimpleJSON;
using System;
using System.IO;

public class QtSceneSave : MonoBehaviour {
    // Use this for initialization
    private string json_text;
    public GameObject heights;
    public GameObject visionTracking;
    private int user_id = 1;
    public GameObject anxiety;
	void Start ()
    {
        
    }
    public void saveAnxiety()
    {
        user_id = this.gameObject.GetComponent<QtSceneLoad>().getUID();
        json_text = this.gameObject.GetComponent<QtSceneLoad>().getJSON();
        var data = JSON.Parse(json_text);
        Debug.Log(data[user_id]["Anxiety"]);
        int current_run = 0;
        foreach (JSONNode run in data[user_id]["Anxiety"]["runs"].AsArray)
        {
            Debug.Log(run);
            if(run["run"] != null)
                current_run = Int16.Parse(run["run"]) - 1;
        }
        Debug.Log("CURRENT RUN IS " + current_run);
        //OUTUTS FOR ANXIETY HERE
        data[user_id]["Anxiety"]["runs"][current_run].Add("time", new JSONData(Time.timeSinceLevelLoad));
        Debug.Log(data);

        var output_file = File.CreateText(this.gameObject.GetComponent<QtSceneLoad>().m_path);
        output_file.Write(data.ToString());
        output_file.Close();
    }
    public void saveSpeech()
    {
        user_id = this.gameObject.GetComponent<QtSceneLoad>().getUID() ;
        json_text = this.gameObject.GetComponent<QtSceneLoad>().getJSON();
        var data = JSON.Parse(json_text);
        Debug.Log(data[user_id]["Social"]);
        int current_run = 0;
        foreach (JSONNode run in data[user_id]["Social"]["runs"].AsArray)
        {
            Debug.Log(run);
            current_run = Int16.Parse(run["run"]) - 1;
        }
        Debug.Log("CURRENT RUN IS " + current_run);
        //OUTPUTS FOR SPEECH HERE
        data[user_id]["Social"]["runs"][current_run].Add("BoardTime", new JSONData(visionTracking.GetComponent<VisionTracker>().boardTime));
        data[user_id]["Social"]["runs"][current_run].Add("EyeTime", new JSONData(visionTracking.GetComponent<VisionTracker>().eyeContactTime));
        data[user_id]["Social"]["runs"][current_run].Add("FloorTime", new JSONData(visionTracking.GetComponent<VisionTracker>().floorTime));
        data[user_id]["Social"]["runs"][current_run].Add("time", new JSONData(Time.timeSinceLevelLoad));
        Debug.Log(data);

        var output_file = File.CreateText(this.gameObject.GetComponent<QtSceneLoad>().m_path);
        output_file.Write(data.ToString());
        output_file.Close();
        Debug.Log("quit!!");
        Application.Quit();
        
    }
    public void SaveHeights(float max_height)
    {
        user_id = this.gameObject.GetComponent<QtSceneLoad>().getUID();
        json_text = this.gameObject.GetComponent<QtSceneLoad>().getJSON();
        var data = JSON.Parse(json_text);
        Debug.Log(data[user_id]["Heights"]);
        int current_run = 0;
        float building_height = 0;
        float[] hardCodeHeights = { 12.708f,17.62f,24.682f,30.82f}; 
        building_height = hardCodeHeights[UnityEngine.PlayerPrefs.GetInt("BuildingNum")];
        foreach (JSONNode run in data[user_id]["Heights"]["runs"].AsArray)
        {
            Debug.Log(run);
            current_run = Int16.Parse(run["run"]) - 1;
        }
        Debug.Log("CURRENT RUN IS " + current_run);
        //OUTPUTS FOR HEIGHTS HERE
        data[user_id]["Heights"]["runs"][current_run].Add("maxHeight", new JSONData(building_height));
        data[user_id]["Heights"]["runs"][current_run].Add("height", new JSONData(max_height));
        data[user_id]["Heights"]["runs"][current_run].Add("time", new JSONData(Time.timeSinceLevelLoad));
        Debug.Log(data);

        var output_file = File.CreateText(this.gameObject.GetComponent<QtSceneLoad>().m_path);
        output_file.Write(data.ToString());
        output_file.Close();
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
