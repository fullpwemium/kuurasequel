using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMainmap : MonoBehaviour {
    public Button BackButton;

	// Use this for initialization
	void Start ()
    {
		BackButton.onClick.AddListener(() => LoadScene());
    }

	public void LoadScene()
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuCancel, 1);
        SceneManager.LoadScene("Overworld");
    }

}
