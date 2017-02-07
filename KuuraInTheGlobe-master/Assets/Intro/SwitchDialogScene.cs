using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchDialogScene : MonoBehaviour {
	
	public Animator animator;
	public Animation anim;
	public int introWatched;
	
	void Start()
	{
		//We set this to true at the end of the phone dialog
		introWatched = PlayerPrefs.GetInt("introWatched");
		
		anim = GetComponent<Animation>();
		anim.Play();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(introWatched > 0)
			{
				GotoMap();
			}
		}
	}
	
	public void GotoDialog()
	{
		SceneManager.LoadScene("Phone_dialog");
	}
	
	public void GotoMap()
	{
		SceneManager.LoadScene("Map2");
	}
}
