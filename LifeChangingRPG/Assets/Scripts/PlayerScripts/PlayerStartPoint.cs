using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    private player_movement thePlayer;
    private camera_control theCamera;

    public Vector2 StartDirection;

    public string PointName;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<player_movement>();
        if (thePlayer.StartPoint == PointName)
        {
            thePlayer.transform.position = transform.position;
            StartDirection = new Vector2(0f, -1f);
            thePlayer.lastMove = StartDirection;
            theCamera = FindObjectOfType<camera_control>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
