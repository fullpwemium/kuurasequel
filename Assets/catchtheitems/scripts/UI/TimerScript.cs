using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

	public Text timer;
	float timeLeft;
	float addTimeValue;
	public static int seconds;
	private UI sceneUi;
	bool GOPOn = false;
	public float time = 30f;

    public static bool Lose = false;
    public static bool Win = false;
    public static bool timeRunOut = false;

    // Use this for initialization
    void Start ()
    {
		sceneUi = FindObjectOfType<UI> ();
		//Debug.Log (ShelfGameManager.manager.currentLevel);
		addTimeValue = GameManager.extraTime;
		time = time + addTimeValue;
		timeLeft = time;
		//timeLeft = (time * (ShelfGameManager.manager.currentLevel + 1))/2f;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
		if (timeLeft > 0)
        {
            if (Lose == false)
            {
                timeLeft -= Time.deltaTime;
                seconds = (int)timeLeft;
                //timer.text = "Time: " + seconds;
                timer.text = "Time: " + timeLeft.ToString("f2");
            }
			

            else if (Lose == true)      //Pysäytetään ajastin kun missataan liikaa esineitä.
            {
                timer.text = "Time: " + timeLeft.ToString("f2");
            }
        } 
		else if (timeLeft <= 0)
        {
            timeLeft = 0;
            timeRunOut = true;

			if (GOPOn == false)
            {
                Win = true;
                //Lose = false;
				sceneUi.GameOverPanelToggle ();
				sceneUi.TextSwitcher (true);
				ShelfGameManager.manager.PlayerWin ();
				GOPOn = true;
			}
		}

        
	}

}
