using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEnemy : MonoBehaviour {
    public int damageToGive;
    private int damageToGiveHolder;
    public GameObject damageNumber;
    public GameObject damageNumberCrit;
    private int toCritOrNotToCrit;
    public int critChance;
	// Use this for initialization
	void Start () {
        critChance = 5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            toCritOrNotToCrit = Random.Range(0, 100);
            //Destroy(other.gameObject);
            if(toCritOrNotToCrit <= critChance)
            {
                damageToGiveHolder = damageToGive;
                damageToGive = 9001;
                other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
                var clone = Instantiate(damageNumberCrit, other.gameObject.transform.position, Quaternion.Euler(Vector3.zero));
                clone.GetComponent<FloatingDamageNumbers>().DamageNumber = damageToGive;
                damageToGive = damageToGiveHolder;
            }
            else
            {
                other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
                var clone = Instantiate(damageNumber, other.gameObject.transform.position, Quaternion.Euler(Vector3.zero));
                clone.GetComponent<FloatingDamageNumbers>().DamageNumber = damageToGive;
            }
            
        }
    }
}
