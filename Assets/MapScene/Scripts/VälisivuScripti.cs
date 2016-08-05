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
    bool moving;

    public GameObject kylttiKissa;

    public GameObject kyltti1;
    public GameObject kyltti2;

    Vector3 kylttiKissaDestination, kylttiKissaStartPosition, kyltti1Destination, kyltti1StartPosition, kyltti2Destination, kyltti2StartPosition;

    int peliNumero;
    Text dialogi;
    Text title;

    public Sprite pelikuva1, pelikuva2, pelikuva3, pelikuva4, pelikuva5;

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
       // button5.onClick.AddListener(buttonpressed);

        //tausta = GameObject.Find("Image");
        tausta.transform.position = new Vector3(tausta.transform.position.x + Screen.width/30, tausta.transform.position.y, tausta.transform.position.z);
        Debug.Log(Screen.width);
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

    }

    void buttonpressed()
    {

        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;
        button4.interactable = false;
        //button5.interactable = false;


        if (BobPlayerScript.StandingButtonNumberX == 0 && BobPlayerScript.StandingButtonNumberY == 3)
        {
            peliNumero = 1;
            title.text = "BAAANAANAAA";
            dialogi.text = "nananananananananananananananaanananan BATMAN!";
            peliKuva.sprite = pelikuva1;
        }
        else if(BobPlayerScript.StandingButtonNumberX == 0 && BobPlayerScript.StandingButtonNumberY == 1)
        {
            peliNumero = 2;
            title.text = "BAAANAANAAA2222";
            dialogi.text = "nananananananananananananananaanananan BATMAN!WTF";
            peliKuva.sprite = pelikuva2;
        }
        else if (BobPlayerScript.StandingButtonNumberX == 2 && BobPlayerScript.StandingButtonNumberY == 1)
        {
            peliNumero = 3;
            title.text = "BAAANAANAAA3333";
            dialogi.text = "nananananananananananananananaanananan BATMAN!WTF madafaka!";
            peliKuva.sprite = pelikuva3;
        }
        else if (BobPlayerScript.StandingButtonNumberX == 2 && BobPlayerScript.StandingButtonNumberY == 3)
        {
            peliNumero = 4;
            title.text = "BAAANAANAAA4444";
            dialogi.text = "nananananananananananananananaanananan BATMAN!WTF BBQ";
            peliKuva.sprite = pelikuva4;
        }
        else if (BobPlayerScript.StandingButtonNumberX == 1 && BobPlayerScript.StandingButtonNumberY == 3)
        {
            peliNumero = 5;
            title.text = "BAAANAANAAA5555";
            dialogi.text = "nananananananananananananananaanananan BATMAN!WTF BBQ 5555";
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
                destination = new Vector3(tausta.transform.position.x - Screen.width/30, tausta.transform.position.y, tausta.transform.position.z);   
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
            Debug.Log(percentageComplete);

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

