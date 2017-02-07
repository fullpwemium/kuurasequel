using UnityEngine;
using System.Collections;

public class BreakingFloor : MonoBehaviour
{
    bool floor = true;
    Animator anim;
    Collider2D col;
    Collision coll;
	public GameObject tryagain;
	public GameObject BlackScreen;
	public GameObject confuseimg;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("Hello");
            StartCoroutine(BreakFloor());
             
            //animation.Play("Collapse");
            
            if (floor == false)
            {
				tryagain.SetActive (true);
				BlackScreen.SetActive (true);
				confuseimg.SetActive(true);
				Time.timeScale = 0;
            }
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && floor == false)
        {
            Debug.Log("Apua");
            tryagain.SetActive(true);
            BlackScreen.SetActive(true);
            confuseimg.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public IEnumerator BreakFloor()
    {
        anim.SetBool("Break", true);
        yield return new WaitForSeconds(2f);
        //Debug.Log("pleb");
        floor = false;
        //anim.SetBool("Break", true);
        //Invoke("BreakFloor", anim.GetNextAnimatorStateInfo(0).length + 0.5f);
    }
}
