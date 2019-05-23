using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManaManager : MonoBehaviour {
    public int PlayerMaxMana;
    public int PlayerCurrentMana;
    public int playerMPRegen;
    private float playerMPRegenCounter;
    public float playerMPRegenDelay;
    // Use this for initialization
    void Start () {
        PlayerCurrentMana = PlayerMaxMana;
        playerMPRegenCounter = playerMPRegenDelay;
    }
	
	// Update is called once per frame
	void Update () {
        playerMPRegenCounter -= Time.deltaTime;
        if (playerMPRegenCounter <= 0)
        {
            if (PlayerCurrentMana < PlayerMaxMana)
            {
                PlayerCurrentMana += playerMPRegen;
                if (PlayerCurrentMana > PlayerMaxMana)
                {
                    PlayerCurrentMana = PlayerMaxMana;
                }
            }
            playerMPRegenCounter = playerMPRegenDelay;
        }
    }
}
