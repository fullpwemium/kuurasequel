using UnityEngine;
using System.Collections;

public class CatReaction : MonoBehaviour {
	public GameObject dustAmount;
	private int dustAddition=1; //amount of dust added per tick
    public AudioClip purring;
    DustController sc1;

    void Start() {
        sc1 = dustAmount.GetComponent<DustController>();
    }

	void OnMouseDown() {
        //Replace with petting animation
		Debug.Log("Cat clicked");
		GetComponent<Animator>().Play ("Sit");
        GetComponent<AudioSource>().PlayOneShot(purring);
        //addDust (dustAddition); 
        StartCoroutine(AddDust());

	}
	void OnMouseUp()
    {
        Debug.Log("Petting ended");
        GetComponent<AudioSource>().Stop();
        //pressed = false;
        StopAllCoroutines();
    }

    IEnumerator AddDust()
    {
        while(true) {
            yield return new WaitForSeconds(1); //amount of seconds to add dustAmount
            sc1.GetDust(dustAddition); //Calls function in DustController to add dust
            sc1.UpdateDust();
        }
    }
    
}
