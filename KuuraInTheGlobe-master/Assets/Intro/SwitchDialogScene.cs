using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchDialogScene : MonoBehaviour {
	
	public Animator animator;
	public Animation anim;
	public bool introWatched;
	
	void Start()
	{
		//We set this to true at the end of the phone dialog
		introWatched = GlobalGameManager.GGM.hasIntroBeenWatched();
		
		anim = GetComponent<Animation>();
		//anim.Play();

	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(introWatched)
			{
				GotoDialog ();
			}
		}

		if (!hasAnimationFinished ()) {
			GotoDialog ();
		}
	}

	bool hasAnimationFinished() {
		return animator.GetCurrentAnimatorStateInfo (0).normalizedTime < 1;
	}

	
	public void GotoDialog()
	{
		GlobalGameManager.GGM.setIntroWatched ();
		SceneManager.LoadScene("Overworld");
	}

}
