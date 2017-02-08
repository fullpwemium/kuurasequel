﻿using UnityEngine;
using System.Collections;

public class Catcher : MonoBehaviour {

	float normalscaleX,normalscaleY;
	bool largesize = false;
    GameObject partikkelit;
    ParticleSystemScript PSS;
    
    void Start()
    {
        MusicPlayer.PlayMusic(MusicTrack.BubbleWarehouse);
        PSS = GameObject.FindObjectOfType<ParticleSystem>().GetComponent<ParticleSystemScript>();
        partikkelit = GameObject.Find("Particle System");

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Items")
        {
            MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.itemCatch, 1);
            PSS.emiParticles();
            Destroy(col.gameObject);
        }
    }

    public void slowDown()
    {
        if (ShelfGameManager.manager.aikamuutettu == false)
        {
            //GameManager.aika = 0.5f;
            //Time.timeScale = GameManager.aika;
            ShelfGameManager.manager.aikamuutettu = true;
            Debug.Log("hidastuu" + ShelfGameManager.manager.aikamuutettu);
            Invoke("speedUp", 1.0f);
        }
    }

    void speedUp()
    {
        //GameManager.aika = 1f;
        //Time.timeScale = GameManager.aika;
        ShelfGameManager.manager.aikamuutettu = false;
        Debug.Log("palautuu" + Time.timeScale);
    }

    public void LargeBucket()
	{
		if (largesize == false)
        {
            Debug.Log("Isonnettu");
            normalscaleX = transform.localScale.x;
			normalscaleY = transform.localScale.y;
			transform.localScale = new Vector2 (normalscaleX + 0.6f, normalscaleY + 0.4f);
			largesize = true;
			Invoke ("Normalsize", 3f);
		}
        
        
    }

	void Normalsize()
	{
		transform.localScale = new Vector2 (normalscaleX, normalscaleY);
		largesize = false;
	}
}