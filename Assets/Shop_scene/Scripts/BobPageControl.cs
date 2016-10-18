using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BobPageControl : MonoBehaviour {

    public bool ownsGreyHat;
    public bool ownsOrangeHat;
    public bool ownsRedHat;
    public bool ownsGreenHat;
    public bool ownsWhiteHat;

    public Image greyHat;
    public Image orangeHat;
    public Image redHat;
    public Image greenHat;
    public Image whiteHat;


    void Awake()
    {
        greyHat.enabled = false;
        orangeHat.enabled = false;
        redHat.enabled = false;
        greenHat.enabled = false;
        whiteHat.enabled = false;

        ownsGreyHat = false;
        ownsOrangeHat = false;
        ownsRedHat = false;
        ownsGreenHat = false;
        ownsWhiteHat = false;
    }
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (ownsGreyHat == true)
        {
            greyHat.enabled = true;
        }
	}
}
