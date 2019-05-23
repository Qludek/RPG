using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NonPlayerPrefs : MonoBehaviour {
    private PlayerStatistics scoreValue;
    public float readScore;
    public CanvasGroup hiScoresImage;
    public CanvasGroup hiScoresBGImage;
    private MainMenuOptions toCanvases;
    public PlayerHealthManager playerIsDead;
    private EndGamePoint playerHasWon;
    private string[] prefNazwy = { "score1", "score2", "score3", "score4", "score5" };
    private float[] playerScores = { 0, 0, 0, 0, 0, 0 };
    private camera_control cameraD;
    private player_movement playerD;
    private UiManager managerD;
    private SFXManager sfxmanagerD;

    public Text[] score;
    //public Text score2;
    //public Text score3;
    //public Text score4;
    //public Text score5;

    private void Awake()
    {
        scoreValue = FindObjectOfType<PlayerStatistics>();
        toCanvases = FindObjectOfType<MainMenuOptions>();
        playerIsDead = FindObjectOfType<PlayerHealthManager>();
        cameraD = FindObjectOfType<camera_control>();
        playerD = FindObjectOfType<player_movement>();
        managerD = FindObjectOfType<UiManager>();
        sfxmanagerD = FindObjectOfType<SFXManager>();

    }
	// Use this for initialization
	void Start () {
        
        //PlayerPrefs.SetFloat("score", scoreValue.score);
        //readScore = PlayerPrefs.GetFloat("score");
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerHasWon = FindObjectOfType<EndGamePoint>();
        if (playerIsDead.playerDead)
        {
            playerIsDead.playerDead = (false);
            SaveScores();
        }
        if (playerHasWon != null)
        {
            if (playerHasWon.playerWin)
            {
                playerHasWon.playerWin = (false);
                SaveScores();
            }
        }
	}
    public void QuitTheGame()
    {
        hiScoresBGImage.alpha = 0f;
        hiScoresBGImage.blocksRaycasts = false;
        hiScoresImage.alpha = 0f;
        hiScoresImage.blocksRaycasts = false;

        Destroy(playerD.gameObject);
        player_movement.PlayerExist = false;
        Destroy(cameraD.gameObject);
        camera_control.CameraExist = false;
        Destroy(managerD.gameObject);
        UiManager.UiExists = false;
        Destroy(sfxmanagerD.gameObject);
        SFXManager.sfxController = false;


        SceneManager.LoadScene("scene1");

        toCanvases.menuBGImage.alpha = 1f;
        toCanvases.menuBGImage.blocksRaycasts = true;
        toCanvases.menuImage.alpha = 1f;
        toCanvases.menuImage.blocksRaycasts = true;
        //Time.timeScale = 0;
    }
    //public void ShowScoresMenu()
    //{

    //    hiScoresBGImage.alpha = 1f;
    //    hiScoresBGImage.blocksRaycasts = true;
    //    hiScoresImage.alpha = 1f;
    //    hiScoresImage.blocksRaycasts = true;

    //    Time.timeScale = 0;
    //}
    public void SaveScores()
    {

        playerScores[5] = scoreValue.score;
        for (int i = 0; i < 5; i++)
        {
            playerScores[i] = PlayerPrefs.GetFloat(prefNazwy[i], 0);
        }
        Array.Sort(playerScores);
        Array.Reverse(playerScores);
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat(prefNazwy[i], playerScores[i]);
            //Debug.Log(playerScores[i]);
        }
        for (int i = 0; i < 5; i++)
        {
            score[i].text = "" + playerScores[i];
        }
        //ShowScoresMenu();
        hiScoresBGImage.alpha = 1f;
        hiScoresBGImage.blocksRaycasts = true;
        hiScoresImage.alpha = 1f;
        hiScoresImage.blocksRaycasts = true;

        Time.timeScale = 0;
    }
}
