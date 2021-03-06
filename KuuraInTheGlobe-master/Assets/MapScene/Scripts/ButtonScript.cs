﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    Button Button;

    public int ButtonNumber;
    public int ButtonNumber2;
    public static ButtonScript buttonScript;




    public int gameNumber;

	private Node nodeScript;
    BobPlayerScript Bob;

    //static GameObject BobPlayer;

    // Use this for initialization
    void Start ()
    {
		nodeScript = GetComponent<Node>();
        Bob = GameObject.Find("BobPlayer").GetComponent<BobPlayerScript>();
        Button = gameObject.GetComponent<Button>();

        Button.onClick.AddListener(() => MoveHere());

        //BobPlayer = GameObject.Find("BobPlayer");
    }

    // Update is called once per frame
    void Update ()
    {
        

    }

    public void OnMouseDown()
    {
        MoveHere();

        //if (this.Button.name == "Exit")
        //{
        //    BobPlayer.transform.position = new Vector3(1.5F, -0.4F, -11.5F);
        //    Debug.Log(BobPlayer.transform.position);
        //}
    }

    void MoveHere ()
    {
        if (BobPlayerScript.Moving == false)
        {       
            GameLoader();
			Bob.startMoving ( 
				nodeScript.findPath (
					nodeScript,
					true,
					0, 
					Bob.getCurrentNode()
				),
				ButtonNumber,
				ButtonNumber2
			);
        }
    }

    public void GameLoader()
    {

        CheckGame();
        //Debug.Log("nearMemoryGame" + BobPlayerScript.nearMemoryGame);

        if (BobPlayerScript.nearMemoryGame)     //Ladataan Scene kun klikataan buttonia jonka päällä Bob seisoo
        {
            //MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().currentScene = "Memory";
            SceneManager.LoadScene("CutScene");
            //SceneManager.LoadScene("LevelMap");    //Ladataan Scene
            BobPlayerScript.nearMemoryGame = false;
        }
        else if (BobPlayerScript.nearCatchTheCat)
        {
			/*
            MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().currentScene = "Warehouse";
            SceneManager.LoadScene("CutScene");
            //SceneManager.LoadScene("CatchTheCatLevelSelect");
            */
            BobPlayerScript.nearCatchTheCat = false;
        }
        else if (BobPlayerScript.nearLabyrinth)
        {
            //MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().currentScene = "Mine";
            SceneManager.LoadScene("CutScene");
            //SceneManager.LoadScene("LabyrinthLevelSelect");
            BobPlayerScript.nearLabyrinth = false;
        }
        else if (BobPlayerScript.Runner)
        {
            //MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);
            GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().currentScene = "Forest";
            SceneManager.LoadScene("CutScene");
            //SceneManager.LoadScene("RunnerLevelMap");
            BobPlayerScript.Runner = false;

        }
        else if (BobPlayerScript.nearBobApartment)
        {
            //MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);
            SceneManager.LoadScene("Bob_apartment");
            BobPlayerScript.nearBobApartment = false;

        }
        else if (BobPlayerScript.nearShop)
        {
            //MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);
            //SceneManager.LoadScene(36);
            SceneManager.LoadScene("Shop");
            BobPlayerScript.nearBobApartment = false;
            Debug.Log("Kauppaan");
        }

    }

   void CheckGame()
    {
        //Debug.Log("BobPlayer position = " + BobPlayer.transform.position);
        //Debug.Log("button position = " + gameObject.transform.position);

        //        if ((BobPlayer.transform.position.x == gameObject.transform.position.x) &&
        //        (BobPlayer.transform.position.y == gameObject.transform.position.y + 1))
        //if ((BobPlayer.transform.position.x == gameObject.transform.position.x)
        //    && (BobPlayer.transform.position.y == gameObject.transform.position.y+aboveButton))
        if(BobPlayerScript.StandingButtonNumberX == ButtonNumber&& BobPlayerScript.StandingButtonNumberY == ButtonNumber2)
        {
            if (gameNumber == 1)    //Katsotaan onko Bobin seisomalla buttonilla annettu arvo
            {
                BobPlayerScript.nearMemoryGame = true;
            }
            else if (gameNumber == 2)
            {
                BobPlayerScript.nearCatchTheCat = true;
            }
            else if (gameNumber == 3)
            {
                BobPlayerScript.nearLabyrinth = true;
            }
            else if (gameNumber == 4)
            {
                BobPlayerScript.Runner = true;
            }
            else if (gameNumber == 5)
                BobPlayerScript.nearBobApartment = true;
            else if (gameNumber == 6)
                BobPlayerScript.nearShop = true;
            else
            {/*
                BobPlayerScript.nearMemoryGame = false;
                BobPlayerScript.Runner = false;
                BobPlayerScript.nearLabyrinth = false;
                BobPlayerScript.nearCatchTheCat = false;*/
            }
        }
    }


}




//public void OnMouseDown()
//{ // start button script 
//    if (this.gameObject.name == "start_button")
//    {
//        layermanager.GetComponent<LayerScript>().Layers();
//        //			this.gameObject.SetActive(false);
//    }
//}
