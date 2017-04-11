using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMistake : MonoBehaviour
{
    //public Sprite emptySprite;

    public static int Mistakes = 0;

    public static int ClickRights = 0;

    public int Trash;

    public GameObject layerManager;

    public GameObject Active;

    public bool Right = false;

    //public float x, y;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Virheet = " + Mistakes);
        Debug.Log("ClickRights = " + ClickRights);
    }

    //Zero mistake clicks.    --> DifferenceManager.OnLevelWasLoaded.
    public static void StartClicks()
    {
        Mistakes = 0;
        Debug.Log("Virheet = " + Mistakes);
        ClickRights = 0;
        Debug.Log("ClickRights = " + ClickRights);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //When clicking trash object.
        if (/*this.gameObject.name == "Roska"*/ Trash == 1 && FindingTimer.timeLeft > 0)
        {
            //x = 0;
            //y = 2;
            click();

            if (ClickRights == DifferenceManager.Spots /*DifferenceManager.RightClicks == 0*/)
            //if (/*RightClicks == DifferenceManager.Spots*/ DifferenceManager.RightClicks == 0)
            {
                FindingTimer.EndGame();     //Stop timer.
                DifferenceManager.manager.PlayerWin();
                Debug.Log("Virheet = " + Mistakes);
            }
        }
        //When clicking background.
        else if (/*this.gameObject.name == "Background"*/ Trash == 0 && FindingTimer.timeLeft > 0)
        {
            FindingTimer.timeLeft -= 3;
            Mistakes++;
            Debug.Log("Virhe!");
        }
    }
    //Actions when clicking trash object.
    void click()
    {
        Debug.Log("Roska löydetty");

        //DifferenceManager.RightClicks--;
        ClickRights++;
        Debug.Log("Click rights = " + ClickRights);

        Right = true;

        //Destroy(gameObject);
        Active.SetActive(false);

        GameObject clickedCard = this.gameObject;
        //layerManager = GameObject.Find("LayerManager");
        //layerManager.GetComponent<LayerScript>().ClickAction(clickedCard, (int)x, (int)y); //kun x ja y floatteja, niin edessä oltava sulkeissa int
    }
}