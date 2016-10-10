using UnityEngine;
using System.Collections;
using System;

public class HappinessController : MonoBehaviour {

    public Sprite hap0;
    public Sprite hap1;
    public Sprite hap2;
    public Sprite hap3;
    TimeSpan hungry;
    System.DateTime startTime;     
    Sprite lastsprite;   
    public static int happinessMultiplier;
    public Sprite[] sprites = new Sprite[4];
    System.DateTime datevalue2;
    System.DateTime fedTime;
    Sprite currentSprite;
    // Use this for initialization
    void Start()
    {
        //DontDestroyOnLoad(this);
        //adding sprites which swap whenever the cats mood changes
        sprites[0] = hap0;
        sprites[1] = hap1;
        sprites[2] = hap2;
        sprites[3] = hap3;
        currentSprite = hap1;
        GetComponent<SpriteRenderer>().sprite = currentSprite;   
        startTime = System.DateTime.Now;
    }
	// Update is called once per frame
	void Update ()
    {
        GetComponent<SpriteRenderer>().sprite = currentSprite;
        datevalue2 = System.DateTime.Now;
        hungry = datevalue2 - fedTime;
        TimeSpan escalate = startTime - datevalue2;     
        //checks the current mood and compares it to a specific sprite then changes the mood if the other conditions are also met
        if (currentSprite == sprites[3] && fedTime.AddMinutes(1) <= datevalue2)
        {
            ChangeMood(2);
            LastFed(datevalue2);
            print("it has been " + hungry.ToString() + " since you last fed the cat, cat is happy");
        }
        else if (currentSprite == sprites[2] && fedTime.AddMinutes(1) <= datevalue2 && startTime.AddMinutes(1) < datevalue2)
        {
            ChangeMood(1);
            LastFed(datevalue2);
            print("it has been " + hungry.ToString() + " since you last fed the cat, cat is ok");         
        }
       else if(currentSprite == sprites[1] && fedTime.AddMinutes(1) <= datevalue2 && startTime.AddMinutes(2) < datevalue2)
        {
            ChangeMood(0);
            LastFed(datevalue2);
            print("it has been " + hungry.ToString() + " since you last fed the cat, cat is sad");
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
    }
    void LastFed(System.DateTime _hours)
    {
        System.DateTime currentTime = System.DateTime.Now; 
        print("it has been " + hungry.ToString() + " since you last fed the cat");       
    }
    public void CatFed()
    {
        Debug.Log("cat has been fed");
        fedTime = System.DateTime.Now;
        currentSprite = sprites[2];
    }

    public void ChangeMood(int number)
    {
        currentSprite = sprites[number];
        lastsprite = sprites[number];
        lastsprite = GetComponent<SpriteRenderer>().sprite;
    }
    public void OnApplicationQuit()
    {
        currentSprite = lastsprite;
        Debug.Log("Cats mood has been saved now");
    }
  
}
