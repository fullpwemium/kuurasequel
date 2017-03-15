using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordButtonScript : MonoBehaviour {

    public string buttonName;
    public Button button;
    WordGameScript game;

    // Use this for initialization
    void Start () {

        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);       //debugging purposes

    }
	
    void TaskOnClick()
    {
        /*
        Debug.Log("Clicked " + buttonName);
        game.buttonClick(buttonName);
        */
    }
}
