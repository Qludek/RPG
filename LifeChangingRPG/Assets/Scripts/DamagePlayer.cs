using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
    public int DamageToGive;
    private int damageToGiveCounter;
    public GameObject DamageNumber;
    private PlayerStatistics armourDecrease;
    private void Awake()
    {
        armourDecrease = FindObjectOfType<PlayerStatistics>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            damageToGiveCounter = DamageToGive;
            DamageToGive -= armourDecrease.playerArmour;
            if (DamageToGive < 1)
            {
                DamageToGive = 1;
            }
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(DamageToGive);
            var clone = (GameObject)Instantiate(DamageNumber, other.gameObject.transform.position, Quaternion.Euler(Vector3.zero));// oprócz Quaternion.Euler(Vector3.zero) działał też Quaternion.identity
            clone.GetComponent<FloatingDamageNumbers>().DamageNumber = DamageToGive;
            DamageToGive = damageToGiveCounter;

        }
    }
}
