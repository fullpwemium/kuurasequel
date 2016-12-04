using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMainmap : MonoBehaviour {
    public Button BackButton;
    public int sceneToLoad;

	// Use this for initialization
	void Start ()
    {
        BackButton.onClick.AddListener(() => LoadScene(sceneToLoad));
    }

    public void LoadScene(int scene)
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuCancel, 1);
        SceneManager.LoadScene("Map2");
    }

}
