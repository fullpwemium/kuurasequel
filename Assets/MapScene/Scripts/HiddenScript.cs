using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HiddenScript : MonoBehaviour {

    bool hidden = true;
    GameObject piiloNappi;
    GameObject puska;
    
    Button Button;

	// Use this for initialization
	void Start () {
        piiloNappi = GameObject.Find("Tile-11");
        puska = GameObject.Find("Puska");

        Button = GameObject.Find("Puska").GetComponent<Button>();

        Button.onClick.AddListener(() => puskaToggle());
    }
	
	// Update is called once per frame
	void Update () {

        if (checkBobPosition() == false)
        {
            hidden = true;
           
        }

        HiddenMethod();
        //if (hidden == false)
        //{
        //    piiloNappi.SetActive(true);
        //    //hidden = true;
        //    Debug.Log("on");
        //}
        //else if(hidden == true)
        //{
        //    piiloNappi.SetActive(false);
        //    //hidden = false;
        //    Debug.Log("off");
        //}
    }

    void puskaToggle()
    {
        if(hidden)
        {
            hidden = false;
        }
        else if(hidden == false)
        {
            hidden = true;
        }
    }

    public bool checkBobPosition()
    {
        if (BobPlayerScript.StandingButtonNumberX == 0 && BobPlayerScript.StandingButtonNumberY == 1 || BobPlayerScript.StandingButtonNumberX == -1 && BobPlayerScript.StandingButtonNumberY == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void HiddenMethod()
    {
        if (BobPlayerScript.StandingButtonNumberX == -1 && BobPlayerScript.StandingButtonNumberY == 1)
        {
            hidden = false;
        }

        if(hidden)
        {
            piiloNappi.SetActive(false);
            puska.SetActive(true);
        }
        else if(hidden == false)
        {
            piiloNappi.SetActive(true);
            puska.SetActive(false);   
        }
    }
}
