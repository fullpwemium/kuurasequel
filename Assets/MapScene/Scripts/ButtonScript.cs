using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    Button Button;

    public int ButtonNumber;
    public int ButtonNumber2;
    public static ButtonScript buttonScript;




    public int gameNumber;

    BobPlayerScript Bob;

    static GameObject BobPlayer;

    // Use this for initialization
    void Start ()
    {

        Bob = GameObject.Find("BobPlayer").GetComponent<BobPlayerScript>();
        Button = gameObject.GetComponent<Button>();

        Button.onClick.AddListener(() => MoveHere());

        BobPlayer = GameObject.Find("BobPlayer");
    }

    // Update is called once per frame
    void Update ()
    {
        

    }

    public void OnMouseDown()
    {
        MoveHere();

        //if (this.Button.name == "Exit")
        //{
        //    BobPlayer.transform.position = new Vector3(1.5F, -0.4F, -11.5F);
        //    Debug.Log(BobPlayer.transform.position);
        //}
    }

    void MoveHere ()
    {
       

        if (BobPlayerScript.Moving == false)
        {

            
            GameLoader();
            BobPlayerScript.DestinationButtonNumberX = ButtonNumber;
            BobPlayerScript.DestinationButtonNumberY = ButtonNumber2;
            StartCoroutine(Bob.CountRoute());
        }
        
         //Verrataan kohdeobjektin arvoa lähtöobjektin arvoon
        //BobPlayerScript.destination = gameObject.transform.position;    //Liikutetaan pelaajaobjekti klikattuun objektiin
    }

    public void GameLoader()
    {
        
        CheckGame();
        //Debug.Log("nearMemoryGame" + BobPlayerScript.nearMemoryGame);

        if (BobPlayerScript.nearMemoryGame)     //Ladataan Scene kun klikataan buttonia jonka päällä Bob seisoo
        { 
            SceneManager.LoadScene("LevelMap");    //Ladataan Scene
            BobPlayerScript.nearMemoryGame = false;

        }
        else if (BobPlayerScript.nearCatchTheCat)
        {
            SceneManager.LoadScene("ShelfLevelSelect");
            BobPlayerScript.nearCatchTheCat = false;
        }
        else if(BobPlayerScript.nearLabyrinth)
        {
            SceneManager.LoadScene("LabyLevelSelect");
            BobPlayerScript.nearLabyrinth = false;
        }
        else if (BobPlayerScript.Runner)
        {
            SceneManager.LoadScene("LevelSelect");
            BobPlayerScript.Runner = false;

        }
        else if (BobPlayerScript.nearBobApartment)
        {
            SceneManager.LoadScene("Bob_apartment");
            BobPlayerScript.nearBobApartment = false;

        }

    }

   void CheckGame()
    {
        //Debug.Log("BobPlayer position = " + BobPlayer.transform.position);
        //Debug.Log("button position = " + gameObject.transform.position);

        //        if ((BobPlayer.transform.position.x == gameObject.transform.position.x) &&
        //        (BobPlayer.transform.position.y == gameObject.transform.position.y + 1))
        //if ((BobPlayer.transform.position.x == gameObject.transform.position.x)
        //    && (BobPlayer.transform.position.y == gameObject.transform.position.y+aboveButton))
        if(BobPlayerScript.StandingButtonNumberX == ButtonNumber&& BobPlayerScript.StandingButtonNumberY == ButtonNumber2)
        {
            if (gameNumber == 1)    //Katsotaan onko Bobin seisomalla buttonilla annettu arvo
            {
                BobPlayerScript.nearMemoryGame = true;
            }
            else if (gameNumber == 2)
            {
                BobPlayerScript.nearCatchTheCat = true;
            }
            else if (gameNumber == 3)
            {
                BobPlayerScript.nearLabyrinth = true;
            }
            else if (gameNumber == 4)
            {
                BobPlayerScript.Runner = true;
            }
            else if (gameNumber == 5)
                BobPlayerScript.nearBobApartment = true;
            else
            {/*
                BobPlayerScript.nearMemoryGame = false;
                BobPlayerScript.Runner = false;
                BobPlayerScript.nearLabyrinth = false;
                BobPlayerScript.nearCatchTheCat = false;*/
            }
        }
    }


}




//public void OnMouseDown()
//{ // start button script 
//    if (this.gameObject.name == "start_button")
//    {
//        layermanager.GetComponent<LayerScript>().Layers();
//        //			this.gameObject.SetActive(false);
//    }
//}
