using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResetCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);
        SceneManager.LoadScene("ARCat");
    }
}
