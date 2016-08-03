using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BobLevelScript : MonoBehaviour
{
    private Animator BobPlayerAnimator;
    int BobDirection = 20;
    int OldBobDirection = 15;

    int startDestinationX, startDestinationY;

    public static bool MemoryGameLevel1 = false;
    public static bool MemoryGameLevel2 = false;
    public static bool MemoryGameLevel3 = false;
    public static bool MemoryGameLevel4 = false;
    public static bool MemoryGameLevel5 = false;
    public static bool MemoryGameLevel6 = false;
    public static bool MemoryGameLevel7 = false;
    public static bool MemoryGameLevel8 = false;
    public static bool MemoryGameLevel9 = false;
    public static bool MemoryGameLevel10 = false;


    public static float aboveButton;


    static public int Frame = 0;

    static int reittiX, reittiY, reitinpituus, midWayDestinationX, midWayDestinationY;

    public static int DestinationLevelNumberX;
    public static int DestinationLevelNumberY;
    public static int StandingLevelNumberX = 0;
    public static int StandingLevelNumberY = 1;

    //    private map_manager map;

    public static Vector3 destination;

    static float lerpStartTime;
    float timeStartedLerping;
    float timeTakenDuringLerp;
    //    float BobNopeus = 10;

    static Vector3 startPosition;

    public Transform target;

    public static bool Moving;

    static GameObject BobPlayer;

    GameObject memoryGame;

    Collider2D Kenttä; //Objektiin luotu tag

    Button Button1, Button2, Button3, Button4;

    // Use this for initialization
    void Start()
    {
//        PlayerPrefs.DeleteAll();

        MemoryGameLevel1 = false;
        MemoryGameLevel2 = false;
        MemoryGameLevel3 = false;
        MemoryGameLevel4 = false;
        MemoryGameLevel5 = false;
        MemoryGameLevel6 = false;
        MemoryGameLevel7 = false;
        MemoryGameLevel8 = false;
        MemoryGameLevel9 = false;
        MemoryGameLevel10 = false;

        Frame = 0;
        BobPlayerAnimator = GetComponent<Animator>();

        startDestinationX = PlayerPrefs.GetInt("Bobin kenttä X");
        startDestinationY = PlayerPrefs.GetInt("Bobin kenttä Y");
        Debug.Log(startDestinationX + " " + startDestinationY);

        StandingLevelNumberX = PlayerPrefs.GetInt("Bobin kenttä X");
        StandingLevelNumberY = PlayerPrefs.GetInt("Bobin kenttä Y");

        GameObject startLevelButton = GameObject.Find("Level" + startDestinationX + startDestinationY);
        if (startLevelButton == null)
        {
            if (startLevelButton == null)
            {
                startLevelButton = GameObject.Find("Level" + 0 + 1);

                StandingLevelNumberX = 0;
                StandingLevelNumberY = 1;

                Debug.Log("Ei löytynyt");
                Debug.Log("startLevel = " + startLevelButton);
            }
        }

//        aboveButtonScale();

        Vector2 kierto;

        kierto.x = startLevelButton.transform.position.x;
        kierto.y = startLevelButton.transform.position.y;

        gameObject.transform.position = kierto;

        //Debug.Log("gameObject" + gameObject.transform.position + "startButton" + startButton.transform.position);

        memoryGame = GameObject.Find("memoryGame");     //Kohde johon kävellään

        //        map = GameObject.Find("tilemap_parent").GetComponent<map_manager>();

        BobPlayer = GameObject.Find("BobPlayer");

        //        BobPlayer.transform.position = new Vector3(BobPlayer.transform.position.x, BobPlayer.transform.position.y, BobPlayer.transform.position.z);

        destination = gameObject.transform.position;

        BobOnButton();

        Kenttä = GameObject.Find("memoryGame").GetComponent<Collider2D>();   //Viitataan luotuun tagiin

        //StandingButtonNumber = 0;

        Debug.Log("StandingLevelNumber = " + StandingLevelNumberX);
        Debug.Log("StandingLevelNumber2 = " + StandingLevelNumberY);


        //Button1 = GameObject.Find("Tile").GetComponent<Button>();
        //Button2 = GameObject.Find("Tile (1)").GetComponent<Button>();
        //Button1 = GameObject.Find("Tile (2)").GetComponent<Button>();
        //Button1 = GameObject.Find("Tile (3)").GetComponent<Button>();

        //        Invoke("Movement", 2);


        // Instanciate the PathMap object:
    }

    public static void StartLerping()
    {
//        Moving = true;

        lerpStartTime = Time.time;
        startPosition = BobPlayer.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement();
//        BobScale();
     //   Frame++;
        if (Moving)
        {
            //if (destination.y > BobPlayer.transform.position.y)
            //{
            //    BobPlayerAnimator.SetTrigger("BobUp");
            //}
            //else if (destination.y < BobPlayer.transform.position.y)
            //{
            //    BobPlayerAnimator.SetTrigger("BobDown");
            //}
            //else if (destination.x > BobPlayer.transform.position.x)
            //{
            //    BobPlayerAnimator.SetTrigger("BobRight");
            //}
            //else if (destination.x < BobPlayer.transform.position.x)
            //{
            //    BobPlayerAnimator.SetTrigger("BobLeft");
            //}

            float timeSinceStarted = Time.time - lerpStartTime;

            float percentageComplete = timeSinceStarted / 0.5F;   //Kävelynopeus


            BobPlayer.transform.position = Vector3.Lerp(startPosition, destination, percentageComplete);    //Muutetaan Bobin sijaintia kartan Lerp-vektoreilla.

            //            Debug.Log("percentageComplete = " + percentageComplete);
            if (percentageComplete >= 1.0F)
            {
                Moving = false;
                StandingLevelNumberX = midWayDestinationX;
                StandingLevelNumberY = midWayDestinationY;//Muutetaan seisomisobjektin arvo kohdeobjektin arvoksi
                Debug.Log("StandingLevelNumber = " + StandingLevelNumberX);
                Debug.Log("StandingLevelNumber2 = " + StandingLevelNumberY);
            }
        }
    }

    //void OnMouseDown()
    //{
    //    if (Input.mousePosition == Target.transform.position)
    //    {
    //        BobPlayerAnimator.SetTrigger("BobDown");
    //        StartLerping();
    //        Moving = true;
    //        destination = new Vector3(Target.transform.position.x, Target.transform.position.y);    //Kävellään kohdeobjektiin
    //    }
    //}

    

    public IEnumerator CountRoute() //Lasketaan etäisyys kohteesta buttonNumbereiden pohjalta
    {

        int routeX = DestinationLevelNumberX - StandingLevelNumberX;
        Debug.Log(DestinationLevelNumberX + "-" + StandingLevelNumberX + "=" + routeX);
        int routeY = DestinationLevelNumberY - StandingLevelNumberY;
        Debug.Log(DestinationLevelNumberY + "-" + StandingLevelNumberY + "=" + routeY);
        Debug.Log(routeX);
        Debug.Log(routeY);

        reitinpituus = Mathf.Abs(routeX) + Mathf.Abs(routeY);

        for (int i = 0; i < reitinpituus; i++)
        {
            reittiY = 0;
            reittiX = 0;

            if (routeX > 0)
            {
                reittiX = 1;
                routeX--;
            }
            else if (routeX < 0)
            {
                reittiX = -1;
                routeX++;
            }
            else if (routeX == 0)
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
            BobOnButton();

            yield return new WaitForSeconds(0.5f);
        }
    }

    void runRoute(int routeX, int routeY)
    {
        Moving = true;
        Debug.Log("routeX" + routeX);
        Debug.Log("routeY" + routeY);
        midWayDestinationX = StandingLevelNumberX;
        //Debug.Log(midWayDestinationX);
        midWayDestinationY = StandingLevelNumberY;
        //Debug.Log(midWayDestinationY);



        if (routeX > 0)
        {
            midWayDestinationX++;
        }
        else if (routeX < 0)
        {
            midWayDestinationX--;
        }
        else if (routeX == 0)
        {
            if (routeY > 0)
            {
                midWayDestinationY++;
            }
            else if (routeY < 0)
            {
                midWayDestinationY--;
            }
            else if (routeY == 0)
            {

            }
        }


        string levelName = "Level" + midWayDestinationX + midWayDestinationY;
        Debug.Log(levelName);
        GameObject midWayButton = GameObject.Find("Level" + midWayDestinationX + midWayDestinationY);
        destination.x = midWayButton.transform.position.x;
//        aboveButtonScale();
        destination.y = midWayButton.transform.position.y;

        Debug.Log("lähdetään liikkeelle");

        //BobPlayer.transform.position = destination;


        StartLerping();
        //BobPlayer.transform.position = Vector3.Lerp(startPosition, destination, 1.5f);
        StandingLevelNumberX = midWayDestinationX;
        StandingLevelNumberY = midWayDestinationY;

        PlayerPrefs.SetInt("Bobin kenttä X", StandingLevelNumberX);
        PlayerPrefs.SetInt("Bobin kenttä Y", StandingLevelNumberY);

        //yield return new WaitForSeconds(1);

    }

    ///IEnumerator waitForSeconds()
    //{
    //    yield return new WaitForSeconds(1);
    //}

    //public static void CheckNeighbour()     //Liikutaan vain yhtä suurempiin tai pienempiin arvoihin
    //{
    //    if ((StandingLevelNumber + 1 == DestinationLevelNumber || StandingLevelNumber - 1 == DestinationLevelNumber || StandingLevelNumber == DestinationLevelNumber)
    //        && (StandingLevelNumber2 + 1 == DestinationLevelNumber2 || StandingLevelNumber2 - 1 == DestinationLevelNumber2 || StandingLevelNumber2 == DestinationLevelNumber2))
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
        destination.y = destination.y + 0.5F;
        //gameObject.transform.position = destination;

        //StartLerping();
    }

    //public void aboveButtonScale()
    //{
    //    aboveButton = gameObject.transform.position.y * -0.2F;
    //    Debug.Log("aboveButton = " + aboveButton);
    //}

    //void OnTriggerEnter2D(Collider2D Col)
    //{
    //    if (Col.tag == "Rakennus1")     //Toiminto kun hitboxit törmäävät
    //    {
    //        Application.LoadLevel("GameScene");     //Mennään muistipeliin
    //    }
    //}
}
