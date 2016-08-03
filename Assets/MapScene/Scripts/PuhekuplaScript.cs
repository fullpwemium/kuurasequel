using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PuhekuplaScript : MonoBehaviour {


    Button Button;
	// Use this for initialization
	void Start () {
        Button = gameObject.GetComponent<Button>();

        Button.onClick.AddListener(() => Talktalk());
    }
	
	// Update is called once per frame
	void Update () {


	
	}

    void Talktalk()
    {
        Debug.Log("Wadap m8!");
    }
}
