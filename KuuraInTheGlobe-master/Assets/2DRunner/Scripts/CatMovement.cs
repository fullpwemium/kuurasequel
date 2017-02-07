using UnityEngine;
using System.Collections;

public class CatMovement : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        gameObject.transform.Translate(Vector2.right * Time.deltaTime * 2);
    }
    public IEnumerator TranformBack(float time)
    {
        this.gameObject.transform.Translate(Vector2.left * Time.deltaTime * 10);
        anim.SetTrigger("Effect");
        yield return new WaitForSeconds(time);
        RunnerManager.manager.isCatMoving = false;
    }
}
