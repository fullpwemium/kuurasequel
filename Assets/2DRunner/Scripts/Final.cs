using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene(0);
            RunnerManager.manager.PlayerWin();
        }
    }
}
