using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class RunnerLevelSelectLimitter : MonoBehaviour
{
    public static List<int> completedLevels = new List<int>();

    public int buttonLevel;
    Button button;
    bool initialized = false;
    private Canvas canvas;
    private Toggle toggle;
    Image[] stars;

    static GlobalGameManager GGM;

    //Checks levels if OnLevelWasLoaded was not called
    void Start()
    {
        //GlobalGameManager.GGM.MemoryGameSave();

        //GlobalGameManager.GGM.RunnerLoad();

        completedLevels = new List<int>();

        //completedLevels.Add(0);
        //completedLevels.Add(1);
        //completedLevels.Add(2);
        //completedLevels.Add(3);
        //Debug.Log(completedLevels[0] + " completed levels");
        //Debug.Log(completedLevels[1] + " completed levels");
        //Debug.Log(completedLevels[2] + " completed levels");
        //Debug.Log(completedLevels[3] + " completed levels");

        //canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        //canvas.enabled = true;
        button = GetComponent<Button>();

        //button.onClick.AddListener(loadFrigginLevel);

        //toggle = GameObject.Find("GyroToggle").GetComponent<Toggle>();
        //toggle.onValueChanged.AddListener((delegate { ShelfGameManager.GyroToggle(); }));

        CheckLevels();

        /*if (ShelfGameManager.gyroOn == true)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        if (initialized == false)
        {
            CheckLevels();
        }*/
    }

    void update()
    {
        CheckLevels();
    }

    void OnLevelWasLoaded(int level)
    {
        CheckLevels();
    }

    //Creates buttons and checks if this level is playable
    void CheckLevels()
    {
        /* If OnClick is assigned through the inspector,
         * the reference is lost upon scene load
         * So it's done through code */

        //Adds OnClick to button
        //Debug.Log("nappula listenerit laitettu");
        gameObject.SetActive(false);

        //Debug.Log(completedLevels.Last());
        //The first level is always shown regardless of its completetion
        if (completedLevels.Any() == false && buttonLevel == 0)
        {
            gameObject.SetActive(true);
            Debug.Log(gameObject + " näkyy");
        }
        //Checks if this or the previous level is completed, if previous is completed check if next level exists
        if (completedLevels.Contains(buttonLevel) ||
            completedLevels.Contains(buttonLevel - 1) &&
            buttonLevel < 10)
        {
            gameObject.SetActive(true);
            Debug.Log(gameObject + " näkyy");
        }
        initialized = true;
    }
}


