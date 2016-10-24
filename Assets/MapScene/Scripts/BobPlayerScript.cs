using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class BobPlayerScript : MonoBehaviour
{
    private Animator BobPlayerAnimator;
    int BobDirection = 20;
    int OldBobDirection = 15;

    bool bobstill;

    int startDestinationX, startDestinationY;

    public static bool nearMemoryGame = false;
    public static bool nearCatchTheCat = false;
    public static bool nearLabyrinth = false;
    public static bool Runner = false;
    public static bool nearBobApartment = false;
    public static bool nearShop = false;

    public static float aboveButton;


    static public int Frame = 0;

    static int reittiX, reittiY, reitinpituus, midWayDestinationX, midWayDestinationY;

    public static int DestinationButtonNumberX;
    public static int DestinationButtonNumberY;
    public static int StandingButtonNumberX = 0;
    public static int StandingButtonNumberY = 1;

    //    private map_manager map;

    public static Vector3 destination;

    static float lerpStartTime;
    float timeStartedLerping;
    float timeTakenDuringLerp;
    //float BobNopeus = 10;

    static Vector3 startPosition;

    public Transform target;

    public static bool Moving;

    static GameObject BobPlayer;

    GameObject memoryGame;

    Collider2D Rakennus1; //Objektiin luotu tag
    Collider2D Rakennus2;

    Button Button1, Button2, Button3, Button4, Button5;

    public Button puhekupla1, puhekupla2, puhekupla3, puhekupla4, puhekupla5;

    // Use this for initialization
    void Start ()
    {
        nearShop = false;
        ReadFile("tiedosto");
        puhekupla1.interactable = false;
        puhekupla2.interactable = false;
        puhekupla3.interactable = false;
        puhekupla4.interactable = false;
        puhekupla5.interactable = false;

        nearMemoryGame = false;
        Frame = 0;
        BobPlayerAnimator = GetComponent<Animator>();

        startDestinationX = PlayerPrefs.GetInt("Bobin paikka X");
        startDestinationY = PlayerPrefs.GetInt("Bobin paikka Y");

        StandingButtonNumberX = PlayerPrefs.GetInt("Bobin paikka X");
        StandingButtonNumberY = PlayerPrefs.GetInt("Bobin paikka Y");

        Debug.Log("StandingButtonNumberX = " + StandingButtonNumberX);
        Debug.Log("StandingButtonNumberY = " + StandingButtonNumberY);

        GameObject startButton = GameObject.Find("Tile" + startDestinationX + startDestinationY);
        Debug.Log("Start button = " + startButton);
        if (startButton == null)
        {
            startButton = GameObject.Find("Tile" + 0 + 1);
            Debug.Log("Ei löytynyt");
        }

        aboveButtonScale();
        gameObject.transform.position = destination;

        Vector2 kierto;

        kierto.x = startButton.transform.position.x;
        kierto.y = startButton.transform.position.y;

        gameObject.transform.position = kierto;


        memoryGame = GameObject.Find("memoryGame");     //Kohde johon kävellään

//        map = GameObject.Find("tilemap_parent").GetComponent<map_manager>();

        BobPlayer = GameObject.Find("BobPlayer");

//        BobPlayer.transform.position = new Vector3(BobPlayer.transform.position.x, BobPlayer.transform.position.y, BobPlayer.transform.position.z);

        destination = gameObject.transform.position;
        //aboveButtonScale();
        BobOnButton();

        Rakennus1 = GameObject.Find("memoryGame").GetComponent<Collider2D>();   //Viitataan luotuun tagiin

        //StandingButtonNumber = 0;
        


        //Button1 = GameObject.Find("Tile").GetComponent<Button>();
        //Button2 = GameObject.Find("Tile (1)").GetComponent<Button>();
        //Button1 = GameObject.Find("Tile (2)").GetComponent<Button>();
        //Button1 = GameObject.Find("Tile (3)").GetComponent<Button>();

        //        Invoke("Movement", 2);


        // Instanciate the PathMap object:
    }

    int ReadFile(string file)
    { 
    if(File.Exists(file))
    {
    var sr = File.OpenText(file);
    var line = sr.ReadLine();
        while(line != null)
        {
        Debug.Log(line); // prints each line of the file
        line = sr.ReadLine();
        }
            return 5;
    }
    else
    {
        return 5;
    }
    }

    public static void StartLerping()
    {
        
        lerpStartTime = Time.time;
        startPosition = BobPlayer.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {

        if (StandingButtonNumberX == 2 && StandingButtonNumberY == 3)
        {
            puhekupla1.interactable = true;
            puhekupla2.interactable = false;
            puhekupla3.interactable = false;
            puhekupla4.interactable = false;
            puhekupla5.interactable = false;

        }
        else if (StandingButtonNumberX == 0 && StandingButtonNumberY == 1)
        {
            puhekupla1.interactable = false;
            puhekupla2.interactable = false;
            puhekupla3.interactable = true;
            puhekupla4.interactable = false;
            puhekupla5.interactable = false;
        }
        else if (StandingButtonNumberX == 2 && StandingButtonNumberY == 0)
        {
            puhekupla1.interactable = false;
            puhekupla2.interactable = false;
            puhekupla3.interactable = false;
            puhekupla4.interactable = false;
            puhekupla5.interactable = true;
        }
        else if (StandingButtonNumberX == 0 && StandingButtonNumberY == 2)
        {
            puhekupla1.interactable = false;
            puhekupla2.interactable = true;
            puhekupla3.interactable = false;
            puhekupla4.interactable = false;
            puhekupla5.interactable = false;
        }
        else if (StandingButtonNumberX == 0 && StandingButtonNumberY == 3)
        {
            puhekupla1.interactable = false;
            puhekupla2.interactable = false;
            puhekupla3.interactable = false;
            puhekupla4.interactable = true;
            puhekupla5.interactable = false;
        }
        else
        {
            puhekupla1.interactable = false;
            puhekupla2.interactable = false;
            puhekupla3.interactable = false;
            puhekupla4.interactable = false;
            puhekupla5.interactable = false;

        }

        //Movement();
        BobScale();
        if (Moving)
        {
            bobstill = false;
            float timeSinceStarted = Time.time - lerpStartTime;

            float percentageComplete = timeSinceStarted / 0.5F;   //Kävelynopeus

            BobPlayer.transform.position = Vector3.Lerp(startPosition, destination, percentageComplete);    //Muutetaan Bobin sijaintia kartan Lerp-vektoreilla.

//            Debug.Log("percentageComplete = " + percentageComplete);
            if (percentageComplete >= 1.0F)
            {
                Moving = false;
                StandingButtonNumberX = midWayDestinationX;
                StandingButtonNumberY = midWayDestinationY;//Muutetaan seisomisobjektin arvo kohdeobjektin arvoksi
                Debug.Log("StandingButtonNumber = " + StandingButtonNumberX);
                Debug.Log("StandingButtonNumber2 = " + StandingButtonNumberY);
                
            }
        }
        else if (Moving == false)
        {

            if(bobstill == false)
            {
                BobPlayerAnimator.SetTrigger("BobStanding");
                bobstill = true;
            }
            else
            {

            }
            
        }

       

    }

    public IEnumerator CountRoute() //Lasketaan etäisyys kohteesta buttonNumbereiden pohjalta
    {
        
        int routeX = DestinationButtonNumberX-StandingButtonNumberX;
        Debug.Log(DestinationButtonNumberX + "-" + StandingButtonNumberX + "=" + routeX);
        int routeY = DestinationButtonNumberY- StandingButtonNumberY;
        Debug.Log(DestinationButtonNumberY + "-" + StandingButtonNumberY + "=" + routeY);
        Debug.Log(routeX);
        Debug.Log(routeY);

        reitinpituus = Mathf.Abs(routeX) + Mathf.Abs(routeY);

        for( int i = 0; i < reitinpituus;i++)
        {
            reittiY = 0;
            reittiX = 0;

            if (routeX > 0)
            {
                reittiX = 1;
                routeX--;
            }
            else if(routeX < 0)
            {
                reittiX = -1;
                routeX++;
            }
            else if(routeX == 0)
            {
               
                if (routeY > 0)
                {
                    reittiY = 1;
                    routeY--;
                }
                else if (routeY < 0)
                {
                    reittiY = -1;
                    routeY++;
                }
            }


            runRoute(reittiX, reittiY);
            aboveButtonScale();
            BobOnButton();

            yield return new WaitForSeconds(0.5f);
        }
        //BobPlayerAnimator.SetTrigger("BobDown");

    }

    void runRoute(int routeX, int routeY)
    {
        Moving = true;
        Debug.Log("routeX = " + routeX);
        Debug.Log("routeY = " + routeY);
        midWayDestinationX = StandingButtonNumberX;
        //Debug.Log(midWayDestinationX);
        midWayDestinationY = StandingButtonNumberY;
        //Debug.Log(midWayDestinationY);

        

        if(routeX > 0)
        {
            midWayDestinationX++;
            BobPlayerAnimator.SetTrigger("BobDown");
        }
        else if(routeX < 0)
        {
            midWayDestinationX--;
            BobPlayerAnimator.SetTrigger("BobUp");
        }
        else if (routeX == 0)
        {
            if (routeY > 0)
            {
                midWayDestinationY++;
                BobPlayerAnimator.SetTrigger("BobRight");
            }
            else if (routeY < 0)
            {
                midWayDestinationY--;
                BobPlayerAnimator.SetTrigger("BobLeft");
            }
        }


        string tileName = "Tile" + midWayDestinationX + midWayDestinationY;
        Debug.Log(tileName);
        GameObject midWayButton = GameObject.Find("Tile" + midWayDestinationX + midWayDestinationY);
		if(midWayButton == null)
			return;
		destination.x = midWayButton.transform.position.x;
        
        destination.y = midWayButton.transform.position.y;
        
        Debug.Log("lähdetään liikkeelle");

        //BobPlayer.transform.position = destination;

        
        StartLerping();
        //BobPlayer.transform.position = Vector3.Lerp(startPosition, destination, 1.5f);
        StandingButtonNumberX = midWayDestinationX;
        StandingButtonNumberY = midWayDestinationY;

        PlayerPrefs.SetInt("Bobin paikka X", StandingButtonNumberX);
        PlayerPrefs.SetInt("Bobin paikka Y", StandingButtonNumberY);

        //yield return new WaitForSeconds(1);

    }

    ///IEnumerator waitForSeconds()
    //{
    //    yield return new WaitForSeconds(1);
    //}

    //public static void CheckNeighbour()     //Liikutaan vain yhtä suurempiin tai pienempiin arvoihin
    //{

    //    if ((StandingButtonNumber + 1 == DestinationButtonNumber || StandingButtonNumber - 1 == DestinationButtonNumber || StandingButtonNumber == DestinationButtonNumber) && ( StandingButtonNumber2 + 1 == DestinationButtonNumber2 || StandingButtonNumber2 - 1 == DestinationButtonNumber2 || StandingButtonNumber2 == DestinationButtonNumber2))
    //    {
    //        StartLerping();
    //    }
    //    else
    //    {

    //    }
    //}

    void BobScale()     //Skaalataan Bobia perspektiivin mukaan
    {
        gameObject.transform.localScale = new Vector2(Mathf.Abs(gameObject.transform.position.y * 0.08F), Mathf.Abs(gameObject.transform.position.y * 0.08F));
    }

    void BobOnButton()
    {
        destination.y = destination.y + aboveButton;
        //gameObject.transform.position = destination;

        //StartLerping();
    }

    public void aboveButtonScale()
    {
        aboveButton = gameObject.transform.position.y * -0.16F;
        Debug.Log("Above Button = " + aboveButton);
    }

    //void OnTriggerEnter2D(Collider2D Col)
    //{
    //    if (Col.tag == "Rakennus1")     //Toiminto kun hitboxit törmäävät
    //    {
    //        Application.LoadLevel("GameScene");     //Mennään muistipeliin
    //    }
    //}
}
