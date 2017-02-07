using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class RunnerStarScript : MonoBehaviour
{
    Image Star;
    public int starNumber;
    public int buttonNumber;

    // Use this for initialization
    void Start ()
    {
        RunnerWonStars();
	}

    void RunnerWonStars()
    {
        Star = GetComponent<Image>();

        //Star.color = Color.white;
        Debug.Log("tähtibananasrunner: " + buttonNumber + " " + RunnerWinningPanel.runnerCats[buttonNumber]);
        if (RunnerWinningPanel.runnerCats[buttonNumber] >= starNumber)
        {
            Star.color = Color.white;
            Debug.Log("varjattu");
            Debug.Log("Button number in Star Script = " + buttonNumber);
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update ()
    {
	
	}
}
