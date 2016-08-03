using UnityEngine;
using System.Collections;

public class Coinmanager : MonoBehaviour
{
    public Vector3 position;
    // Use this for initialization
    void Awake()
    {
        position = transform.localPosition;
    }
    void OnEnable()
    {
        transform.localPosition = position;
    }
    // Update is called once per frame

}
