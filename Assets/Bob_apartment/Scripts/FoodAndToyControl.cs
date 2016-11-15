using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FoodAndToyControl : MonoBehaviour {

    HappinessController hc1;
    GameObject food;

    float LockedYPosition;
    Vector3 screenPoint;
    Vector3 offset;

    float x;
    float y;
    bool reset = true;
    Vector2 startPos;

    GameObject AmountofFood;
    GameObject thefood;

    public int foodamount = ItemControl.amountofFood;
    int happiness;
    //Sprite Feedable2;
    private bool feedable = HappinessController.feedable;
    // Use this for initialization
    void Start()
    {
        //Feedable2 = GameObject.Find("CatHappiness").GetComponent<HappinessController>().hap3;
        food = gameObject;
        AmountofFood = GameObject.Find("AmountofFood");
        startPos = new Vector2(-3, 3.15f);
        AmountofFood.GetComponent<Text>().text = ItemControl.amountofFood.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        feedable = HappinessController.feedable;
    //Feedable2 = GameObject.Find("CatHappiness").GetComponent<HappinessController>().hap3;
        x = Input.mousePosition.x;
        y = Input.mousePosition.y;

        //Checks if the player has more than 0 food and then also checks if the cat is hungry
        if (ItemControl.amountofFood > 0 && HappinessController.feedable == true)
        {
            reset = false;
            GetComponent<SpriteRenderer>().enabled = true;
            AmountofFood.GetComponent<Text>().enabled = true;
        }
        else if (ItemControl.amountofFood < 1 || HappinessController.feedable == true)
        {
            //the cats food sprite disappears if the amount of food is 0 or the cat isn't hungry
            GetComponent<SpriteRenderer>().enabled = false;
            reset = true;
            AmountofFood.GetComponent<Text>().enabled = false;
        }

        if(ItemControl.amountofFood > 0 && HappinessController.feedable == true)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            AmountofFood.GetComponent<Text>().enabled = true;
        }

        AmountofFood.GetComponent<Text>().text = ItemControl.amountofFood.ToString();
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.ScreenToWorldPoint(gameObject.transform.position);
        LockedYPosition = screenPoint.y;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        transform.position = Camera.main.ScreenToViewportPoint(new Vector2(x,y));
        AmountofFood.GetComponent<Text>().enabled = true;
    }

    //Enables the dragging of the food
    void OnMouseDrag()
    {
        if (reset == false)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
       
    }

    //Checks if the Happiness meter is triggered and if it is then the cat will be fed
    void OnTriggerStay2D(Collider2D other)
    {    
        if (other.gameObject.tag == "HappinessMeter")
        {
            thefood = GameObject.Find("CatHappiness");
            hc1 = GetComponent<HappinessController>();
            Debug.Log("Cat is eating now");
            reset = true;
            transform.position = startPos;
            AmountofFood.GetComponent<Text>().enabled = true;
            AmountofFood.GetComponent<Text>().text = ItemControl.amountofFood.ToString();
            Instantiate(food, new Vector2 (-3,3.15f),Quaternion.identity);
            Destroy(gameObject);
            GameObject.Find("ItemController").GetComponent<ItemControl>().LoseFood(1);
            GameObject.Find("CatHappiness").GetComponent<HappinessController>().CatFed();
            other.gameObject.GetComponent<HappinessController>().ChangeMood(2);
            PlayerPrefs.SetInt("LastMood", 2);
        }
    }

    //on mouse up moves the food to it's starting position
    void OnMouseUp()
    {
        transform.position = startPos;
    }  
}