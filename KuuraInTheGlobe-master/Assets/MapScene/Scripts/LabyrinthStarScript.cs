using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class LabyrinthStarScript : MonoBehaviour {

    Image Star;
    public int starNumber;
    public int buttonNumber;

    // Use this for initialization
    void Start()
    {
        ChecKStars();
    }

    void ChecKStars()
    {
		/*
        Star = GetComponent<Image>();

        //Star.color = Color.white;
        Debug.Log("tähtibananas: "+ buttonNumber + LabManager.levelCats[buttonNumber]);
        if (LabManager.levelCats[buttonNumber] >= starNumber)
        {
            Star.color = Color.white;
            Debug.Log("varjattu");
            Debug.Log("Button number in Star Script = " + buttonNumber);
        }
        else
        {

        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        // ChecKStars();

    }


}