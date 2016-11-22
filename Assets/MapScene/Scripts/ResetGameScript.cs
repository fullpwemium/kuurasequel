using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResetGameScript : MonoBehaviour {

    public Button resetGame;

	// Use this for initialization
	void Start ()
    {
        resetGame.onClick.AddListener(ResetGame);
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
