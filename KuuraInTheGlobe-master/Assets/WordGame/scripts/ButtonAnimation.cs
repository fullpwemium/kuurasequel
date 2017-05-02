using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour {

    private float timeLeft;             //determines the intervals when the wiggling animation will be played
    private Animator anim;              //reference to the animator

    /**
     * Initializes the animator and the first wiggle timer.
     */
    private void Start()
    {
        anim = GetComponent<Animator>();
        timeLeft = Random.Range(4.0f, 7.5f);
    }

    // Update is called once per frame
    /**
     * Counts from the timeLeft down to 0. When the timer reaches 0, the button will wiggle.
     */
    void Update(){
       
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            changeState();
        }
    }

    /**
     * Generates a new animation timer between 2 random floats and triggers the animations itself.
     */
    private void changeState()
    {
        timeLeft = Random.Range(6.5f, 20.5f);           //refresh the timer once again
        anim.SetTrigger("animWiggle");
    }
}
