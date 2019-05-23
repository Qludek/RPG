using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialGrandpa : MonoBehaviour {
    private int triviaForToday;
    public Text textSentence;
    string[] sentences = new string[] { "Did you know, that the incompetent programmer couldn't even programme yellow text on crit hit?",  "In a future far, far away maybye this window will have some use... ", "Changing the attack speed of animation, thats, like, impossible!", "why are there only basic skills? beacause HE couldn't programme it!" };
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Trivia()
    {
        triviaForToday = Random.Range(0, 4);
        textSentence.text= sentences[triviaForToday];
    }
}
