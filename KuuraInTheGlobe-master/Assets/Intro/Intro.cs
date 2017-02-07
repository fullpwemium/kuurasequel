using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
        StartCoroutine(CountDown());
	}
	
	private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("IntroVideo");
    }
}
