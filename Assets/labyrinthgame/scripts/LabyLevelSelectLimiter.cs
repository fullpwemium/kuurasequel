﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class LabyLevelSelectLimiter : MonoBehaviour {

    public int buttonLevel;
    Button button;
    bool initialized = false;

    //Checks levels if OnLevelWasLoaded was not called
    void Start()
    {
        CheckLevels();

        if (initialized == false)
        {
            CheckLevels();
        }
    }
    void OnLevelWasLoaded(int level)
    {
        CheckLevels();
    }
    void loadFrigginLevel()
    {
        LabyGameManager.manager.LoadLevel(buttonLevel);
    }

    //Creates buttons and checks if this level is playable
    public void CheckLevels()
    {
        /* If OnClick is assigned through the inspector,
         * the reference is lost upon scene load
         * So it's done through code */
        button = GetComponent<Button>();
        //button.onClick.AddListener(loadFrigginLevel); //Adds OnClick to button
        gameObject.SetActive(false);
        //Debug.Log(LabManager.manager);

        //The first level is always shown regardless of its completetion
        if (LabyGameManager.manager.completedLevels.Any() == false && buttonLevel == 0)
        {
            gameObject.SetActive(true);
        }
        //Checks if this or the previous level is completed, if previous is completed check if next level exists
        if (LabyGameManager.manager.completedLevels.Contains(buttonLevel) ||
            LabyGameManager.manager.completedLevels.Contains(buttonLevel - 1) && buttonLevel < LabyGameManager.manager.levelIndex.Length)
        {
            gameObject.SetActive(true);
        }
        initialized = true;
    }
}
