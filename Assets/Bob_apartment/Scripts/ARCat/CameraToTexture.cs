using UnityEngine;
using System.Collections;

public class CameraToTexture : MonoBehaviour {
    WebCamTexture cameraTexture;
    public GameObject floor;

    // Use this for initialization
    void Start () {
        WebCamDevice[] device = WebCamTexture.devices;
        
        if (device.Length > 0) { 
            cameraTexture = new WebCamTexture();
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.mainTexture = cameraTexture;
            cameraTexture.Play();
        } else
        {

            floor.GetComponent<Renderer>().enabled = true; // render ground if no camera available 
        }

    }

    void OnDestroy()
    {
        cameraTexture.Stop();
    }

}
