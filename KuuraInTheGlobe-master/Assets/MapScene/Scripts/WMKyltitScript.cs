﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class WMKyltitScript : MonoBehaviour {

    Button Button;
    public int nappi;

	// Use this for initialization
	void Start () {

        Button = gameObject.GetComponent<Button>();

        Button.onClick.AddListener(() => tsubbidubbiduu());

    }

    void tsubbidubbiduu()
    {
        if(nappi == 1)
        {

            if (BobPlayerScript.nearMemoryGame)     //Ladataan Scene kun klikataan buttonia jonka päällä Bob seisoo
            {
                SceneManager.LoadScene("LevelMap");    //Ladataan Scene
                BobPlayerScript.nearMemoryGame = false;
            }
            else if (BobPlayerScript.nearCatchTheCat)
            {
                SceneManager.LoadScene("CatchTheCatLevelSelect");
                BobPlayerScript.nearCatchTheCat = false;
            }
            else if (BobPlayerScript.nearLabyrinth)
            {
                Debug.Log("bananaaa");
                SceneManager.LoadScene("LabyrinthLevelSelect");
                BobPlayerScript.nearLabyrinth = false;
            }
            else if (BobPlayerScript.Runner)
            {
                SceneManager.LoadScene("RunnerLevelMap");
                BobPlayerScript.Runner = false;

            }
            else if (BobPlayerScript.nearBobApartment)
            {
                SceneManager.LoadScene("Bob_apartment");
                BobPlayerScript.nearBobApartment = false;
            }
        }
        else if (nappi == 2)
        {
            BobPlayerScript.nearMemoryGame = false;
            BobPlayerScript.nearBobApartment = false;
            BobPlayerScript.Runner = false;
            BobPlayerScript.nearLabyrinth = false;
            BobPlayerScript.nearCatchTheCat = false;
            SceneManager.LoadScene("Map2");    //Ladataan Scene

        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    
}
