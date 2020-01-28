using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectShip : MonoBehaviour
{
    [SerializeField]
    private GameObject DisplayShip, MainGame, selectShipGame;

    [SerializeField]
    private Text lockText, tipText, recordText;

    [SerializeField]
    private GameObject leftArrow, rightArrow;

    [SerializeField]
    private GameObject MainPanel, SettingPanel, PatchPanel, RecordPanel;

    [SerializeField]
    private Sprite[] Sound;

    [SerializeField]
    private Image MuteButton;

    [SerializeField]
    private Slider BGM, SoundEffect;

    private bool selectShip;

    private int index;

    private SoundManager soundManager;

    private bool mute;

    private void Start()
    {
        mute = false;
        soundManager = FindObjectOfType<SoundManager>();
        if(SaveSystem.LoadPlayer() == null)
        {
            SaveSystem.SavePlayer();
        }
        else
        {
            for(int i = 0; i < SaveSystem.LoadPlayer().TempSHIP_ID.Length; i++)
            {
                PlayerData.Instance.SHIP_ID[i] = SaveSystem.LoadPlayer().TempSHIP_ID[i];
            }
            PlayerData.Instance.destoryedMeteor = SaveSystem.LoadPlayer().TempMeteorDestory;
            PlayerData.Instance.destoryedMeteorWater = SaveSystem.LoadPlayer().TempDestroyedMeteorWater;
            PlayerData.Instance.destoryedEnemySpaceShip = SaveSystem.LoadPlayer().TempDestroyedEnemySpaceShip;
            PlayerData.Instance.destoryedBoss = SaveSystem.LoadPlayer().TempDestroyedBoss;
            PlayerData.Instance.WatchedAds = SaveSystem.LoadPlayer().TempWatchAdsTimes;
        }
        //Record Text
        recordText.text =
            PlayerData.Instance.getDestoryedMeteor() + "\n" +
            PlayerData.Instance.getDestoryedWaterMeteor() + "\n" +
            PlayerData.Instance.getDestoryedEnemySpaceShip() + "\n" +
            PlayerData.Instance.getDestoryedSatellite() + "\n" +
            PlayerData.Instance.getDestoryedBoss() + "\n" +
            PlayerData.Instance.getWatchedAdsTime();
        index = 0;
        soundManager.AddLowPassFilter();
    }

    private void FixedUpdate()
    {
        //Text
        if (!PlayerData.Instance.SHIP_ID[index])
        {
            lockText.text = "LOCKED";
            switch (index)
            {
                case 0:
                    tipText.text = "";
                    break;
                case 1:
                    tipText.text = "Destory " + (50 - PlayerData.Instance.getDestoryedMeteor()) + " Meteors";
                    break;
                case 2:
                    tipText.text = "Destory this ship in the game";
                    break;
                case 3:
                    tipText.text = "Destory " + (100 - PlayerData.Instance.getDestoryedMeteor()) + " Meteors";
                    break;
                case 4:
                    tipText.text = "Watch " + (5 - PlayerData.Instance.getWatchedAdsTime()) + " Ads";
                    break;
                case 5:
                    tipText.text = "Watch " + (15 - PlayerData.Instance.getWatchedAdsTime()) + " Ads";
                    break;
                case 6:
                    tipText.text = "Destory " + (50 - PlayerData.Instance.getDestoryedWaterMeteor()) + " Water Meteors";
                    break;
                case 7:
                    tipText.text = "Destory " + (150 - PlayerData.Instance.getDestoryedWaterMeteor()) + " Water Meteors";
                    break;
                case 8:
                    tipText.text = "Destory " + (100 - PlayerData.Instance.getDestoryedSatellite()) + " Satellite";
                    break;
            }
        }
        else
        {
            lockText.text = "";
            tipText.text = "";
        }        

        //UI arrow
        if(index == 8)
        {
            rightArrow.SetActive(false);
        }
        else if(index == 0)
        {
            leftArrow.SetActive(false);
        }
        else
        {
            rightArrow.SetActive(true);
            leftArrow.SetActive(true);
        }

        soundManager.AdjustBGMVolume(BGM.value);
        soundManager.AdjustSoundEffectVolume(SoundEffect.value);
    }

    //Button
    public void RightArrow()
    {
        if (index < 8)
        {
            index++;
            Vector3 desiredPos = DisplayShip.transform.position + new Vector3(-30, 0, 0);
            //Vector3 smoothePos = Vector3.Lerp(DisplayShip.transform.position, desiredPos, 0.125f);
            DisplayShip.transform.position = desiredPos;
            soundManager.PlaySoundEffect(0);
        }
    }

    public void LeftArrow()
    {
        if(index > 0)
        {
            index--;
            Vector3 desiredPos = DisplayShip.transform.position + new Vector3(30, 0, 0);
            //Vector3 smoothePos = Vector3.Lerp(DisplayShip.transform.position, desiredPos, Time.deltaTime);
            DisplayShip.transform.position = desiredPos;
            soundManager.PlaySoundEffect(0);
        }
    }

    public void comfirmSelectedShip()
    {
        if (PlayerData.Instance.SHIP_ID[index])
        {
            PlayerData.Instance.selectedShip = index;
            selectShipGame.SetActive(false);
            MainGame.SetActive(true);
            soundManager.PlaySoundEffect(0);
            soundManager.RemoveLowPassFilter();
        }
    }

    public void Mute()
    {
        if (!mute)
        {
            soundManager.MuteAll();
            MuteButton.sprite = Sound[1];
            mute = true;
        }
        else
        {
            soundManager.UnMuteAll();
            MuteButton.sprite = Sound[0];
            mute = false;
        }
    }

    public void SettingButton()
    {
        MainPanel.SetActive(false);
        SettingPanel.SetActive(true);
        soundManager.PlaySoundEffect(0);
    }

    public void Back2MainPanel()
    {
        MainPanel.SetActive(true);
        SettingPanel.SetActive(false);
        PatchPanel.SetActive(false);
        RecordPanel.SetActive(false);
        soundManager.PlaySoundEffect(0);
    }

    public void PatchButton()
    {
        MainPanel.SetActive(false);
        PatchPanel.SetActive(true);
        soundManager.PlaySoundEffect(0);
    }

    public void RecordButton()
    {
        MainPanel.SetActive(false);
        RecordPanel.SetActive(true);
        soundManager.PlaySoundEffect(0);
    }
}