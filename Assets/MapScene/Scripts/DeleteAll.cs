using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeleteAll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ClearAll()
    {
        PlayerPrefs.DeleteAll();
        //GlobalGameManager.MagicDust = 1000;
        //PlayerPrefs.SetInt("Magic Dust ", GlobalGameManager.MagicDust);
        SceneManager.LoadScene("Map2");
    }
}
