using UnityEngine;
using System.Collections;

public class RandomY : MonoBehaviour
{

    void Start()
    {
        float x = transform.localPosition.x;
        transform.localPosition = new Vector2(x, Random.Range(1, 8));
    }
}
