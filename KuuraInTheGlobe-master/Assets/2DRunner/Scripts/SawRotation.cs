using UnityEngine;
using System.Collections;

public class SawRotation : MonoBehaviour
{
    private float rotationSpeed = 100f;
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, Time.time * rotationSpeed);
    }
}
