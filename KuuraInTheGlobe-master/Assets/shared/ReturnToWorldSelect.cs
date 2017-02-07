using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReturnToWorldSelect : MonoBehaviour {

    Button button;

	// Use this for initialization
	void Start ()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ReturnToWorld);
	}

    void ReturnToWorld()
    {
        LabyGameManager.manager.ReturnToWorldSelect();
    }
}
