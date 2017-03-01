using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToyControl : MonoBehaviour {

    //HappinessController hc1;
    GameObject toy;
    float x;
    float y;
    //float LockedYPosition;
    //Vector3 screenPoint;
    Vector3 offset;
    Vector2 startPos;
    GameObject AmountofToys;
    //GameObject thetoy;
    GameObject cattoy;
    bool reset=true;
    private int happinessMultiplier = HappinessController.happinessMultiplier;
    //Sprite Feedable;
    //Sprite Feedable2;
    //private bool feedable = HappinessController.feedable;
    // Use this for initialization
    void Start ()
    {
        //Feedable = GameObject.Find("CatHappiness").GetComponent<HappinessController>().hap2;
        //Feedable2 = GameObject.Find("CatHappiness").GetComponent<HappinessController>().hap3;
        cattoy = gameObject;
        startPos = new Vector2(-1.4f, 3.15f);
        AmountofToys = GameObject.Find("AmountofToys");
        AmountofToys.GetComponent<Text>().text = ItemControl.amountofToys.ToString();
        if (happinessMultiplier != 2 )
        {
            GetComponent<SpriteRenderer>().enabled = false;
            AmountofToys.GetComponent<Text>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        happinessMultiplier = HappinessController.happinessMultiplier;
        //feedable = HappinessController.feedable;
        //Shows when the cat is feedable
        if (happinessMultiplier == 2)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            AmountofToys.GetComponent<Text>().enabled = true;
        }
        //Shows when the cat is not feedable
        else if (happinessMultiplier != 2)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            AmountofToys.GetComponent<Text>().enabled = false;
        }
        x = Input.mousePosition.x;
        y = Input.mousePosition.y;
        if (happinessMultiplier == 2)
        {
            reset = false;
            GetComponent<SpriteRenderer>().enabled = true;
            AmountofToys.GetComponent<Text>().enabled = true;
        }
        else if (happinessMultiplier != 2)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            reset = true;
            AmountofToys.GetComponent<Text>().enabled = false;
        }
       
        if (ItemControl.amountofToys < 1)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            reset = true;
            AmountofToys.GetComponent<Text>().enabled = false;
        }
        AmountofToys.GetComponent<Text>().text = ItemControl.amountofToys.ToString();
    }

    void OnMouseDown()
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.bookOpen, 1);
        //screenPoint = Camera.main.ScreenToWorldPoint(gameObject.transform.position);
        //LockedYPosition = screenPoint.y;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        transform.position = Camera.main.ScreenToViewportPoint(new Vector2(x, y));
        AmountofToys.GetComponent<Text>().enabled = true;        
    }

    //Enables the dragging of the toy
    void OnMouseDrag()
    {
        if (reset == false)
        {           
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }

    //Checks if the Happiness meter is triggered and if it is then the cat will be happier
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "HappinessMeter")
        {
            MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.catHeadCollected, 1);
            //thetoy = GameObject.Find("CatHappiness");
            //hc1 = GetComponent<HappinessController>();
            Debug.Log("Cat is eating now");
            reset = true;
            transform.position = startPos;
            AmountofToys.GetComponent<Text>().enabled = true;
            AmountofToys.GetComponent<Text>().text = ItemControl.amountofToys.ToString();
            Instantiate(cattoy, new Vector2(-1.4f, 3.15f), Quaternion.identity);
            Destroy(gameObject);
            GameObject.Find("ItemController").GetComponent<ItemControl>().LoseBall(1);
            GameObject.Find("CatHappiness").GetComponent<HappinessController>().CatPlayed();
            PlayerPrefs.SetInt("LastMood", 3);
        }
    }

    //On mouse up moves the toy to it's starting position
    void OnMouseUp()
    {
        transform.position = startPos;
    }
}
