using UnityEngine;
using System.Collections;

public class SafemodeControl : MonoBehaviour
{

    //Sets particlesystems layers
    void Start()
    {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Default";
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = 2;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Death" && other.gameObject.name != "DeathTrigger") || other.gameObject.tag == "Fireball")
        {
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<EllipsoidParticleEmitter>().enabled = true;
            gameObject.GetComponent<ParticleRenderer>().enabled = true;
            
        }
    }


}
