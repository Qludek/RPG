using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
    public int MaxHealth;
    public int CurrentHealth;

    private PlayerStatistics thePlayerStatistics;

    public int expToGive;
    // Use this for initialization
    void Start()
    {
        CurrentHealth = MaxHealth;

        thePlayerStatistics = FindObjectOfType<PlayerStatistics>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);

            thePlayerStatistics.AddExperience(expToGive);
        }
    }
    public void HurtEnemy(int DamageToGive)
    {
        CurrentHealth -= DamageToGive;
    }
    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
