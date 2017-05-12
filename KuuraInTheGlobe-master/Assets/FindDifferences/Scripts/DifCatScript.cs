using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class DifCatScript : MonoBehaviour
{
    Image Cat;
    public int catNumber;
    public int buttonNumber;

    // Use this for initialization
    void Start ()
    {
        DiffefenceWonCats();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void DiffefenceWonCats()
    {
        Cat = GetComponent<Image>();

        //Debug.Log("Won cats: " + buttonNumber + DifferenceManager.levelCats[buttonNumber]);

        //Check how many points/cat heads won in completed levels.
        //if (DifferenceManager.levelCats[buttonNumber] >= catNumber)
        if (DifLevelSelectScript.wonCats >= catNumber)
        {
            gameObject.SetActive(true);     //Set won cat heads visible.
            Cat.color = Color.white;       //Visualize won points/cat heads.
            Debug.Log("Värjatty");
            Debug.Log("Button number in Star Script = " + buttonNumber);
        }
        else
        {
            gameObject.SetActive(false);    //Set not won cat heads unvisible.
        }
    }
}
