using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsInitializer : MonoBehaviour
{
    [SerializeField]
    private string
        androidGameId = "1094862",
        iosGameId = "1094871";

    [SerializeField]
    private bool testMode;

    void Start()
    {
        string gameId = null;

#if UNITY_ANDROID
        gameId = androidGameId;
#elif UNITY_IOS
        gameId = iosGameId;
#endif

        if (Advertisement.isSupported && !Advertisement.isInitialized)
        {
            Advertisement.Initialize(gameId, testMode);
        }
    }
}