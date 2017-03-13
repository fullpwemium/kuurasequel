using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RG_CatObjectAnimationScript : MonoBehaviour {

	public List<Sprite> sprites;
	public float animationSpeed = 0.06f;
	float timer = 0f;
	int index = 0;

	SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		timer = animationSpeed;
		renderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.fixedDeltaTime;
		if (timer <= 0) {
			timer = animationSpeed;
			index++;
			if (index >= sprites.Count) {
				index = 0;
			}

			renderer.sprite = sprites [index];
		}
	}
}
