using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{


	public void ChangeToScene(string sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
        //SceneManager.LoadScene("Map2");
        Collector.Coins = 0;
	}

    //IEnumerator ChangeToScene(string sceneToChangeTo)
    //{
    //    //        Application.LoadLevel(sceneToChangeTo);
    //    AsyncOperation async = Application.LoadLevelAdditiveAsync(sceneToChangeTo);
    //    yield return async;
    //    Debug.Log("Loading complete");
    //}
}
