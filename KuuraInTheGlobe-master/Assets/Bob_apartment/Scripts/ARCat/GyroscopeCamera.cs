using UnityEngine;
using System.Collections;

public class GyroscopeCamera : MonoBehaviour {
	//public GameObject target;
	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0, -Input.gyro.rotationRateUnbiased.y, 0);
	}
}
