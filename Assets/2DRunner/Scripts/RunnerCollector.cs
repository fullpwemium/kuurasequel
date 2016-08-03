using UnityEngine;
using System.Collections;

public class RunnerCollector : MonoBehaviour {


    public GameObject PFB;
    public bool flyMode;
    GameObject parent;
    public Vector3 thescale;
    public float gravity;
    public bool reverseGravity;
    //public Platformer2DUserControl control;
    void Awake()
    {
        parent = this.gameObject.transform.parent.gameObject;
        thescale = parent.transform.localScale;
        gravity = parent.GetComponent<Rigidbody2D>().gravityScale;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            gameObject.GetComponent<AudioSource>().Play();
            RunnerManager.manager.AddScore();
            other.gameObject.SetActive(false);

        }
        if (other.gameObject.tag == "Area")
        {
            parent.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        if ((other.gameObject.tag == "Death" || other.gameObject.tag == "Fireball" || other.gameObject.tag == "SnowFlasks"))
        {
            GameObject.Find("Background").GetComponent<ScrollScript>().scroll = false;
            RunnerManager.manager.PlayerLose();
        }
        if (other.gameObject.tag == "Finished")
        {
            RunnerManager.manager.PlayerLose();
        }

        if (other.gameObject.tag == "StoneTrigger")
        {
            GameObject.Find("Stone").GetComponent<Rigidbody2D>().gravityScale = 2;
        }
        if (other.gameObject.tag == "SpikeTrigger")
        {
            GameObject.Find("Spike").GetComponent<Animator>().SetTrigger("SpikeTrigger");
        }
        if (other.gameObject.tag == "FireballTrigger")
        {
            GameObject[] fireball;
            fireball = GameObject.FindGameObjectsWithTag("Fireball");
            foreach (GameObject go in fireball)
            {
                go.GetComponent<ConstantForce2D>().enabled = true;
            }
        }
        if (other.gameObject.name == "Ski")
        {
            flyMode = true;
            parent.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            other.transform.SetParent(parent.transform);
            other.transform.localPosition = new Vector2(0f, -0.2f);
        }
        if (other.gameObject.name == "SkiTrigger")
        {

            GameObject ski = GameObject.Find("Ski").gameObject;
            GameObject platform = GameObject.FindGameObjectWithTag("SkiPlatform").gameObject;
            parent.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
            ski.SetActive(false);
            parent.transform.eulerAngles = new Vector3(0, 0, 0);
            ski.transform.SetParent(platform.transform);
            flyMode = false;
        }
        if (other.gameObject.tag == "SwitchGravity")
        {
            parent.GetComponent<Rigidbody2D>().gravityScale *= -1;
            parent.GetComponent<PlatformerCharacter2D>().M_Jumpforce *= -1;
            thescale.y *= -1;
            parent.transform.localScale = thescale;
            other.enabled = false;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Area")
        {
            parent.GetComponent<Rigidbody2D>().gravityScale = gravity;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Stone")
        {
            RunnerManager.manager.PlayerLose();
        }

    }



}
