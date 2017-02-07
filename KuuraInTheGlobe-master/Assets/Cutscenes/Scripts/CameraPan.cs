using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour {
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    private int scenePosition = EventHandler.scenePosition;
    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        scenePosition = EventHandler.scenePosition;
        if (scenePosition < 1)
        {
            transform.position = Vector3.Lerp(transform.position, endMarker.position, 0.1f * Time.deltaTime); //move camera towards end marker
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 0.1f, -10);
        }
    }
}
