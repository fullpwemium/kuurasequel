using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
{

	Button lvlSelect;
    public string levelName;

	// Use this for initialization
	void Start ()
    {
		lvlSelect = GetComponent<Button> ();
		lvlSelect.onClick.AddListener (LevelSelect);

        if (RunnerManager.score != 0)
        {
            RunnerManager.score = 0;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

	void LevelSelect()
	{
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuCancel, 1);
        SceneManager.LoadScene(levelName);
	}
}
