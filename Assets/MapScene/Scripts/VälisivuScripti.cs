using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class VälisivuScripti : MonoBehaviour
{
    //Button button;
    GameObject muutNapit;
    GameObject BobPlayer;
    Image peliKuva;
    static public int page;
    public int suunta;
    float startTime;
    Vector2 startPos;
    public Button button1, button2, button3, button4, button5;
    public GameObject tausta;
    Image Hahmo;
    bool moving;

    public GameObject kylttiKissa;

    public GameObject kyltti1;
    public GameObject kyltti2;

    Vector3 kylttiKissaDestination, kylttiKissaStartPosition, kyltti1Destination, kyltti1StartPosition, kyltti2Destination, kyltti2StartPosition;

    int peliNumero;
    Text dialogi;
    Text title;

    public Sprite pelikuva1, pelikuva2, pelikuva3, pelikuva4, pelikuva5;
    public Sprite hahmo1, hahmo2, hahmo3, hahmo4, hahmo5;

    public Vector3 destination;
    float lerpStartTime;
    float timeStartedLerping;
    float timeTakenDuringLerp;

    Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        BobPlayer = GameObject.Find("BobPlayer");

        //button = GetComponent<Button>();
        button1.onClick.AddListener(buttonpressed);
        button2.onClick.AddListener(buttonpressed);
        button3.onClick.AddListener(buttonpressed);
        button4.onClick.AddListener(buttonpressed);
        button5.onClick.AddListener(buttonpressed);

        //tausta = GameObject.Find("Image");

        Debug.Log("Screen width: "+Screen.width);
        Debug.Log("Image position: " + tausta.transform.localPosition);


        //tausta.transform.localPosition = new Vector3(tausta.transform.position.x + 2300, tausta.transform.localPosition.y, tausta.transform.position.z);


        Debug.Log("Image position: " + tausta.transform.localPosition);



        destination = tausta.transform.position;

        kylttiKissa.transform.position = new Vector3(kylttiKissa.transform.position.x, kylttiKissa.transform.position.y - Screen.height / 30, kylttiKissa.transform.position.z);
        kylttiKissaDestination = kylttiKissa.transform.position;

        kyltti1.transform.position = new Vector3(kyltti1.transform.position.x, kyltti1.transform.position.y - Screen.height / 30, kyltti1.transform.position.z);
        kyltti1Destination = kyltti1.transform.position;

        kyltti2.transform.position = new Vector3(kyltti2.transform.position.x, kyltti2.transform.position.y - Screen.height / 30, kyltti2.transform.position.z);
        kyltti2Destination = kyltti2.transform.position;

        //button = GetComponent<Button>();
        //button.onClick.AddListener(buttonpressed);
        peliKuva = GameObject.Find("PeliKuva").GetComponent<Image>();
        title = GameObject.Find("Title").GetComponent<Text>();
        dialogi = GameObject.Find("Dialogia").GetComponent<Text>();
        Hahmo = GameObject.Find("Kissa").GetComponent<Image>();

    }

    void buttonpressed()
    {

        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;
        button4.interactable = false;

        button5.interactable = false;


        if (BobPlayerScript.StandingButtonNumberX == 0 && BobPlayerScript.StandingButtonNumberY == 3)
        {
            peliNumero = 1;
            BobPlayerScript.nearMemoryGame = true;
            title.text = "Mister Mysterious Mystic Cards";
            dialogi.text = "- Hope you have a good memory!\n- Try to find images above Bob.";
            peliKuva.sprite = pelikuva1;
        }
        else if(BobPlayerScript.StandingButtonNumberX == 0 && BobPlayerScript.StandingButtonNumberY == 2)
        {
            peliNumero = 2;
            BobPlayerScript.nearLabyrinth = true;
            title.text = "Winter Hedge Maze";
            dialogi.text = "-	Don't let Swipper get you!\n- Watch the floor...";
            peliKuva.sprite = pelikuva2;
            Hahmo.sprite = hahmo2;
        }
        else if (BobPlayerScript.StandingButtonNumberX == 0 && BobPlayerScript.StandingButtonNumberY == 1)
        {
            peliNumero = 3;
            BobPlayerScript.nearCatchTheCat = true;
            title.text = "Bubble Warehouse";
            dialogi.text = "-	What a nasty snowflake!\n- Get cake to grow your bowl!";
            peliKuva.sprite = pelikuva3;
            
        }
        else if (BobPlayerScript.StandingButtonNumberX == 2 && BobPlayerScript.StandingButtonNumberY == 3)
        {
            peliNumero = 4;
            BobPlayerScript.Runner = true;
            title.text = "Winter Forest Marathon";
            dialogi.text = "- Make all the coins come to you with magnet!\n- Don't forget you can JUMP again while midair!";
            peliKuva.sprite = pelikuva4;
        }
        else if (BobPlayerScript.StandingButtonNumberX == 2 && BobPlayerScript.StandingButtonNumberY == 0)
        {
            peliNumero = 5;
            BobPlayerScript.nearBobApartment = true;
            title.text = "Bob's apartment";
            dialogi.text = "- Smooth Kuura to get Magic Dust.\n- Watch ad to get even more Magic Dust.";
            peliKuva.sprite = pelikuva5;
        }

        kylttiKissaDestination = new Vector3(kylttiKissa.transform.position.x, kylttiKissa.transform.position.y + Screen.height / 30, kylttiKissa.transform.position.z);

        kyltti1Destination = new Vector3(kyltti1.transform.position.x, kyltti1.transform.position.y + Screen.height / 30, kyltti1.transform.position.z);

        kyltti2Destination = new Vector3(kyltti2.transform.position.x, kyltti2.transform.position.y + Screen.height / 30, kyltti2.transform.position.z);

        BobPlayer.SetActive(false);

            //destination = new Vector3(tausta.transform.position.x * 1 * Time.deltaTime, tausta.transform.position.y, tausta.transform.position.z);

            if (suunta == 0)
            {
                destination = new Vector3(tausta.transform.position.x + Screen.width, tausta.transform.position.y, tausta.transform.position.z);
            }
            else if (suunta == 1)
            {
                destination = new Vector3(.7f, tausta.transform.position.y, tausta.transform.position.z);
            }
            else if (suunta == 2)
            {
                destination = new Vector3(tausta.transform.position.x, tausta.transform.position.y - Screen.height / 80, tausta.transform.position.z);
            }
            else if (suunta == 3)
            {
                destination = new Vector3(tausta.transform.position.x, tausta.transform.position.y + Screen.height / 80, tausta.transform.position.z);
            }
            StartLerping();
            Debug.Log(Screen.width);
            Debug.Log(destination);
            moving = true;
            //tausta.transform.position = Vector3.Lerp(tausta.transform.position, destination, 0.5f * Time.deltaTime);
            //tausta.transform.position = new Vector3(tausta.transform.position.x * 1 * Time.deltaTime, tausta.transform.position.y, tausta.transform.position.z);
            Debug.Log(suunta);
    }

    void StartLerping()
    {
        moving = true;
        lerpStartTime = Time.time;
        startPosition = tausta.transform.position;

        kylttiKissaStartPosition = kylttiKissa.transform.position;
        kyltti1StartPosition = kyltti1.transform.position;
        kyltti2StartPosition = kyltti2.transform.position;
    }

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            float timeSinceStarted = Time.time - lerpStartTime;
            float percentageComplete = timeSinceStarted / 1.5f;
            //Debug.Log(percentageComplete);

            kylttiKissa.transform.position = Vector3.Lerp(kylttiKissaStartPosition, kylttiKissaDestination, percentageComplete);
            kyltti1.transform.position = Vector3.Lerp(kyltti1StartPosition, kyltti1Destination, percentageComplete);
            kyltti2.transform.position = Vector3.Lerp(kyltti2StartPosition, kyltti2Destination, percentageComplete);

            tausta.transform.position = Vector3.Lerp(startPosition, destination, percentageComplete);
            //Debug.Log(tausta.transform.position);
            if (percentageComplete >= 1.0f)
            {
                moving = false;
            }
        }
    }
}

