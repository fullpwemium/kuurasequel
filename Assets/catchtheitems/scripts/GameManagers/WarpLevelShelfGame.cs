using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WarpLevelShelfGame : MonoBehaviour
{
    Button button;

    //Temporal skip button
	void Start ()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(WarpToNext);
    }
    void WarpToNext ()
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);
        ShelfGameManager.manager.PlayerWin();
		ShelfGameManager.manager.LoadNextLevel ();
    }
}
