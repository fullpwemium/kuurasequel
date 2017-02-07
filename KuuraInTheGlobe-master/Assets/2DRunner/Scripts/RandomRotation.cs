using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 180));
    }
}
