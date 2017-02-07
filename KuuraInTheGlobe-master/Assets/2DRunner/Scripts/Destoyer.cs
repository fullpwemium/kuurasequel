using UnityEngine;
using System.Collections;

public class Destoyer : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Stone")
        {
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Fireball")
        {
            other.gameObject.SetActive(false);
        }

    }
}