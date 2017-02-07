using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class MemoryGameStarScript : MonoBehaviour
{
    Image Star;
    public int starNumber;
    public int buttonNumber;

    // Use this for initialization
    void Start()
    {

        ChecKStars();
    }

    public void ChecKStars()
    {
        Star = GetComponent<Image>();

        //Star.color = Color.white;
        //Debug.Log("HUUUUAAAARRRRGHGHGHG!" + Storage.MemoryGameStars[buttonNumber]);
        if (Storage.MemoryGameStars[buttonNumber] >= starNumber)
        {
            Star.color = Color.white;
            //Debug.Log("MemoryGameStarScript: varjattu");
            //GlobalGameManager.GGM.MemoryGameSave();
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        ChecKStars();

    }


}
