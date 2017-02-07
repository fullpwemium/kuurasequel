using UnityEngine;
using System.Collections;

public class TextScrollTheater : MonoBehaviour {

    public GameObject text;
    Vector3 textpos;
    public float smoothTime = 0.3F;
    private float yVelocity = 0.0F;
    public Transform target;
    bool textScrolling;

    // Use this for initialization
    void Start () {
       textScrolling = true;
    }
	
	// Update is called once per frame
	void Update () {
       MoveText();
    }

    void MoveText()
    {
        if (textScrolling == true)
        {
            float newPosition = Mathf.SmoothDamp(transform.position.y, 10, ref yVelocity, smoothTime);
            transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
        }
       //  Debug.Log(newPosition);
       //  Debug.Log(transform.position);
    }

    public void StopScrolling()
    {
        textScrolling = false;
    }
}
