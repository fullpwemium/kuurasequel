using UnityEngine;
using System.Collections;

public class MoviePlayer : MonoBehaviour
{
    private string movPath = "Kuura in the snowglobe 1.mp4";
    private static bool moviePlayed = false;
    //public MovieTexture movTexture;
    // Use this for initialization
    void Start()
    {
        //GetComponent<Renderer>().material.mainTexture = movTexture;
        //movTexture.Play();

        if (moviePlayed == false) {
			Movieplayer (movPath);
			Debug.Log ("Vilmi pyörinyt");
		}
    }

    public void Movieplayer(string path)
    {

		Handheld.PlayFullScreenMovie(path, Color.white, FullScreenMovieControlMode.CancelOnInput);
        moviePlayed = true;
		GlobalGameManager.GGM.StartMapScene ();
    }


}
