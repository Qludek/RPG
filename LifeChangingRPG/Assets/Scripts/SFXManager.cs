using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour {
    public MainMenuOptions optionsVisible;
    public static bool sfxController;
    public AudioSource templeBGM;
    //float sliderValue;
    public Slider soundSlider;
    private void Awake()
    {
        optionsVisible = FindObjectOfType<MainMenuOptions>();
    }
    // Use this for initialization
    void Start () {
        if (!sfxController)
        {
            sfxController = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //sliderValue = 0.5f;
        templeBGM = GetComponent<AudioSource>();
        templeBGM.Play();
        soundSlider.value = 1f;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnGUI()
    {
        if(optionsVisible.onGUI == true)
        {
            //sliderValue = GUI.HorizontalSlider(new Rect(200, 200, 200, 60), sliderValue, 0.0F, 1.0F);
            templeBGM.volume = soundSlider.value;
        }
    }
    //public void volumeDown()
    //{

    //}
    //public void volumeUp()
    //{

    //}
}