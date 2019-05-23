using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {
    public Slider HealthBar;
    public Text HPText;
    public PlayerHealthManager PlayerHealth;
    public Slider ManaBar;
    public Text MPText;
    public PlayerManaManager PlayerMana;
    private bool skillMenuCheck;
    public TutorialGrandpa saySomething;
    public PlayerStatistics playerStats;
    public Text skillUpPtsLeft;

    private PlayerStatistics thePS;
    public Text levelText;
    public Text scoreText;

    public static bool UiExists;

    public CanvasGroup skillWindow;
    public CanvasGroup skillpointNotification;
    private bool mainMenuCheck;

    public MainMenuOptions menuOptions;

    private void Awake()
    {
        menuOptions = FindObjectOfType<MainMenuOptions>();
        playerStats = FindObjectOfType<PlayerStatistics>();
    }
    // Use this for initialization
    void Start () {
        if (!UiExists)
        {
            UiExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        thePS = GetComponent<PlayerStatistics>();
        //saySomething = GameObject.FindObjectOfType<TutorialGrandpa>();
        skillMenuCheck = (true);
    }
	
	// Update is called once per frame
	void Update () {
        HealthBar.maxValue = PlayerHealth.PlayerMaxHealth;
        HealthBar.value = PlayerHealth.PlayerCurrentHealth;
        HPText.text = "" + PlayerHealth.PlayerCurrentHealth + "/" + PlayerHealth.PlayerMaxHealth;
        ManaBar.maxValue = PlayerMana.PlayerMaxMana;
        ManaBar.value = PlayerMana.PlayerCurrentMana;
        MPText.text = "" + PlayerMana.PlayerCurrentMana + "/" + PlayerMana.PlayerMaxMana;

        levelText.text = "" + thePS.currentLevel;
        scoreText.text = "Score: " + thePS.score;

        skillUpPtsLeft.text = "Skill points left: " + playerStats.skillPoints;

        if (Input.GetKeyDown("p"))
        {
            if (skillMenuCheck)
            {
                saySomething.Trivia();
                skillWindow.alpha = 1f;
                skillWindow.blocksRaycasts = true;
                skillMenuCheck = (false);
            }
            else
            {
                skillWindow.alpha = 0f;
                skillWindow.blocksRaycasts = false;
                skillMenuCheck = (true);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mainMenuCheck)
            {
                menuOptions.EnterMenu();
                mainMenuCheck = (false);
            }
            else
            {
                menuOptions.ExitMenu();
                mainMenuCheck = (true);
            }
            
        }
        if (playerStats.skillPoints > 0)
        {
            skillpointNotification.alpha = 1f;
            skillpointNotification.blocksRaycasts = true;
        }
        else
        {
            skillpointNotification.alpha = 0f;
            skillpointNotification.blocksRaycasts = false;
        }
    }
}
