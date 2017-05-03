using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifLevelObjects : MonoBehaviour
{
    public static DifLevelObjects DLO;

    public GameObject original, bottom;
    public GameObject roska01, roska02, roska03, roska04, roska05, roska11, roska12, roska13, roska14, roska15;

    public Sprite painting1, painting2;

    public static int levelNumber;

    // Use this for initialization
    void Start ()
    {
        //original = GameObject.Find("Original");
        //bottom = GameObject.Find("Bottom");

        //Defines painting and trash objects by chosen level
        if (levelNumber == 0)
        {
            Debug.Log("Ladataan objektit 1");

            //original.GetComponent<SpriteRenderer>().sprite = Resources.Load("muotokuva_oikea", typeof(Sprite)) as Sprite;
            //bottom.GetComponent<SpriteRenderer>().sprite = Resources.Load("muotokuva_oikea", typeof(Sprite)) as Sprite;
            original.GetComponent<SpriteRenderer>().sprite = painting1;
            bottom.GetComponent<SpriteRenderer>().sprite = painting1;

            roska01.SetActive(true);
            roska02.SetActive(true);
            roska03.SetActive(true);
            roska04.SetActive(true);
            roska05.SetActive(true);

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

            roska11.SetActive(true);
            roska12.SetActive(true);
            roska13.SetActive(true);
            roska14.SetActive(true);
            roska15.SetActive(true);
        }
        else if (levelNumber == 2)
        {
            Debug.Log("Ladataan objektit 3");


        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
