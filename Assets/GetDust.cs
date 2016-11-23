using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetDust : MonoBehaviour {

    int MagicDust;
    public Button addDust;
    public static Text AllMagicDust;

    // Use this for initialization
    void Start ()
    {
        MagicDust = PlayerPrefs.GetInt("Magic Dust ");
        addDust.onClick.AddListener(AddDust);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void AddDust()
    {
        MagicDust =+ 50000;
        PlayerPrefs.SetInt("Magic Dust ", MagicDust);

        if (GameObject.Find("MagicDust"))
        {
            AllMagicDust = GameObject.Find("MagicDust").GetComponent<Text>();
            AllMagicDust.text = MagicDust.ToString("f0");
        }
    }
}
