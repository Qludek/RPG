using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePoint : MonoBehaviour {
    public CanvasGroup winningScreen;
    private NonPlayerPrefs images;
    public bool playerWin;
	// Use this for initialization
	void Start () {
        playerWin = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            //winningScreen.alpha = 1f;
            //winningScreen.blocksRaycasts = true;
            playerWin = true;
            Time.timeScale = 0;
        }
    }
}
