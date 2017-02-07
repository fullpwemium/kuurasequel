using UnityEngine;
using System.Collections;

public class KissaPetClickExit : MonoBehaviour {
	public GameObject pet2;
	public GameObject pet1;
    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            pet1.SetActive(true);
            pet2.SetActive(false);
 
        }
	}
	void OnMouseExit()
    {
        pet1.SetActive(true);
        pet2.SetActive(false);

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pet1.SetActive(true);
            pet2.SetActive(false);
        }
    }
}
