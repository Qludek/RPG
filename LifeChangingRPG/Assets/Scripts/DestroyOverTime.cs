using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {
    public float TimeToDestroy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimeToDestroy -= Time.deltaTime;

        if (TimeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
	}
}
