using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour {
    public PlayerHealthManager playerHealth;
    public PlayerManaManager playerMana;
    public PlayerStatistics playerStats;
    public DamageEnemy playerDamage;

    //private float attSpeed;
    public Text skillPoints;
    //private static bool SkillManagerExist;
    private int onePointCapR;
    private int onePointCapDWM;
    private int onePointCapBP;
    private int critCap;
    public bool moveAndAttack;
    public float attSpeed;
    public bool bladeParade;
    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealthManager>();
        playerMana = FindObjectOfType<PlayerManaManager>();
        playerStats = FindObjectOfType<PlayerStatistics>();
        playerDamage = FindObjectOfType<DamageEnemy>();
    }
        // Use this for initialization
        void Start () {
        //if (!SkillManagerExist)
        //{
        //    SkillManagerExist = true;
        //    DontDestroyOnLoad(transform.gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
        attSpeed = 10;
        moveAndAttack = false;
    }
	
	// Update is called once per frame
	void Update () {
        skillPoints.text = "Skill points left: " + playerStats.skillPoints;
    }
    public void HealthUP()
    {
        if (playerStats.skillPoints > 0)
        {
            playerStats.skillPoints--;
            playerHealth.PlayerMaxHealth += 60;
            playerHealth.PlayerCurrentHealth += 60;
            if (playerHealth.PlayerCurrentHealth > playerHealth.PlayerMaxHealth)
            {
                playerHealth.PlayerCurrentHealth = playerHealth.PlayerMaxHealth;
            }
        }  
    }
    public void HealthRegenUP()
    {
        if (playerStats.skillPoints > 0)
        {
            playerStats.skillPoints--;
            playerHealth.playerHPRegen += 2;
        }  
    }
    public void ManaUP()
    {
        if (playerStats.skillPoints > 0)
        {
            playerStats.skillPoints--;
            playerMana.PlayerMaxMana += 15;
            playerMana.PlayerCurrentMana += 15;
            if (playerMana.PlayerCurrentMana > playerMana.PlayerMaxMana)
            {
                playerMana.PlayerCurrentMana = playerMana.PlayerMaxMana;
            }
        }
    }
    public void ManaRegenUP()
    {
        if (playerStats.skillPoints > 0)
        {
            playerStats.skillPoints--;
            playerMana.playerMPRegen += 2;
        }
    }
    public void ArmorUP()
    {
        if (playerStats.skillPoints > 0)
        {
            playerStats.skillPoints--;
            playerStats.playerArmour += 1;
        }
    }
    public void MOARArmorUP()
    {
        if (playerStats.skillPoints > 0)
        {
            playerStats.skillPoints--;
            playerStats.playerArmour += 1;
        }
    }
    public void Resurrect()
    {
        if (playerStats.skillPoints > 0)
        {
            if (onePointCapR < 1)
            {
                playerStats.skillPoints--;
                playerHealth.resurrectSkill++;
                onePointCapR++;
            }
        } 
    }
    public void DamageUP()
    {
        if (playerStats.skillPoints > 0)
        {
            playerStats.skillPoints--;
            playerDamage.damageToGive += 4;
        }
    }
    public void AttSpeedUP()
    {
        if (playerStats.skillPoints > 0)
        {
            playerStats.skillPoints--;
            attSpeed += 1;
        }
    }
    public void CritUP()
    {
        if (playerStats.skillPoints > 0)
        {
            if (critCap < 4)
            {
                playerStats.skillPoints--;
                playerDamage.critChance += 1;
                critCap++;
            }
        }
    }
    public void MoveWhileAttack()
    {
        if (playerStats.skillPoints > 0)
        {
            if (onePointCapDWM < 1)
            {
                playerStats.skillPoints--;
                moveAndAttack = true;
                onePointCapDWM++;
            }
        }
    }
    public void BladeParade()
    {
        if (playerStats.skillPoints > 0)
        {
            if (onePointCapBP < 1)
            {
                playerStats.skillPoints--;
                bladeParade = true;
                onePointCapBP++;
            }
        }
    }
}
