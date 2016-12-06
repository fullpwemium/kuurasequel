using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WMleffateatterinappi : MonoBehaviour {

    Button button;

	// Use this for initialization
	void Start () {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(() => leffateatteriin());
    }

    void leffateatteriin()
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);
        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().currentScene = "Theater";
        SceneManager.LoadScene("Theater");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
