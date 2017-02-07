using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class startScript : MonoBehaviour {

    Image Star;
    public int starNumber;
    public int buttonNumber;

	// Use this for initialization
	void Start () {

        ChecKStars();
    }

    void ChecKStars()
    {
        Star = GetComponent<Image>();
        
        //Star.color = Color.white;

        /*
		Mitä varten on tämä kakka?
		if (ShelfGameManager.manager.levelStars[buttonNumber] >= starNumber)
        {
            Star.color = Color.white;
        }
        else
        {

        }*/
    }
}
