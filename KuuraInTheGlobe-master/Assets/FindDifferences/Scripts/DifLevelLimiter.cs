﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class DifLevelLimiter : MonoBehaviour
{
    public int buttonLevel;
    Button Button;
    bool initialized;

    // Use this for initialization
    void Start ()
    {
        //DifferenceManager.manager.DifferenceLoad();

        //CheckLevels();      //Limit opened levels.

        if (initialized == false)
        {
            CheckLevels();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnLevelWasLoaded(int level)
    {
        //CheckLevels();
    }

    public void CheckLevels()
    {
        Button = GetComponent<Button>();

        gameObject.SetActive(false);

        //Define first level activated.
        if (DifferenceManager.manager.completedLevels.Any() == false && buttonLevel == 0)
        {
            gameObject.SetActive(true);

            //Button.interactable = true;

            Debug.Log("1. kenttä auki");
        }

        //Open level if earlier is completed.
        if (DifferenceManager.manager.completedLevels.Contains(buttonLevel) ||
            DifferenceManager.manager.completedLevels.Contains(buttonLevel - 1) &&
            buttonLevel < DifferenceManager.manager.levelIndex.Length)
        {
            gameObject.SetActive(true);

            //Button.interactable = true;

            Debug.Log("Muu kenttä auki");
        }
        //else
        //{
        //    Button.interactable = false;
        //}

        initialized = true;
    }
}