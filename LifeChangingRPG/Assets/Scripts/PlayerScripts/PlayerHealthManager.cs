using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {
    public int PlayerMaxHealth;
    public int PlayerCurrentHealth;
    public int playerHPRegen;
    private float playerHPRegenCounter;
    public float playerHPRegenDelay;
    public float resurrectSkill;
    public float resurrectSkillCounter;
    public float resurrectSkillTimer;
    public bool resurrectViable;
    public bool playerDead;
    public player_movement regenDelay;
    private void Awake()
    {
        regenDelay = FindObjectOfType<player_movement>();
    }
    // Use this for initialization
    void Start () {
        PlayerCurrentHealth = PlayerMaxHealth;
        playerHPRegenCounter = playerHPRegenDelay;
        resurrectSkill = 0f;
        resurrectSkillTimer =60f;
        resurrectViable =(true);
        playerDead = (false);
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerCurrentHealth <= 0)
        {
            if (resurrectSkill > 0)
            {
                if (resurrectViable==(true))
                {
                    StartCoroutine("Resurrect");
                }
                else
                {
                    gameObject.SetActive(false);
                    playerDead = (true);
                }
            }
            else
            {
                gameObject.SetActive(false);
                playerDead = (true);
            }
        }
        regenDelay.afterThrustDelay -= Time.deltaTime;
        if (regenDelay.afterThrustDelay <= 0)
        {
            playerHPRegenCounter -= Time.deltaTime;
            if (playerHPRegenCounter <= 0)
            {
                if (PlayerCurrentHealth < PlayerMaxHealth)
                {
                    PlayerCurrentHealth += playerHPRegen;
                    if (PlayerCurrentHealth > PlayerMaxHealth)
                    {
                        PlayerCurrentHealth = PlayerMaxHealth;
                    }
                }
                playerHPRegenCounter = playerHPRegenDelay;
            }
        }
	}
    public void HurtPlayer(int DamageToGive)
    {
        PlayerCurrentHealth -= DamageToGive;
    }
    public IEnumerator Resurrect()
    {
        PlayerCurrentHealth = PlayerMaxHealth;
        resurrectViable = (false);
        yield return new WaitForSeconds(resurrectSkillTimer);
        resurrectViable = (true);
        yield return null;
    }
}
