using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class HappinessController : MonoBehaviour {

   // FoodAndToyControl fatc1;
    HungerControl hc1;    
    public static int counter;
    static TimeSpan hungry;
    static System.DateTime startTime;     
    //static Sprite lastsprite;   
    public static int happinessMultiplier = 0;
    public Sprite[] sprites = new Sprite[4];
    static System.DateTime currentTime;
    static System.DateTime fedTime;
    long whenfed;
   // static Sprite currentSprite;
    
    public Scene currentScene;
    public static bool feedable;
    // Use this for initialization
    int changeface;

    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("LastMood"));
        feedable = true;
        DontDestroyOnLoad(gameObject);
        //makes currentsprite equal to the last sprite of the cat
        //currentSprite = sprites[PlayerPrefs.GetInt("LastMood")];
        happinessMultiplier = PlayerPrefs.GetInt("LastMood");
        startTime = HungerControl.currenttime;
        hc1 = GetComponent<HungerControl>();
        
       
        //adding sprites which swap whenever the cats mood changes
        counter = PlayerPrefs.GetInt("counter");

        if (counter == 0)
        {
            Debug.Log("counter" + counter + " " + System.DateTime.Now);
            CatFed();
            ChangeMood(2);         
            counter++;
            PlayerPrefs.SetInt("counter", counter);
            //GetComponent<SpriteRenderer>().sprite = currentSprite;
            PlayerPrefs.SetInt("LastMood", 2);
        }

        //currentSprite = sprites[PlayerPrefs.GetInt("LastMood")];
        whenfed = Convert.ToInt64(PlayerPrefs.GetString("WhenFed"));
        fedTime = DateTime.FromBinary(whenfed);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(happinessMultiplier);

        if (happinessMultiplier == 3)
        {
            feedable = false;
        }
        else
        {
            feedable = true;
        }
        

        //checks if active scene is bobsapartment scene.
        /*if (bobApartmentScene == currentScene)
        {
            gameObject.SetActive(true);
        }
        else if (bobApartmentScene != currentScene)
        {
            gameObject.SetActive(false);
        }*/

        //GetComponent<SpriteRenderer>().sprite = currentSprite;
        currentTime = HungerControl.newtime;
        hungry = currentTime - fedTime;
        TimeSpan escalate = startTime - currentTime;

        //checks if there is no sprite loaded, then uses the last sprite
        /*
        if (GetComponent<SpriteRenderer>().sprite == null)
        {
            Debug.Log("No sprite");
            GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("LastMood")];
            currentSprite = sprites[PlayerPrefs.GetInt("LastMood")];
            GetComponent<SpriteRenderer>().sprite = currentSprite;
            Debug.Log("current sprite " + currentSprite);
        }
        */

        //checks the current mood and compares it to a specific sprite then changes the mood if the other conditions are also met
        if (happinessMultiplier == 3 && fedTime.AddHours(2) <= currentTime)
        {
            Debug.Log("current time is " + currentTime);
            Debug.Log("fedtime" + fedTime.AddHours(2));
            ChangeMood(2);
            LastFed(currentTime);
            print("it has been " + hungry.ToString() + " since you last fed the cat, cat is happy " + System.DateTime.Now);
        }
        else if (happinessMultiplier == 2 && fedTime.AddHours(6) <= currentTime)
        {
            Debug.Log("current time is " + currentTime);
            Debug.Log("fedtime" + fedTime.AddHours(6));
            
            ChangeMood(1);
            LastFed(currentTime);
            print("it has been " + hungry.ToString() + " since you last fed the cat, cat is ok " + System.DateTime.Now);
        }
        else if(happinessMultiplier == 1 && fedTime.AddHours(7) <= currentTime)
        {
            Debug.Log("current time is " + currentTime);
            Debug.Log("fedtime" + fedTime.AddHours(7));
            ChangeMood(0);
            LastFed(currentTime);
            print("it has been " + hungry.ToString() + " since you last fed the cat, cat is sad " + System.DateTime.Now);
        }

        //Changes the happiness multiplier depending the mood of the cat
        /*
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
        */
    }

    //saves the time from when the cat was last fed
    void LastFed(System.DateTime _hours)
    {
        System.DateTime currentTime = System.DateTime.Now; 
        print("it has been " + hungry.ToString() + " since you last fed the cat " + System.DateTime.Now);       
    }

    public void CatFed()
    {
        //feeds the cat
        Debug.Log("cat has been fed "+ System.DateTime.Now);
        fedTime = System.DateTime.Now;
        PlayerPrefs.SetString("WhenFed", System.DateTime.Now.ToBinary().ToString());
        happinessMultiplier = 2;
        //PlayerPrefs.SetInt("LastMood", happinessMultiplier);
        /*counter = 0;
        PlayerPrefs.SetInt("counter", counter);*/

    }
   
    public void OnApplicationQuit()
    {
        //When the application goes off, the last mood will be saved to the hard drive
        PlayerPrefs.SetInt("LastMood", happinessMultiplier);
        Debug.Log("Cats mood has been saved now " + happinessMultiplier);
    }
     
    void OnDisable()
    {       
        //When the cats mood face is disabled, the last mood will be saved to the hard drive
        //GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("LastMood")];      
        int number = PlayerPrefs.GetInt("LastMood");
        PlayerPrefs.SetInt("LastMood", number);
        Debug.Log("Saved " + number + " " + System.DateTime.Now);
    }

    void OnEnable()
    {
        Debug.Log("Whenfed is " + PlayerPrefs.GetInt("WhenFed"));
        fedTime.AddHours(PlayerPrefs.GetInt("WhenFed"));
        Debug.Log("Whenfed is " + PlayerPrefs.GetInt("WhenFed"));

        //When the cats mood face is enabled, the last mood will be loaded from the hard drive
        //GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("LastMood")];
        //int number = PlayerPrefs.GetInt("LastMood");
        //Debug.Log("loaded" + number + " " + System.DateTime.Now);
    }

    public void ChangeMood(int number)
    {
        //changes the mood of the cat and saves it to the hard drive
        Debug.Log("Cats mood has been changed "+ number + " " + System.DateTime.Now);
        fedTime = System.DateTime.Now;
        happinessMultiplier = number;
        PlayerPrefs.SetString("WhenFed", System.DateTime.Now.ToBinary().ToString());
        PlayerPrefs.SetInt("LastMood", happinessMultiplier);
        Debug.Log(PlayerPrefs.GetInt("LastMood"));
    }

    public void CatPlayed()
    {   
        Debug.Log("cat has been played with " + System.DateTime.Now);
        fedTime = System.DateTime.Now;
        happinessMultiplier = 3;
        feedable = false;
        PlayerPrefs.SetString("WhenFed", System.DateTime.Now.ToBinary().ToString());
        PlayerPrefs.SetInt("LastMood", happinessMultiplier);
        Debug.Log(PlayerPrefs.GetInt("LastMood"));
    }
}
