using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class RunnerLevelSelectLimiter : MonoBehaviour
{
    public static List<int> completedLevels = new List<int>(100);

    public int buttonLevel;
    Button button;
    bool initialized;

    //Checks levels if OnLevelWasLoaded was not called
    void Start()
    {
        if (initialized == false)
        {
            CheckLevels();
            Debug.Log("initialized false");
        }
    }
    void OnLevelWasLoaded(int level)
    {
        CheckLevels();
    }
    void loadFrigginLevel()
    {
        RunnerManager.manager.LoadLevel(buttonLevel);
    }

    //Creates buttons and checks if this level is playable
    void CheckLevels()
    {
        /* If OnClick is assigned through the inspector,
         * the reference is lost upon scene load
         * So it's done through code */
        button = GetComponent<Button>();
        //button.onClick.AddListener(loadFrigginLevel); //Adds OnClick to button

        gameObject.SetActive(false);
//        gameObject.SetActive(true);

       // Debug.Log(RunnerManager.manager.completedLevels.Any());
		if(RunnerManager.manager == null)
			return;
        //The first level is always shown regardless of its completetion
        if (RunnerManager.manager.completedLevels.Any() == false && buttonLevel == 0)
        {
            gameObject.SetActive(true);
        }
        //Checks if this or the previous level is completed, if previous is completed check if next level exists
        if (RunnerManager.manager.completedLevels.Contains(buttonLevel) ||
            RunnerManager.manager.completedLevels.Contains(buttonLevel - 1) && buttonLevel < RunnerManager.manager.levelIndex.Length)
        {
            gameObject.SetActive(true);
        }
        initialized = true;
    }
}
