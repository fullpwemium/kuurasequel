using UnityEngine;
using System.Collections;

public class Tavara : MonoBehaviour {

    bool Ovitausta = false;
    bool Kattoparrut = false;
    bool Parvi = false;
    bool Parvituki = false;
    bool Peti = false;
    bool Tikkaat = false;
    bool Tyyny = false;
    bool Tuoli = false;
    bool Uuni = false;
    bool Uuni_misc = false;
    bool Matto = false;

   

    GameObject OvitaustaGO;
    GameObject KattoparrutGO;
    GameObject ParviGO;
    GameObject ParvitukiGO;
    GameObject PetiGO;
    GameObject TikkaatGO;
    GameObject TyynyGO;
    GameObject TuoliGO;
    GameObject UuniGO;
    GameObject Uuni_miscGO;
    GameObject MattoGO;

    // Use this for initialization
    void Start() {
        OvitaustaGO = GameObject.Find("Ovitausta");
        KattoparrutGO = GameObject.Find("Kattoparrut");
        ParviGO = GameObject.Find("Parvi");
        ParvitukiGO = GameObject.Find("Parvituki");
        PetiGO = GameObject.Find("Peti");
        TikkaatGO = GameObject.Find("Tikkaat");
        TyynyGO = GameObject.Find("Tyyny");
        TuoliGO = GameObject.Find("Tuoli");
        UuniGO = GameObject.Find("Uuni");
        Uuni_miscGO = GameObject.Find("Uuni misc");
        MattoGO = GameObject.Find("Matto");
    }


    public bool toggle(bool toggle)
    {
        if (toggle == true)
        {
            toggle = false;
        }
        else if (toggle == false)
        {
            toggle = true;
        }
        return toggle;
    }


    public bool boolReturn(int boolIndex)
    {
        if (boolIndex == 1) return Ovitausta;

        else if (boolIndex == 2) return Parvi;

        else if (boolIndex == 3) return Tuoli;

        else if (boolIndex == 4) return Uuni;

        else return false;
    }


    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown("q"))   // Korvaa nämä ostamisella !!!!!! ja heitä kaikki updatesta starttiin
        {
           Ovitausta = toggle(Ovitausta);
            Debug.Log("Painettu Q " + "Ovi = " + Ovitausta);
        }
        if (Ovitausta == false) OvitaustaGO.SetActive(false);
        else OvitaustaGO.SetActive(true);



        if (Input.GetKeyDown("w"))
        {
            Kattoparrut = toggle(Kattoparrut);
            Debug.Log("Painettu W " + "Kattoparrut = " + Kattoparrut);
        }
        if (Kattoparrut == false) KattoparrutGO.SetActive(false);
        else KattoparrutGO.SetActive(true);



        if (Input.GetKeyDown("e"))
        {
            Parvi = toggle(Parvi);
            Debug.Log("Painettu E " + "Parvi = " + Parvi);
        }

        if (Parvi == false) ParviGO.SetActive(false);
        else ParviGO.SetActive(true);



        if (Input.GetKeyDown("r"))   
        {
            Parvituki = toggle(Parvituki);
            Debug.Log("Painettu R " + "Parvituki = " + Parvituki);
        }
        if (Parvituki == false) ParvitukiGO.SetActive(false);
        else ParvitukiGO.SetActive(true);



        if (Input.GetKeyDown("a"))
        {
            Peti = toggle(Peti);
            Debug.Log("Painettu A " + "Peti = " + Peti);
        }

        if (Peti == false) PetiGO.SetActive(false);
        else PetiGO.SetActive(true);



        if (Input.GetKeyDown("s"))
        {
            Tikkaat = toggle(Tikkaat);
            Debug.Log("Painettu S " + "Tikkaat = " + Tikkaat);
        }

        if (Tikkaat == false) TikkaatGO.SetActive(false);
        else TikkaatGO.SetActive(true);



        if (Input.GetKeyDown("d"))
        {
            Tyyny = toggle(Tyyny);
            Debug.Log("Painettu D " + "Tyyny = " + Tyyny);
        }

        if (Tyyny == false) TyynyGO.SetActive(false);
        else TyynyGO.SetActive(true);



        if (Input.GetKeyDown("f"))
        {
            Tuoli = toggle(Tuoli);
            Debug.Log("Painettu F " + "Tuoli = " + Tuoli);
        }

        if (Tuoli == false) TuoliGO.SetActive(false);
        else TuoliGO.SetActive(true);



        if (Input.GetKeyDown("z"))
        {
            Uuni = toggle(Uuni);
            Debug.Log("Painettu Z " + "Uuni = " + Uuni);
        }

        if (Uuni == false) UuniGO.SetActive(false);
        else UuniGO.SetActive(true);



        if (Input.GetKeyDown("x"))
        {
            Uuni_misc = toggle(Uuni_misc);
            Debug.Log("Painettu X " + "Uuni_misc = " + Uuni_misc);
        }

        if (Uuni_misc == false) Uuni_miscGO.SetActive(false);
        else Uuni_miscGO.SetActive(true);



        if (Input.GetKeyDown("c"))
        {
            Matto = toggle(Matto);
            Debug.Log("Painettu C " + "Matto = " + Matto);
        }

        if (Matto == false) MattoGO.SetActive(false);
        else MattoGO.SetActive(true);
        

        if (ParviGO.activeSelf == false)
        {
            PetiGO.SetActive(false);
            TyynyGO.SetActive(false);
            TikkaatGO.SetActive(false);
        }

        if (UuniGO.activeSelf == false)
        {
            Uuni_miscGO.SetActive(false);
        }



    }
}
