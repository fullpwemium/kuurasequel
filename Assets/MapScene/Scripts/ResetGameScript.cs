using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResetGameScript : MonoBehaviour {

    public Button resetGame;
    public static Text AllMagicDust;
    int MagicDust;

    // Use this for initialization
    void Start ()
    {
        resetGame.onClick.AddListener(ResetGame);
        MagicDust = PlayerPrefs.GetInt("Magic Dust ");
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        MagicDust = PlayerPrefs.GetInt("Magic Dust ");

        if (GameObject.Find("MagicDust"))
        {
            AllMagicDust = GameObject.Find("MagicDust").GetComponent<Text>();
            AllMagicDust.text = MagicDust.ToString("f0");
        }
    }
}
