using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {

    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {    
	
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.bubbleBurst3, 1);
            anim.SetTrigger("Bounce");
        }
    }
}
