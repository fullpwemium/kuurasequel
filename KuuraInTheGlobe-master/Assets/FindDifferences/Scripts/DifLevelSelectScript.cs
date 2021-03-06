﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifLevelSelectScript : MonoBehaviour
{
    public static DifLevelSelectScript DLSS;

    public static int wonCats;

    public GameObject systemPrefab;
    public List<Button> levelButtons;
    DifGameSystem system;

    ////---------------------------------------------------
    ////Intro panel objects. //(Moved to DifGameIfo script.)
    //public Button introButton;
    //public GameObject introPanel;
    //public GameObject introPicture1, introPicture2;
    //public List<Sprite> introImages;
    //public Text introText;
    //public Text pageNumber;
    //public Button introNextButton;
    //public Button introPrevButton;
    //public int introPage;
    ////---------------------------------------------------

    // Use this for initialization
    void Start ()
    {
        //introPanel.SetActive(false);

        // Fetch system object
        if (!GameObject.Find("difGameSystem"))      //Create system prefab if it's missing.
        {
            system = GameObject.Instantiate(systemPrefab).GetComponent<DifGameSystem>();
            //system.init ();
            Debug.Log("system added");
        }
        else
        {
            system = GameObject.Find("difGameSystem").GetComponent<DifGameSystem>();
            Debug.Log("system found");
        }

        checkButtons();

        MusicPlayer.PlayMusic(MusicTrack.BubbleWarehouseCutscene);
    }

    //Open levels by clicking level buttons, set in level buttons' On Click()
    public void levelButtonClick(int level)
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuEffect, 1);

        //SceneManager.LoadScene("DifGameplay", LoadSceneMode.Single);

        //system.setStartingLevel(level);

        //Open level by level number (1-->) written in Button's On Click()
        if (level == 1)
        {
            Debug.Log("Kenttä 1");

            //SceneManager.LoadScene("DifLevel1(2)", LoadSceneMode.Single);         //When opening all levels in own scenes (Not using)
            SceneManager.LoadScene("DifGameplay", LoadSceneMode.Single);        //When opening all levels in common DifGameplay scene.

            DifLevelObjects.levelNumber = 0;        //Set value which set active objects defined to each level.
            Debug.Log("Level number = " + DifLevelObjects.levelNumber);
        }
        else if (level == 2)
        {
            Debug.Log("Kenttä 2");

            //SceneManager.LoadScene("DifLevel2", LoadSceneMode.Single);    //Not using
            SceneManager.LoadScene("DifGameplay", LoadSceneMode.Single);

            DifLevelObjects.levelNumber = 1;
            Debug.Log("Level number = " + DifLevelObjects.levelNumber);
        }
        else if (level == 3)
        {
            Debug.Log("Kenttä 3");

            //SceneManager.LoadScene("DifLevel3", LoadSceneMode.Single);    //Not using
            SceneManager.LoadScene("DifGameplay", LoadSceneMode.Single);

            DifLevelObjects.levelNumber = 2;
            Debug.Log("Level number = " + DifLevelObjects.levelNumber);
        }
        else if (level == 4)
        {
            Debug.Log("Kenttä 4");

            SceneManager.LoadScene("DifGameplay", LoadSceneMode.Single);

            DifLevelObjects.levelNumber = 3;
            Debug.Log("Level number = " + DifLevelObjects.levelNumber);
        }
        else if (level == 5)
        {
            Debug.Log("Kenttä 5");

            SceneManager.LoadScene("DifGameplay", LoadSceneMode.Single);

            DifLevelObjects.levelNumber = 4;
            Debug.Log("Level number = " + DifLevelObjects.levelNumber);
        }
        else if (level == 6)
        {
            Debug.Log("Kenttä 6");

            SceneManager.LoadScene("DifGameplay", LoadSceneMode.Single);

            DifLevelObjects.levelNumber = 5;
            Debug.Log("Level number = " + DifLevelObjects.levelNumber);
        }
        else if (level == 7)
        {
            Debug.Log("Kenttä 7");

            //SceneManager.LoadScene("DifGameplay", LoadSceneMode.Single);

            DifLevelObjects.levelNumber = 6;
            Debug.Log("Level number = " + DifLevelObjects.levelNumber);
        }
        else if (level == 8)
        {
            Debug.Log("Kenttä 8");

            //SceneManager.LoadScene("DifGameplay", LoadSceneMode.Single);

            DifLevelObjects.levelNumber = 7;
            Debug.Log("Level number = " + DifLevelObjects.levelNumber);
        }
        else if (level == 9)
        {
            Debug.Log("Kenttä 9");

            //SceneManager.LoadScene("DifGameplay", LoadSceneMode.Single);

            DifLevelObjects.levelNumber = 8;
            Debug.Log("Level number = " + DifLevelObjects.levelNumber);
        }
        else if (level == 10)
        {
            Debug.Log("Kenttä 10");

            //SceneManager.LoadScene("DifGameplay", LoadSceneMode.Single);

            DifLevelObjects.levelNumber = 9;
            Debug.Log("Level number = " + DifLevelObjects.levelNumber);
        }
    }

    //Open level buttons by cleared levels number.      --> Start()
    private void checkButtons()
    {
        for (int i = 0; i < levelButtons.Capacity; i++)
        {
            int clearedlevels = system.getClearedLevels();      //Get cleared levels number from system.
            if (clearedlevels >= i)     //Compare cleared levels number to local i variable.
            {
                levelButtons[i].interactable = true;
                Debug.Log("Open buttons = " + i);

                wonCats = i - 1;
                Debug.Log("Won cats = " + i);
            }
            else if (clearedlevels < i)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void exitMinigame()      //Return to Overworld, set in Exit button's On Click()
    {
        //system.exit();

        // Saving cleared levels, collected cats, and other details would go here

        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuCancel, 1);
        Destroy(gameObject);
        SceneManager.LoadScene("Overworld", LoadSceneMode.Single);
        Debug.Log("Poistutaan");
    }

    public void openIntroPanel()        //(Moved to DifGameIfo script.)
    {
        //introPanel.SetActive(true);
        //introPage = 1;
        //introText.text = "Sivu 1";
        //introPrevButton.interactable = false;
    }

    public void closeIntroPanel()
    {
        //introPanel.SetActive(false);
    }

    public void introPanelNextPage()        //(Moved to DifGameIfo script.)
    {
        ////Check if introPage is inside wanted numbers.
        //if (introPage >= 1 && introPage <= 3)
        //{
        //    introPage++;
        //    Debug.Log("Intro page = " + introPage);
        //}

        //if (introPage == 1)
        //{
        //    introText.text = "Sivu 1";
        //    introNextButton.interactable = true;
        //}
        //if (introPage == 2)
        //{
        //    introText.text = "Sivu 2";
        //    introNextButton.interactable = true;
        //}
        //if (introPage == 3)
        //{
        //    introText.text = "Sivu 3";
        //    introNextButton.interactable = false;
        //}
    }

    public void introPanelPrevPage()        //(Moved to DifGameIfo script.)
    {
        ////Check if introPage is inside wanted numbers.
        //if (introPage >= 1 && introPage <= 3)
        //{
        //    introPage--;
        //    Debug.Log("Intro page = " + introPage);
        //}

        //if (introPage == 1)
        //{
        //    introText.text = "Sivu 1";
        //    introPrevButton.interactable = false;
        //}
        //if (introPage == 2)
        //{
        //    introText.text = "Sivu 2";
        //    introPrevButton.interactable = true;
        //}
        //if (introPage == 3)
        //{
        //    introText.text = "Sivu 3";
        //    introPrevButton.interactable = true;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        ////When introPanel is active. (Moved to DifGameIfo script.)
        //if (introPanel.activeInHierarchy == true)
        //{
        //    if (introPage == 1)
        //    {
        //        introPicture1.SetActive(false);
        //        introPicture2.SetActive(false);
        //        introText.text = "Sivu 1";
        //        pageNumber.text = introPage + " / 3";
        //        introPrevButton.interactable = false;
        //        introNextButton.interactable = true;
        //    }
        //    if (introPage == 2)
        //    {
        //        introPicture1.SetActive(true);
        //        introPicture2.SetActive(true);
        //        introPicture1.GetComponent<SpriteRenderer>().sprite = introImages[1];
        //        introPicture2.GetComponent<SpriteRenderer>().sprite = introImages[0];
        //        introText.text = "Sivu 2";
        //        pageNumber.text = introPage + " / 3";
        //        introPrevButton.interactable = true;
        //        introNextButton.interactable = true;
        //    }
        //    if (introPage == 3)
        //    {
        //        introPicture1.GetComponent<SpriteRenderer>().sprite = introImages[0];
        //        introPicture2.GetComponent<SpriteRenderer>().sprite = introImages[0];
        //        introText.text = "Sivu 3";
        //        pageNumber.text = introPage + " / 3";
        //        introPrevButton.interactable = true;
        //        introNextButton.interactable = false;
        //    }
        //}
    }
}
