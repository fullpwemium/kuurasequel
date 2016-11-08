using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour {
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    // Use this for initialization
    void Start () {
        //startTime = Time.time;
        //journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Update is called once per frame
    void Update () {
        transform.position = Vector3.Lerp(transform.position, endMarker.position, 0.1f * Time.deltaTime);
    }
}
