using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EmitterController : MonoBehaviour {

    
    DustController sc1;
    // public int scratchCounter;
    // public int happinessCounter;
    //public int DustAmount = GlobalManager.MagicDust;
    public int DustAmount = GlobalGameManager.MagicDust;
    public Text dustAmount;
    public int timer;
    // Use this for initialization
    void Start()
    {
        DustAmount = PlayerPrefs.GetInt("Magic Dust ");
        sc1 = dustAmount.GetComponent<DustController>();
        sc1.UpdateDust();
    }
    void OnEnable()
    {
        InvokeRepeating("UpdateDust", 2, 2);
    }

    //Gives player dust, reactivates emissions and updates the amount of dust text
    void UpdateDust()
    {       
        if (gameObject.activeSelf == true)
        {
            timer = HappinessController.happinessMultiplier;
            sc1.GetDust(timer);
            ParticleSystem em = GetComponent<ParticleSystem>();
            em.Stop();
            em.Play();
            DustAmount = PlayerPrefs.GetInt("Magic Dust ");
            sc1.UpdateDust();          
        }
        else
        {
            CancelInvoke();
           // scratchCounter = 0;
        }
    }
}
