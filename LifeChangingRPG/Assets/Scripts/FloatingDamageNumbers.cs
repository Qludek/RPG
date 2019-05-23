using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingDamageNumbers : MonoBehaviour {
    public float MoveSpeed;
    public int DamageNumber;
    public Text DisplayNumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DisplayNumber.text = "" + DamageNumber;
        transform.position = new Vector3(transform.position.x, transform.position.y + (MoveSpeed * Time.deltaTime), transform.position.z);
	}
}
