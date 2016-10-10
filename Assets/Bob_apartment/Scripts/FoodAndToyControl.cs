using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FoodAndToyControl : MonoBehaviour {

    GameObject food;
    float LockedYPosition;
    Vector3 screenPoint;
    Vector3 offset;
    float x;
    float y;
    bool reset = true;
    Vector2 startPos;
    GameObject AmountofFood;
   public int foodamount = ItemControl.amountofFood;
    // Use this for initialization
    void Start()
    {
        food = gameObject;
        AmountofFood = GameObject.Find("AmountofFood");
        startPos = new Vector2(-3, 3.15f);
        AmountofFood.GetComponent<Text>().text = ItemControl.amountofFood.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.mousePosition.x;
        y = Input.mousePosition.y;
        if (ItemControl.amountofFood > 0)
        {
            reset = false;
            GetComponent<SpriteRenderer>().enabled = true;           
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            reset = true;
            AmountofFood.GetComponent<Text>().enabled = false;
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

    void OnMouseDrag()
    {
        if (reset == false)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
       
    }
    void OnTriggerStay2D(Collider2D other)
    {
      
        if (other.gameObject.tag == "HappinessMeter")
        {   
            Debug.Log("Cat is eating now");
            other.gameObject.GetComponent<HappinessController>().ChangeMood(2);
            reset = true;
            transform.position = startPos;
            AmountofFood.GetComponent<Text>().enabled = true;
            AmountofFood.GetComponent<Text>().text = ItemControl.amountofFood.ToString();
            Instantiate(food, new Vector2 (-3,3.15f),Quaternion.identity);
                Destroy(gameObject);
            ItemControl.amountofFood--;
        }
    }    
}
