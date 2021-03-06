﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
 
	// this is an object, so that you can move it around in the editor.
	public Transform bottom;
	public Transform top;
	public Transform gondola;
	public Text height;
	public float highestPoint = 0f;
    public GameObject settings;
    private float base_wind = 0.2f;
    private float scale_wind = 0;
    private float base_ground = 0.2f;
    private float scale_ground = 1; 


    int direction = 0;

	// units per second
	int speed = 1;
 
    void Update(){
        // remember, 10 - 5 is 5, so target - position is always your direction.
		Vector3 dir = gondola.position;
		if (direction == 1)
			dir = top.position - gondola.position;
		else if (direction == -1)
			dir = bottom.position - gondola.position;
		else
			dir = new Vector3( 0, 0, 0);

        // magnitude is the total length of a vector.
        // getting the magnitude of the direction gives us the amount left to move
        float dist = dir.magnitude;
       
        // this makes the length of dir 1 so that you can multiply by it.
        dir = dir.normalized;
       
        // the amount we can move this frame
        float move = speed * Time.deltaTime;
       
        // limit our move to what we can travel.
        if(move > dist) move = dist;
       
        // apply the movement to the object.
        gondola.Translate( dir * move);

        //this.direction = 0;

		height.text = (1.8f*gondola.transform.position.y).ToString("F2") + " Meters";
        scale_ground = 1f - gondola.position.y / top.position.y;
        scale_wind = gondola.position.y / top.position.y;
    }

    public float getWind()
    {
        //Debug.Log("wind "+ scale_wind +" " + base_wind);
        return scale_wind* base_wind;
        
    }
    public float getGround()
    {
        //Debug.Log("ground " + scale_ground + " " + base_ground);
        return scale_ground * base_ground;
    }
	public void UpPressed()
	{
		this.direction = 1;
	}

	public void DownPressed()
	{
		this.direction = -1;
	}

	public void Depressed()
	{
		this.direction = 0;
        if (highestPoint < gondola.transform.position.y)
        {
            highestPoint = gondola.transform.position.y;
        }
    }

	public void Up()
	{
		if (this.direction == 1)
			this.direction = 0;
		else
			this.direction = 1;

		if(highestPoint < gondola.transform.position.y)
		{
			highestPoint = gondola.transform.position.y;
		}
	}

	public void Down()
	{
		if (this.direction == -1)
			this.direction = 0;
		else
			this.direction = -1;
	}

	public void Exit()
	{
        Debug.Log("Quitting Scene...");
        settings.GetComponent<QtSceneSave>().SaveHeights(highestPoint);
        Application.Quit();

	}
}
