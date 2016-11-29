using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour {
    public Texture2D fadeoutTexture;
    public float fadeSpeed = 0.02f;

    private int drawDepth = -1000; //texture draw order
    private float alpha = 1.0f; // 1.0f is completely visible, 0 is black
    private int fadeDir = -1;   //direction of the fade, in is -1 and out is 1

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeoutTexture);
    }

    public float BeginFade (int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }
    
    void OnLevelFinishedLoading()
    {
        BeginFade(1);
        Debug.Log("begin fade");
    }
    
}
