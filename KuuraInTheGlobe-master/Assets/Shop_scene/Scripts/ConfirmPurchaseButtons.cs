using UnityEngine;
using System.Collections;

public class ConfirmPurchaseButtons : MonoBehaviour {

    public void PlayConfirmBuySound() {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.keyCollected, 1);
    }

    public void PlayCancelSound()
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuCancel, 1);
    }

}
