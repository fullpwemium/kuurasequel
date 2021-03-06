﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Theater_exitButton : MonoBehaviour {

	public string OverworldSceneName;

	// Use this for initialization
	void Start () {
		Button but = gameObject.GetComponent<Button>();

		but.onClick.AddListener(() => exit());
	}
	
	void exit () {
		MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuCancel, 1);
		SceneManager.LoadScene (OverworldSceneName, LoadSceneMode.Single);
	}
}
