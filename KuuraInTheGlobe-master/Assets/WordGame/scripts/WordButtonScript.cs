using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordButtonScript : MonoBehaviour {

    public string buttonName;
    public Button yourButton;
    WordGamePlayerScript player;
    WordGameScript game;

    // Use this for initialization
    void Start () {

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        //player = GameObject.Find("Player").GetComponent<WordGamePlayerScript>();
        //game = GameObject.Find("WordGameSystem").GetComponent<WordGameScript>();

    }
	
    void TaskOnClick()
    {
        Debug.Log("Clicked " + buttonName);
        //game.buttonClick(buttonName);
    }

    // Update is called once per frame

    private void Update()
    {

    }
}
