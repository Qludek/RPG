using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour {
    public int currentLevel;
    public float currentExp;
    public float toLevelUp;
    private float currentLevelFloat;
    private float a;
    private float b;
    public float score;
    public int skillPoints;

    public int playerArmour;

    public DamageEnemy playerAttack;

    private PlayerHealthManager playerHealth;
    private PlayerManaManager playerMana;

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealthManager>();
        playerAttack = FindObjectOfType<DamageEnemy>();
        playerMana = FindObjectOfType<PlayerManaManager>();
    }

    //private PlayerManaManager playerMana;
    // Use this for initialization
    void Start () {
        currentLevel = 1;
        toLevelUp = 12;
        skillPoints = 4;
        a = 100f;
        b = 1.5f;
    }
	
	// Update is called once per frame
	void Update () {
        if (currentExp >= toLevelUp)
        {
            currentLevelFloat = currentLevel;
            currentExp -= toLevelUp;
            toLevelUp *=(b+((currentLevelFloat)/a));
            skillPoints++;
            LevelUp();
        }
	}
    public void AddExperience(float experienceToAdd)
    {
        currentExp += experienceToAdd;
        score += experienceToAdd;
    }
    public void LevelUp()
    {
        playerHealth.PlayerMaxHealth += 20;
        playerMana.PlayerMaxMana += 5;
        currentLevel++;
        playerArmour += 1; //+ (currentLevel / 5);
        playerAttack.damageToGive += 7;
        playerHealth.PlayerCurrentHealth = playerHealth.PlayerMaxHealth;
        playerMana.PlayerCurrentMana = playerMana.PlayerMaxMana;
    }
}
