using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpriteControl : MonoBehaviour {

    private int happinessMultiplier = HappinessController.happinessMultiplier;
    //Sprite currentsprite;
    public Sprite[] sprites = new Sprite[4];
    public Scene bobApartmentScene;
    public Scene currentScene;
    // Use this for initialization
    void Start ()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("LastMood")];
        bobApartmentScene = SceneManager.GetActiveScene();
    }
	
	// Update is called once per frame
	void Update () 
    {
        happinessMultiplier = HappinessController.happinessMultiplier;
        GetComponent<SpriteRenderer>().sprite = sprites[happinessMultiplier];
        currentScene = SceneManager.GetActiveScene();

        if (bobApartmentScene == currentScene)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (bobApartmentScene != currentScene)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
