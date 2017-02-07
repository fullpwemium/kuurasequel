using UnityEngine;
using System.Collections;

public class SkiCollector : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Coin")
        {
            RunnerManager.manager.AddScore();
            c.gameObject.SetActive(false);
            GameObject.Find("Collider").gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
