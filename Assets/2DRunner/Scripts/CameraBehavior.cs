using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour
{
    public Transform player;
    private float horizontalOffset = 2f;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float x = player.position.x;
        transform.position = new Vector3(x + horizontalOffset, transform.position.y, -10);
    }
}
