using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[RequireComponent(typeof(PowerupManager))]
public class PowerUp : MonoBehaviour
{
    public bool doublePoints;
    public Text DoublepointsText;
    public bool safeMode;
    public bool magnet;
    public float powerupLength;
    private PowerupManager manager;
    void Awake()
    {
        //if (GameObject.Find("GameManager"))
        //{
            manager = GameObject.Find("GameManager").GetComponent<PowerupManager>();
        //}
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            manager.ActivatePowerup(doublePoints, safeMode, magnet, powerupLength);
            
            Destroy(gameObject);
        }

    }
}
