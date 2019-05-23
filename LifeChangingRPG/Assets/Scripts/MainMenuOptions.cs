using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuOptions : MonoBehaviour {
    public CanvasGroup menuBGImage;
    public CanvasGroup menuImage;
    public CanvasGroup optionSoundImage;
    private static bool MainMenuExist;
    public bool onGUI;
    // Use this for initialization
    void Start()
    {
        //if (!MainMenuExist)
        //{
        //    MainMenuExist = true;
        //    DontDestroyOnLoad(transform.gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
        menuBGImage.alpha = 1f;
        menuBGImage.blocksRaycasts = true;
        menuImage.alpha = 1f;
        menuImage.blocksRaycasts = true;
        Time.timeScale = 0;
        onGUI = false;
        optionSoundImage.alpha = 0f;
        optionSoundImage.blocksRaycasts = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        menuBGImage.alpha = 0f;
        menuBGImage.blocksRaycasts = false;
        menuImage.alpha = 0f;
        menuImage.blocksRaycasts = false;
        Time.timeScale = 1;
    }
    public void QuitTheGame()
    {
        Application.Quit();
    }
    public void EnterMenu()
    {
        menuBGImage.alpha = 1f;
        menuBGImage.blocksRaycasts = true;
        menuImage.alpha = 1f;
        menuImage.blocksRaycasts = true;
        Time.timeScale = 0;
    }
    public void ExitMenu()
    {
        menuBGImage.alpha = 0f;
        menuBGImage.blocksRaycasts = false;
        menuImage.alpha = 0f;
        menuImage.blocksRaycasts = false;
        Time.timeScale = 1;
    }
    public void SoundOptions()
    {
        if (onGUI == true)
        {
            onGUI = false;
            optionSoundImage.alpha = 0f;
            optionSoundImage.blocksRaycasts = false;
        }
        else
        {
            optionSoundImage.alpha = 1f;
            optionSoundImage.blocksRaycasts = true;
            onGUI = true;
        }
    }
}
