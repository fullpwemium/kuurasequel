using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Kissa : MonoBehaviour {

    

    bool lattiaKissa;
    bool lattiaKissa2;
    bool parviKissa;
    bool parviKissa2;
    bool oviKissa;
    bool tuoliKissa;
    bool piippuKissa;
    bool takkaKissa;
    bool kasa1;
    bool kasa2;
    bool kasa3;
    bool kasa4;

    // GameObject[] kissat;

    public Sprite[] kissat;
    public Sprite[] kasat;
    public Sprite[] erikoiset;

    GameObject lattiaKissaGO;
    GameObject lattiaKissa2GO;
    GameObject parviKissaGO;
    GameObject parviKissa2GO;
    GameObject oviKissaGO;
    GameObject tuoliKissaGO;
    GameObject piippuKissaGO;
    GameObject takkaKissaGO;
    GameObject kasa1GO;
    GameObject kasa2GO;
    GameObject kasa3GO;
    GameObject kasa4GO;

    SpriteRenderer lattiaKissaSR;
    SpriteRenderer lattiaKissa2SR;
    SpriteRenderer parviKissaSR;
    SpriteRenderer parviKissa2SR;
    SpriteRenderer oviKissaSR;
    SpriteRenderer tuoliKissaSR;
    SpriteRenderer piippuKissaSR;
    SpriteRenderer takkaKissaSR;
    SpriteRenderer kasa1SR;
    SpriteRenderer kasa2SR;
    SpriteRenderer kasa3SR;
    SpriteRenderer kasa4SR;




    GameObject kissakuva;

    Tavara tavara;

    void Start () {

        tavara = gameObject.GetComponent<Tavara>();

        lattiaKissaGO = GameObject.Find("lattiaKissa");
        lattiaKissa2GO = GameObject.Find("lattiaKissa2");
        parviKissaGO = GameObject.Find("parviKissa");
        parviKissa2GO = GameObject.Find("parviKissa2");
        oviKissaGO = GameObject.Find("oviKissa");
        tuoliKissaGO = GameObject.Find("tuoliKissa");
        piippuKissaGO = GameObject.Find("piippukissa");
        takkaKissaGO = GameObject.Find("takkaKissa");
        kasa1GO = GameObject.Find("Kasa1");
        kasa2GO = GameObject.Find("Kasa2");
        kasa3GO = GameObject.Find("Kasa3");
        kasa4GO = GameObject.Find("Kasa4");

        lattiaKissaSR = lattiaKissaGO.GetComponent<SpriteRenderer>();
        lattiaKissa2SR = lattiaKissa2GO.GetComponent<SpriteRenderer>();
        parviKissaSR = parviKissaGO.GetComponent<SpriteRenderer>();
        parviKissa2SR = parviKissa2GO.GetComponent<SpriteRenderer>();
        oviKissaSR = oviKissaGO.GetComponent<SpriteRenderer>();
        tuoliKissaSR = tuoliKissaGO.GetComponent<SpriteRenderer>();
        piippuKissaSR = piippuKissaGO.GetComponent<SpriteRenderer>();
        takkaKissaSR = takkaKissaGO.GetComponent<SpriteRenderer>();
        kasa1SR = kasa1GO.GetComponent<SpriteRenderer>();
        kasa2SR = kasa2GO.GetComponent<SpriteRenderer>();
        kasa3SR = kasa3GO.GetComponent<SpriteRenderer>();
        kasa4SR = kasa4GO.GetComponent<SpriteRenderer>();


        lattiaKissaSR.sprite = kissat[kissaRandom()];
        lattiaKissa2SR.sprite = kissat[kissaRandom()];


    }


    public int kissaRandom()        // randomoi yksittäisten kissojen spritet
    {
        var rng = Random.Range(0, 5);
        return rng;
    }

    public int kasaRandom()         // randomoi kissakasojen spritet
    {
        var rng = Random.Range(0, 3);
        return rng;
    }
        
    public int erikoisRandom()       // randomoi erikoisten kissojen spritet (piippukissa)
    { 
        var rng = Random.Range(0, 3);
        return rng;
    }


    void Update () {

        if (tavara.boolReturn(1) == false)
        {
            oviKissaGO.SetActive(false);
        }
        else
        {
            oviKissaGO.SetActive(true);
            
        }


        if (tavara.boolReturn(2) == false)
        {
            parviKissaGO.SetActive(false);
            parviKissa2GO.SetActive(false);
            kasa2GO.SetActive(false);
        }
        else
        {
            parviKissaGO.SetActive(true);
            parviKissa2GO.SetActive(true);
            kasa2GO.SetActive(true);
        }


        if (tavara.boolReturn(3) == false) tuoliKissaGO.SetActive(false);
        else tuoliKissaGO.SetActive(true);

        if (tavara.boolReturn(4) == false) piippuKissaGO.SetActive(false);
        else piippuKissaGO.SetActive(true);

        if (Input.GetKeyDown("space"))
        {
            kuvaVaihto();
        }
      
    }

    void kuvaVaihto()               //Tämä suoritettavaksi esim scenen lataukseen
    {

        if (oviKissaGO.activeSelf == true) oviKissaSR.sprite = kissat[kissaRandom()];
        if (lattiaKissaGO.activeSelf == true) lattiaKissaSR.sprite = kissat[kissaRandom()];
        if (lattiaKissa2GO.activeSelf == true) lattiaKissa2SR.sprite = kissat[kissaRandom()];
        if (parviKissaGO.activeSelf == true) parviKissaSR.sprite = kissat[kissaRandom()];
        if (parviKissa2GO.activeSelf == true) parviKissa2SR.sprite = kissat[kissaRandom()];
        if (tuoliKissaGO.activeSelf == true) tuoliKissaSR.sprite = kissat[kissaRandom()];
        if (piippuKissaGO.activeSelf == true) piippuKissaSR.sprite = erikoiset[erikoisRandom()];
        if (takkaKissaGO.activeSelf == true) piippuKissaSR.sprite = kissat[kissaRandom()];
        kasa1SR.sprite = kasat[kasaRandom()];
        kasa2SR.sprite = kasat[kasaRandom()];
        kasa3SR.sprite = kasat[kasaRandom()];
        kasa4SR.sprite = kasat[kasaRandom()];

        //lattiaKissaSR = lattiaKissaGO.GetComponent<SpriteRenderer>();
        //lattiaKissa2SR = lattiaKissa2GO.GetComponent<SpriteRenderer>();
        //parviKissaSR = parviKissaGO.GetComponent<SpriteRenderer>();
        //parviKissa2SR = parviKissa2GO.GetComponent<SpriteRenderer>();
        //oviKissaSR = oviKissaGO.GetComponent<SpriteRenderer>();
        //tuoliKissaSR = tuoliKissaGO.GetComponent<SpriteRenderer>();
        //piippuKissaSR = piippuKissaGO.GetComponent<SpriteRenderer>();
        //takkaKissaSR = takkaKissaGO.GetComponent<SpriteRenderer>();
        //kasa1SR = kasa1GO.GetComponent<SpriteRenderer>();
        //kasa2SR = kasa2GO.GetComponent<SpriteRenderer>();
        //kasa3SR = kasa3GO.GetComponent<SpriteRenderer>();
        //kasa4SR = kasa4GO.GetComponent<SpriteRenderer>();


    }

    void kissaAnimaatio()
    {
       

    }




}
