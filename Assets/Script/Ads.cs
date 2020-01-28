using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class Ads : MonoBehaviour
{
    private GameObject adsButtonGameObject, adsCoolingDown;

    private Button adsButton;

    private const float CDtime = 60f;

    private const string GooglePlayID = "3420912";

    private static bool cd = false;

    private static Ads adsInstance;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (adsInstance == null)
        {
            adsInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        adsCoolingDown = GameObject.FindGameObjectWithTag("AdsCoolingDown");
        adsButtonGameObject = GameObject.FindGameObjectWithTag("AdsButton");
        adsButton = adsButtonGameObject.GetComponent<Button>();
        //your GameID for showing ad
        Advertisement.Initialize(GooglePlayID, false);
        adsButton.onClick.AddListener(ShowAd);
    }

    private void FixedUpdate()
    {
        if (adsButtonGameObject == null)
        {
            adsButtonGameObject = GameObject.FindGameObjectWithTag("AdsButton");
            adsButton = adsButtonGameObject.GetComponent<Button>();
            adsButton.onClick.AddListener(ShowAd);
        }
        if (adsCoolingDown == null)
        {
            adsCoolingDown = GameObject.FindGameObjectWithTag("AdsCoolingDown");
        }
    }

    private void LateUpdate()
    {
        if (adsButtonGameObject != null && adsCoolingDown != null)
        {
            adsButtonGameObject.SetActive(!cd);
            adsCoolingDown.SetActive(cd);
        }
    }

    //put showAd() on the button which stands for watching ad
    public void ShowAd()
    {
        if (Advertisement.isShowing == false && cd == false)
        {
            if (Advertisement.IsReady("rewardedVideo"))
            {
                Advertisement.Show("rewardedVideo");
                Getreward();
                cooldown();
            }
        }
    }

    private static void Getreward()
    {
        //rewards
        PlayerData.Instance.setWatchedAds();
    }

    private void cooldown()
    {
        if (!cd)
        {
            cd = true;
            Invoke("refreshcd", CDtime);
        }
    }

    private void refreshcd()
    {
        cd = false;
    }
}
