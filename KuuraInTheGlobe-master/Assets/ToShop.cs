using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToShop : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //SceneManager.LoadScene(36);
            SceneManager.LoadScene("Shop");
            Debug.Log("Kauppias");
        }
    }
}
