using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour {

	Button lvlSelect;

	// Use this for initialization
	void Start () {
		lvlSelect = GetComponent<Button> ();
		lvlSelect.onClick.AddListener (LevelSelect);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LevelSelect()
	{
        SceneManager.LoadScene("CatchTheCatLevelSelect");
	}
}
