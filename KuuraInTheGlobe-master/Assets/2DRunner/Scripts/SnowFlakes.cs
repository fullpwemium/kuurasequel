using UnityEngine;
using System.Collections;

public class SnowFlakes : MonoBehaviour
{
    private Rigidbody2D rigid;
    Vector2 direction;
    public float speed;
    private bool canMove;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        direction = new Vector2(-0.5f, -1f);
        direction.Normalize();
    }
    void FixedUpdate()
    {
        if (canMove)
        {
            rigid.velocity = direction * speed;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SnowFlakesTrigger")
        {
            canMove = true;
        }
    }
}
