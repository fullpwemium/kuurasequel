using UnityEngine;
using System.Collections;

public class Fireballmovement : MonoBehaviour
{

    float speed = 5;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    public void Movement()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed, 0);
    }
}
