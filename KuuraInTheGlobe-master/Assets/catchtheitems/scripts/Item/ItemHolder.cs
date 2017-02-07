using UnityEngine;
using System.Collections;

public class ItemHolder : MonoBehaviour {

	Animator anim;
	private DropItem drop;
	private PowerUpSpeedScript dropSpeed;
    private AudioSource bubbleBurst;

	// Use this for initialization
	void Start () {
        bubbleBurst = GetComponent<AudioSource>();
		anim = GetComponent<Animator> ();
		drop = GetComponentInChildren<DropItem> ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Cat") 
		{
            if (!bubbleBurst.isPlaying)
            {
                bubbleBurst.Play();
            }

            drop.WaitActivate ();
			anim.SetBool ("boom", true);

		}
        
			
	}

	void DestroyObject()
	{
		Destroy (gameObject);
    }
}
