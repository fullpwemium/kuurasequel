using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifClicksLeft : MonoBehaviour
{
    public static int clicksLeft;

    public static Text clickCounter;

    // Use this for initialization
    void Start ()
    {
        //Show how many clicks is left.
        if (DifLevelObjects.levelNumber == 0 || DifLevelObjects.levelNumber == 1 || DifLevelObjects.levelNumber == 3)
        {
            clicksLeft = 5;
        }
        if (DifLevelObjects.levelNumber == 2)
        {
            clicksLeft = 4;
        }

        clickCounter = GameObject.Find("ClicksLeft").GetComponent<Text>(); //Find text component.
    }
	
	// Update is called once per frame
	void Update ()
    {
        clickCounter.text = clicksLeft.ToString(); //Print clicks left in text object.
    }
}
