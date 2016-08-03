using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Death")
        {
            RunnerManager.manager.PlayerLose();
        }
    }
}
