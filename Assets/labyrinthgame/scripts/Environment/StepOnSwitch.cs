using UnityEngine;
using System.Collections;

public class StepOnSwitch : SwitchActivate
{
    void Start()
    {

    }
    //Solve player trigger problem
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerPush"))
        {
            MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.doorUnlocked, 1);
            Activate();
        }
    }
    /*protected override void Activate()
    {
        base.Activate();
    }*/
}
