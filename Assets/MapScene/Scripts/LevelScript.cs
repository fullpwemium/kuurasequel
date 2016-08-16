using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    Button levelButton;

    public int levelButtonNumber;
    public int levelButtonNumber2;


    public int gameNumber;

    BobLevelScript Bob;

    static GameObject BobLevelPlayer;

    // Use this for initialization
    void Start ()
    {
        Bob = GameObject.Find("BobPlayer").GetComponent<BobLevelScript>();
        levelButton = gameObject.GetComponent<Button>();

        levelButton.onClick.AddListener(() => MoveHere());

        BobLevelPlayer = GameObject.Find("BobPlayer");
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnMouseDown()
    {
        MoveHere();
    }

    void MoveHere()
    {


        if (BobLevelScript.Moving == false)
        {


            GameLoader();
            BobLevelScript.DestinationLevelNumberX = levelButtonNumber;
            BobLevelScript.DestinationLevelNumberY = levelButtonNumber2;
            StartCoroutine(Bob.CountRoute());
        }

        //Verrataan kohdeobjektin arvoa lähtöobjektin arvoon
        //BobLevelScript.destination = gameObject.transform.position;    //Liikutetaan pelaajaobjekti klikattuun objektiin
    }

    void GameLoader()
    {
        CheckGame();
        Debug.Log("nearMemoryGame" + BobLevelScript.MemoryGameLevel1);

        if (BobLevelScript.MemoryGameLevel1 == true)     //Ladataan Scene kun klikataan buttonia jonka päällä Bob seisoo
        {
            SceneManager.LoadScene("Level1");    //Ladataan Scene

            Debug.Log("Load Memory Game");
        }
        else if (BobLevelScript.MemoryGameLevel2 == true)     //Ladataan Scene kun klikataan buttonia jonka päällä Bob seisoo
        {
            SceneManager.LoadScene("Level2");    //Ladataan Scene

            Debug.Log("Load Memory Game");
        }
        else if (BobLevelScript.MemoryGameLevel3 == true)     //Ladataan Scene kun klikataan buttonia jonka päällä Bob seisoo
        {
            SceneManager.LoadScene("Level3");    //Ladataan Scene

            Debug.Log("Load Memory Game");
        }
        else if (BobLevelScript.MemoryGameLevel4 == true)     //Ladataan Scene kun klikataan buttonia jonka päällä Bob seisoo
        {
            SceneManager.LoadScene("Level4");    //Ladataan Scene

            Debug.Log("Load Memory Game");
        }
        else if (BobLevelScript.MemoryGameLevel5 == true)     //Ladataan Scene kun klikataan buttonia jonka päällä Bob seisoo
        {
            SceneManager.LoadScene("Level5");    //Ladataan Scene

            Debug.Log("Load Memory Game");
        }
        else if (BobLevelScript.MemoryGameLevel6 == true)     //Ladataan Scene kun klikataan buttonia jonka päällä Bob seisoo
        {
            SceneManager.LoadScene("Level6");    //Ladataan Scene

            Debug.Log("Load Memory Game");
        }
        else if (BobLevelScript.MemoryGameLevel7 == true)     //Ladataan Scene kun klikataan buttonia jonka päällä Bob seisoo
        {
            SceneManager.LoadScene("Level7");    //Ladataan Scene

            Debug.Log("Load Memory Game");
        }
        else if (BobLevelScript.MemoryGameLevel8 == true)     //Ladataan Scene kun klikataan buttonia jonka päällä Bob seisoo
        {
            SceneManager.LoadScene("Level8");    //Ladataan Scene

            Debug.Log("Load Memory Game");
        }
        else if (BobLevelScript.MemoryGameLevel9 == true)     //Ladataan Scene kun klikataan buttonia jonka päällä Bob seisoo
        {
            SceneManager.LoadScene("Level9");    //Ladataan Scene

            Debug.Log("Load Memory Game");
        }
        else if (BobLevelScript.MemoryGameLevel10 == true)     //Ladataan Scene kun klikataan buttonia jonka päällä Bob seisoo
        {
            SceneManager.LoadScene("Level10");    //Ladataan Scene

            Debug.Log("Load Memory Game");
        }
    }

    void CheckGame()
    {
        if(BobLevelScript.StandingLevelNumberX == levelButtonNumber && BobLevelScript.StandingLevelNumberY == levelButtonNumber2)
        {
            if (gameNumber == 1)
            {
                if (levelButtonNumber == 0)    //Katsotaan onko Bobin seisomalla buttonilla annettu arvo
                {
                    BobLevelScript.MemoryGameLevel1 = true;
                }
                else if (levelButtonNumber == 1)
                {
                    BobLevelScript.MemoryGameLevel2 = true;
                }
                else if (levelButtonNumber == 2)
                {
                    BobLevelScript.MemoryGameLevel3 = true;
                }
                else if (levelButtonNumber == 3)
                {
                    BobLevelScript.MemoryGameLevel4 = true;
                }
                else if (levelButtonNumber == 4)
                {
//                    BobLevelScript.MemoryGameLevel5 = true;
                }
                else if (levelButtonNumber == 5)
                {
                    BobLevelScript.MemoryGameLevel5 = true;
                }
                else if (levelButtonNumber == 6)
                {
                    BobLevelScript.MemoryGameLevel6 = true;
                }
                else if (levelButtonNumber == 7)
                {
                    BobLevelScript.MemoryGameLevel7 = true;
                }
                else if (levelButtonNumber == 8)
                {
                    BobLevelScript.MemoryGameLevel8 = true;
                }
                else if (levelButtonNumber == 9)
                {
                    BobLevelScript.MemoryGameLevel9 = true;
                }
                else if (levelButtonNumber == 9)
                {
                    BobLevelScript.MemoryGameLevel10 = true;
                }

                else
                {
                    BobLevelScript.MemoryGameLevel1 = false;
                    BobLevelScript.MemoryGameLevel2 = false;
                    BobLevelScript.MemoryGameLevel3 = false;
                    BobLevelScript.MemoryGameLevel4 = false;
                    BobLevelScript.MemoryGameLevel5 = false;
                    BobLevelScript.MemoryGameLevel6 = false;
                    BobLevelScript.MemoryGameLevel7 = false;
                    BobLevelScript.MemoryGameLevel8 = false;
                    BobLevelScript.MemoryGameLevel9 = false;
                    BobLevelScript.MemoryGameLevel10 = false;
                }
            }
            else if(gameNumber == 2)
            {
                
                GameManager.manager.LoadLevel(levelButtonNumber);
            }
            else if(gameNumber == 3)
            {
                RunnerManager.manager.LoadLevel(levelButtonNumber);
            }
            else if(gameNumber == 4)
            {
                LabyGameManager.manager.LoadLevel(levelButtonNumber);
            }
        }

        if (BobLevelScript.StandingLevelNumberX == levelButtonNumber && BobLevelScript.StandingLevelNumberY == levelButtonNumber2)
        {
            
        }
    }
}
