using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour
{

    public float speed;
    public bool scroll;
    private float time;
    void Start()
    {
        scroll = true;
    }
    // Scroll the background if player is moving, stop if dead of stuck. Controlled in PlatformerCharacter2D script
    void LateUpdate()
    {
        if (scroll) {
            time += Time.deltaTime;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(time * speed, 0f);
    }

    }
}
