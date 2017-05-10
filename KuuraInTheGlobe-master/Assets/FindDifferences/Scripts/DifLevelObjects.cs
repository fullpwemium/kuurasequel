using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifLevelObjects : MonoBehaviour
{
    public static DifLevelObjects DLO;

    //-----------------------------------------------
    //Objects and object lists in each level
    public GameObject original, bottom;
    //public GameObject roska01, roska02, roska03, roska04, roska05, roska11, roska12, roska13, roska14, roska15;
    public List<GameObject> roskat1, roskat2, roskat3, roskat4, roskat5;
    public List<GameObject> oikeat3, oikeat4;

    public Sprite painting1, painting2, painting3, painting4, painting5;
    public Sprite editablePaintingSprite3, editablePaintingSprite4;
    //-----------------------------------------------

    public static int levelNumber;

    // Use this for initialization
    void Start ()
    {
        //original = GameObject.Find("Original");
        //bottom = GameObject.Find("Bottom");

        //------------------------------------------------------------------------
        //Defines painting and trash objects by chosen level (0-->)
        if (levelNumber == 0)
        {
            Debug.Log("Ladataan objektit 1");

            //original.GetComponent<SpriteRenderer>().sprite = Resources.Load("muotokuva_oikea", typeof(Sprite)) as Sprite;
            //bottom.GetComponent<SpriteRenderer>().sprite = Resources.Load("muotokuva_oikea", typeof(Sprite)) as Sprite;
            original.GetComponent<SpriteRenderer>().sprite = painting1;
            bottom.GetComponent<SpriteRenderer>().sprite = painting1;

            //roska01.SetActive(true);
            //roska02.SetActive(true);
            //roska03.SetActive(true);
            //roska04.SetActive(true);
            //roska05.SetActive(true);

            roskat1[0].SetActive(true);
            roskat1[1].SetActive(true);
            roskat1[2].SetActive(true);
            roskat1[3].SetActive(true);
            roskat1[4].SetActive(true);

            //roska1 = GameObject.Find("Roska1");
            //roska2 = GameObject.Find("Roska2");
            //roska3 = GameObject.Find("Roska3");
            //roska4 = GameObject.Find("Roska4");
            //roska5 = GameObject.Find("Roska5");
        }
        else if (levelNumber == 1)
        {
            Debug.Log("Ladataan objektit 2");

            original.GetComponent<SpriteRenderer>().sprite = painting2;
            bottom.GetComponent<SpriteRenderer>().sprite = painting2;

            //roska11.SetActive(true);
            //roska12.SetActive(true);
            //roska13.SetActive(true);
            //roska14.SetActive(true);
            //roska15.SetActive(true);

            roskat2[0].SetActive(true);
            roskat2[1].SetActive(true);
            roskat2[2].SetActive(true);
            roskat2[3].SetActive(true);
            roskat2[4].SetActive(true);
        }
        else if (levelNumber == 2)
        {
            Debug.Log("Ladataan objektit 3");

            original.GetComponent<SpriteRenderer>().sprite = painting3;
            bottom.GetComponent<SpriteRenderer>().sprite = editablePaintingSprite3;

            roskat3[0].SetActive(true);
            roskat3[1].SetActive(true);
            roskat3[2].SetActive(true);
            roskat3[3].SetActive(true);
            //roskat3[4].SetActive(true);
        }
        else if (levelNumber == 3)
        {
            Debug.Log("Ladataan objektit 3");

            original.GetComponent<SpriteRenderer>().sprite = painting4;
            bottom.GetComponent<SpriteRenderer>().sprite = editablePaintingSprite4;

            roskat4[0].SetActive(true);
            roskat4[1].SetActive(true);
            roskat4[2].SetActive(true);
            roskat4[3].SetActive(true);
            roskat4[4].SetActive(true);
        }
        //------------------------------------------------------------------------
    }

    // Update is called once per frame
    void Update ()
    {
        if (levelNumber == 2 || levelNumber == 3)
        {
            Replace();
        }
    }

    //If needs to replace wrong object to right object, for example in third level.     --> Update()
    public void Replace()
    {
        if (levelNumber == 2)
        {
            if (roskat3[0].activeInHierarchy == false)      //Check if GameObject is unactive.
            {
                oikeat3[0].SetActive(true);
                Debug.Log("roskat3[0] --> oikeat3[0]");
            }
            if (roskat3[1].activeInHierarchy == false)
            {
                oikeat3[1].SetActive(true);
                Debug.Log("roskat3[1] --> oikeat3[1]");
            }
            if (roskat3[2].activeInHierarchy == false)
            {
                oikeat3[2].SetActive(true);
                Debug.Log("roskat3[2] --> oikeat3[2]");
            }
        }
        if (levelNumber == 3)
        {
            if (roskat4[1].activeInHierarchy == false)      //Check if GameObject is unactive.
            {
                oikeat4[0].SetActive(true);
                Debug.Log("roskat4[2] --> oikeat4[0]");
            }
            if (roskat4[2].activeInHierarchy == false)
            {
                oikeat4[1].SetActive(true);
                Debug.Log("roskat4[3] --> oikeat4[1]");
            }
        }
    }
}
