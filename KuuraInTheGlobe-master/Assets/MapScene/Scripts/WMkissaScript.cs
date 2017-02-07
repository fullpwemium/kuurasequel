using UnityEngine;
using System.Collections;

public class WMkissaScript : MonoBehaviour {

    int i;
    bool goingup = true;
	// Use this for initialization
	void Start () {
        i = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
        if(goingup)
        {
            i++;
            Debug.Log("going up" + i);
            gameObject.transform.localScale += new Vector3(0, gameObject.transform.position.y * 0.005f, 0);
            if(i>= 60)
            {
                goingup = false;
            }

        }
        else if(goingup == false)
        {
            i--;
            Debug.Log("going down" + i);
            gameObject.transform.localScale += new Vector3(0, gameObject.transform.position.y * -0.005f, 0);
            if (i <= 0)
            {
                goingup = true;
            }
        }
	
	}
}
