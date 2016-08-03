using UnityEngine;
using System.Collections;

public class PuskaScript : MonoBehaviour {

    HiddenScript HS;
    bool puskaHeilui;
    int i;

	// Use this for initialization
	void Start () {
        HS = GameObject.Find("HiddenScript").GetComponent<HiddenScript>();
        i = 0;
        puskaHeilui = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (HS.checkBobPosition() == true)
        {
            PuskaHeiluu();
        }
        else
        {

        }
	}

    void PuskaHeiluu()
    {
        i++;

        if(puskaHeilui&&i>=20)
        {
            gameObject.transform.localScale += new Vector3(0.05f, 0.05f, 0);
            i = 0;
            puskaHeilui = false;
        }
        else if(puskaHeilui == false && i>=20)
        {
            gameObject.transform.localScale += new Vector3(-0.05f, -0.05f, 0);
            i = 0;
            puskaHeilui = true;
        }
    }
}
