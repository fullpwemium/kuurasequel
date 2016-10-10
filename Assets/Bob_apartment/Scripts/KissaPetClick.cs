using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KissaPetClick : MonoBehaviour {

	public GameObject pet2;
	public GameObject pet1;
    public GameObject exitButton;
    public GameObject magicDust;
    public GameObject dustAmount;
    //public GameObject food;
    //public GameObject happiness;
    //public Text text;

	// Use this for initialization
	void Start ()
    {
        //food = GameObject.Find("Food");
        DustController sc1 = dustAmount.GetComponent<DustController>();
        //food.SetActive(false);
        //happiness.SetActive(false);
        //text.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //food.SetActive(false);
        //happiness.SetActive(false);
        //text.enabled = false;
    }
	void OnMouseOver() {
        if (Input.GetMouseButtonDown(0))
        {
            pet1.SetActive(false);
            pet2.SetActive(true);
            exitButton.SetActive(false);
            magicDust.SetActive(true);
            //food.SetActive(false);
            //happiness.SetActive(false);
            //text.enabled = false;
            //pet2.GetComponent<EmitterController>().CancelInvoke();
        }
	}

}
