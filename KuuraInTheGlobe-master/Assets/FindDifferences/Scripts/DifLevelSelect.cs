using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifLevelSelect : MonoBehaviour
{
    Button levelButton;

    public int levelButtonNumber;

    public List<Button> buttons;
    DifferenceManager manager;

    // Use this for initialization
    void Start ()
    {
        levelButton = gameObject.GetComponent<Button>();

        levelButton.onClick.AddListener(() => LoadDifferenceGame());
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    public void OnMouseDown()
    {
        LoadDifferenceGame();
    }

    void LoadDifferenceGame()
    {
        DifferenceManager.manager.LoadLevel(levelButtonNumber);
        Debug.Log("Level Button Number = " + levelButtonNumber);
    }

    //private void checkButtons()
    //{
    //    for (int i = 0; i < buttons.Capacity; i++)
    //    {
    //        int completedLevels = manager.getClearedLevels();
    //        if (completedLevels >= i)
    //        {
    //            buttons[i].interactable = true;
    //        }
    //        else if (completedLevels < i)
    //        {
    //            buttons[i].interactable = false;
    //        }
    //    }
    //}
}
