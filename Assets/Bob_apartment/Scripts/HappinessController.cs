using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class HappinessController : MonoBehaviour {

    FoodAndToyControl fatc1;
    HungerControl hc1;    
    public Sprite hap0;
    public Sprite hap1;
    public Sprite hap2;
    public Sprite hap3;
    public static int counter;
   static TimeSpan hungry;
   static System.DateTime startTime;     
    static Sprite lastsprite;   
    public static int happinessMultiplier;
    public Sprite[] sprites = new Sprite[4];
   static System.DateTime datevalue2;
   static System.DateTime fedTime;
   static Sprite currentSprite;
    Scene activeScene;
    Scene currentScene;
    // Use this for initialization

    void Start()
    {
        //makes currentsprite equal to the last sprite of the cat
        currentSprite = sprites[PlayerPrefs.GetInt("LastMood")];       
        startTime = HungerControl.currenttime;
        hc1 = GetComponent<HungerControl>();
        activeScene = SceneManager.GetActiveScene();

        //adding sprites which swap whenever the cats mood changes
        sprites[0] = hap0;
        sprites[1] = hap1;
        sprites[2] = hap2;
        sprites[3] = hap3;
        counter = PlayerPrefs.GetInt("counter");
            
        if (counter == 0)
        {
            Debug.Log("counter" + counter + " " + System.DateTime.Now);
            CatFed();
            currentSprite = sprites[PlayerPrefs.GetInt("LastMood")];         
            counter++;
            PlayerPrefs.SetInt("counter", counter);
            GetComponent<SpriteRenderer>().sprite = currentSprite;
        }
        fedTime.AddSeconds(PlayerPrefs.GetInt("WhenFed"));
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();

        //checks if active scene is bobsapartment scene.
        if (activeScene == currentScene)
        {
            gameObject.SetActive(true);
        }
        else if (activeScene != currentScene)
        {
            gameObject.SetActive(false);
        }
        GetComponent<SpriteRenderer>().sprite = currentSprite;
        datevalue2 = HungerControl.newtime;
        hungry = datevalue2 - fedTime;
        TimeSpan escalate = startTime - datevalue2;

        //checks if there is no sprite loaded, then uses the last sprite
        if (GetComponent<SpriteRenderer>().sprite == null)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("LastMood")];
            currentSprite = sprites[PlayerPrefs.GetInt("LastMood")];
            GetComponent<SpriteRenderer>().sprite = currentSprite;
        }

        //checks the current mood and compares it to a specific sprite then changes the mood if the other conditions are also met
        if (currentSprite == sprites[3] && fedTime.AddMinutes(5) <= datevalue2)
        {
            ChangeMood(2);
            LastFed(datevalue2);
            print("it has been " + hungry.ToString() + " since you last fed the cat, cat is happy " + System.DateTime.Now);
        }
        else if (currentSprite == sprites[2] && fedTime.AddMinutes(5.5) <= datevalue2 && startTime.AddMinutes(1) < datevalue2)
        {
            ChangeMood(1);
            LastFed(datevalue2);
            print("it has been " + hungry.ToString() + " since you last fed the cat, cat is ok " + System.DateTime.Now);         
        }
       else if(currentSprite == sprites[1] && fedTime.AddMinutes(6) <= datevalue2 && startTime.AddMinutes(1) < datevalue2)
        {
            ChangeMood(0);
            LastFed(datevalue2);
            print("it has been " + hungry.ToString() + " since you last fed the cat, cat is sad " + System.DateTime.Now);
        }

        //Changes the happiness multiplier depending the mood of the cat
        if (currentSprite == sprites[3])
        {
            happinessMultiplier = 3;
        }
        else if (currentSprite == sprites[2])
        {
            happinessMultiplier = 2;
        }
        else if (currentSprite == sprites[1])
        {
            happinessMultiplier = 1;
        }
        else if (currentSprite == sprites[0])
        {
            happinessMultiplier = 0;
        }

        if (lastsprite != currentSprite)
        {
            lastsprite = currentSprite;            
        }

    }

    //saves the time from when the cat was last fed
    void LastFed(System.DateTime _hours)
    {
        System.DateTime currentTime = System.DateTime.Now; 
        print("it has been " + hungry.ToString() + " since you last fed the cat " +System.DateTime.Now);       
    }

    public void CatFed()
    {
        //feeds the cat
        Debug.Log("cat has been fed "+ System.DateTime.Now);
        fedTime = System.DateTime.Now;
        int whenfed = fedTime.Second;
        PlayerPrefs.SetInt("WhenFed", whenfed);
        currentSprite = sprites[2];
        counter = 0;
        PlayerPrefs.SetInt("counter", counter);
    }
   
    public void OnApplicationQuit()
    {
        //When the application goes off, the last mood will be saved to the hard drive
        currentSprite = lastsprite;         
        int number = PlayerPrefs.GetInt("LastMood");
        PlayerPrefs.SetInt("LastMood", number);
        Debug.Log("Cats mood has been saved now " + number);
    }
     
    void OnDisable()
    {       
        //When the cats mood face is disabled, the last mood will be saved to the hard drive
        GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("LastMood")];      
        int number = PlayerPrefs.GetInt("LastMood");
        PlayerPrefs.SetInt("LastMood", number);
        Debug.Log("Saved " + number + " " + System.DateTime.Now);
    }

    void OnEnable()
    {
        //When the cats mood face is enabled, the last mood will be loaded from the hard drive
        GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("LastMood")];
        int number = PlayerPrefs.GetInt("LastMood");
        Debug.Log("loaded" + number + " " + System.DateTime.Now);
    }

    public void ChangeMood(int number)
    {
        //changes the mood of the cat and saves it to the hard drive
        currentSprite = sprites[number];
        lastsprite = sprites[number];
        lastsprite = GetComponent<SpriteRenderer>().sprite;
        Debug.Log("Cats mood has been changed "+ number + " " + System.DateTime.Now);
        GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("LastMood")];
        PlayerPrefs.SetInt("LastMood", number);
        GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("LastMood")];
    }

    public void CatPlayed()
    {
        if (currentSprite == hap2)
        {
            Debug.Log("cat has been played with " + System.DateTime.Now);
            fedTime = System.DateTime.Now;
            currentSprite = sprites[3];
            int whenfed = fedTime.Second;
            PlayerPrefs.SetInt("WhenFed", whenfed);
            PlayerPrefs.SetInt("LastMood", 3);
            counter = 0;
            PlayerPrefs.SetInt("counter", counter);
        }
    }
}
