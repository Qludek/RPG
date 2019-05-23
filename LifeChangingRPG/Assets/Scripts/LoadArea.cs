using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadArea : MonoBehaviour {

    public string LevelToLoad;

    public string ExitPoint;

    private player_movement ThePlayer;
	// Use this for initialization
	void Start () {
        ThePlayer = FindObjectOfType<player_movement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Application.LoadLevel(LevelToLoad);
            ThePlayer.StartPoint = ExitPoint;
        }
    }
}
