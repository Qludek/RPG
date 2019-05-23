using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour {
    private BoxCollider2D bounds;
    private camera_control theCamera;
	// Use this for initialization
	void Start () {
        bounds = GetComponent<BoxCollider2D>();
        theCamera = FindObjectOfType<camera_control>();
        theCamera.SetBounds(bounds);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
