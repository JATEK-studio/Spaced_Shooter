using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //Get player ship info
    private PlayerController playerController;

    private SoundManager soundManager;

    [SerializeField]
    private GameObject Type_AOrC_Panel, Type_B_Panel, Type_D_Panel, Pause_Panel, CountDown_Panel, GameOver_Panel;

    [SerializeField]
    private GameObject[] Type_C_Missile;

    [SerializeField]
    private Sprite[] Energy;

    [SerializeField]
    private Image Type_B_Battery;

    [SerializeField]
    private Text countDown;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        playerController = FindObjectOfType<PlayerController>();
        switch (playerController.shipType)
        {
            case PlayerController.SpaceShipType.TypeA:
                Type_AOrC_Panel.SetActive(true);
                Type_AOrC_Panel.transform.GetChild(1).gameObject.SetActive(true);
                Type_AOrC_Panel.transform.GetChild(2).gameObject.SetActive(false);
                Type_B_Panel.SetActive(false);
                Type_D_Panel.SetActive(false);
                break;
            case PlayerController.SpaceShipType.TypeB:
                Type_AOrC_Panel.SetActive(false);
                Type_AOrC_Panel.transform.GetChild(1).gameObject.SetActive(false);
                Type_B_Panel.SetActive(true);
                Type_D_Panel.SetActive(false);
                break;
            case PlayerController.SpaceShipType.TypeC:
                Type_AOrC_Panel.SetActive(true);
                Type_AOrC_Panel.transform.GetChild(1).gameObject.SetActive(false);
                Type_AOrC_Panel.transform.GetChild(2).gameObject.SetActive(true);
                Type_B_Panel.SetActive(false);
                Type_D_Panel.SetActive(false);
                break;
            case PlayerController.SpaceShipType.TypeD:
                Type_AOrC_Panel.SetActive(false);
                Type_AOrC_Panel.transform.GetChild(1).gameObject.SetActive(false);
                Type_B_Panel.SetActive(false);
                Type_D_Panel.SetActive(true);
                break;
        }
        Pause_Panel.SetActive(false);
        CountDown_Panel.SetActive(false);
        GameOver_Panel.SetActive(false);
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            if (Input.GetButton("Fire1"))
            {
                CountDown_Panel.SetActive(true);
                Resume();
            }
        }
        else if (playerController == null)
        {
            GameOver();
        }

        //Different Ship Different UI
        #region
        //Type B Energy UI
        if (playerController.shipType == PlayerController.SpaceShipType.TypeB)
        {
            Type_B_Battery.sprite = Energy[playerController.batteryUI];
        }

        //Type C missile ui
        if(playerController.shipType == PlayerController.SpaceShipType.TypeC)
        {
            for (int i = Type_C_Missile.Length; i > 0; i--)
            {
                if (playerController.missileCount >= i) Type_C_Missile[i-1].SetActive(true);
                else Type_C_Missile[i-1].SetActive(false);
            }

            // old version ui control
            /*
            switch (playerController.missileCount)
            {
                case 0:
                    foreach(GameObject missileIcon in Type_C_Missile)
                    {
                        missileIcon.SetActive(false);
                    }
                    break;
                case 1:
                    Type_C_Missile[0].SetActive(true);
                    Type_C_Missile[1].SetActive(false);
                    Type_C_Missile[2].SetActive(false);
                    Type_C_Missile[3].SetActive(false);
                    Type_C_Missile[4].SetActive(false);
                    Type_C_Missile[5].SetActive(false);
                    Type_C_Missile[6].SetActive(false);
                    Type_C_Missile[7].SetActive(false);
                    Type_C_Missile[8].SetActive(false);
                    Type_C_Missile[9].SetActive(false);
                    break;
                case 2:
                    Type_C_Missile[0].SetActive(true);
                    Type_C_Missile[1].SetActive(true);
                    Type_C_Missile[2].SetActive(false);
                    Type_C_Missile[3].SetActive(false);
                    Type_C_Missile[4].SetActive(false);
                    Type_C_Missile[5].SetActive(false);
                    Type_C_Missile[6].SetActive(false);
                    Type_C_Missile[7].SetActive(false);
                    Type_C_Missile[8].SetActive(false);
                    Type_C_Missile[9].SetActive(false);
                    break;
                case 3:
                    Type_C_Missile[0].SetActive(true);
                    Type_C_Missile[1].SetActive(true);
                    Type_C_Missile[2].SetActive(true);
                    Type_C_Missile[3].SetActive(false);
                    Type_C_Missile[4].SetActive(false);
                    Type_C_Missile[5].SetActive(false);
                    Type_C_Missile[6].SetActive(false);
                    Type_C_Missile[7].SetActive(false);
                    Type_C_Missile[8].SetActive(false);
                    Type_C_Missile[9].SetActive(false);
                    break;
                case 4:
                    Type_C_Missile[0].SetActive(true);
                    Type_C_Missile[1].SetActive(true);
                    Type_C_Missile[2].SetActive(true);
                    Type_C_Missile[3].SetActive(true);
                    Type_C_Missile[4].SetActive(false);
                    Type_C_Missile[5].SetActive(false);
                    Type_C_Missile[6].SetActive(false);
                    Type_C_Missile[7].SetActive(false);
                    Type_C_Missile[8].SetActive(false);
                    Type_C_Missile[9].SetActive(false);
                    break;
                case 5:
                    Type_C_Missile[0].SetActive(true);
                    Type_C_Missile[1].SetActive(true);
                    Type_C_Missile[2].SetActive(true);
                    Type_C_Missile[3].SetActive(true);
                    Type_C_Missile[4].SetActive(true);
                    Type_C_Missile[5].SetActive(false);
                    Type_C_Missile[6].SetActive(false);
                    Type_C_Missile[7].SetActive(false);
                    Type_C_Missile[8].SetActive(false);
                    Type_C_Missile[9].SetActive(false);
                    break;
                case 6:
                    Type_C_Missile[0].SetActive(true);
                    Type_C_Missile[1].SetActive(true);
                    Type_C_Missile[2].SetActive(true);
                    Type_C_Missile[3].SetActive(true);
                    Type_C_Missile[4].SetActive(true);
                    Type_C_Missile[5].SetActive(true);
                    Type_C_Missile[6].SetActive(false);
                    Type_C_Missile[7].SetActive(false);
                    Type_C_Missile[8].SetActive(false);
                    Type_C_Missile[9].SetActive(false);
                    break;
                case 7:
                    Type_C_Missile[0].SetActive(true);
                    Type_C_Missile[1].SetActive(true);
                    Type_C_Missile[2].SetActive(true);
                    Type_C_Missile[3].SetActive(true);
                    Type_C_Missile[4].SetActive(true);
                    Type_C_Missile[5].SetActive(true);
                    Type_C_Missile[6].SetActive(true);
                    Type_C_Missile[7].SetActive(false);
                    Type_C_Missile[8].SetActive(false);
                    Type_C_Missile[9].SetActive(false);
                    break;
                case 8:
                    Type_C_Missile[0].SetActive(true);
                    Type_C_Missile[1].SetActive(true);
                    Type_C_Missile[2].SetActive(true);
                    Type_C_Missile[3].SetActive(true);
                    Type_C_Missile[4].SetActive(true);
                    Type_C_Missile[5].SetActive(true);
                    Type_C_Missile[6].SetActive(true);
                    Type_C_Missile[7].SetActive(true);
                    Type_C_Missile[8].SetActive(false);
                    Type_C_Missile[9].SetActive(false);
                    break;
                case 9:
                    Type_C_Missile[0].SetActive(true);
                    Type_C_Missile[1].SetActive(true);
                    Type_C_Missile[2].SetActive(true);
                    Type_C_Missile[3].SetActive(true);
                    Type_C_Missile[4].SetActive(true);
                    Type_C_Missile[5].SetActive(true);
                    Type_C_Missile[6].SetActive(true);
                    Type_C_Missile[7].SetActive(true);
                    Type_C_Missile[8].SetActive(true);
                    Type_C_Missile[9].SetActive(false);
                    break;
                case 10:
                    Type_C_Missile[0].SetActive(true);
                    Type_C_Missile[1].SetActive(true);
                    Type_C_Missile[2].SetActive(true);
                    Type_C_Missile[3].SetActive(true);
                    Type_C_Missile[4].SetActive(true);
                    Type_C_Missile[5].SetActive(true);
                    Type_C_Missile[6].SetActive(true);
                    Type_C_Missile[7].SetActive(true);
                    Type_C_Missile[8].SetActive(true);
                    Type_C_Missile[9].SetActive(true);
                    break;
            }
            */
        }
        #endregion
    }

    public void Pause()
    {
        Time.timeScale = 0;
        Pause_Panel.SetActive(true);
        soundManager.AddLowPassFilter();
    }

    private void Resume()
    {       
        Pause_Panel.SetActive(false);
        countDown.text = "";
        CountDown_Panel.SetActive(true);
        StartCoroutine(WaitToResumeGame());
    }

    private void GameOver()
    {
        GameOver_Panel.SetActive(true);
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene(0);
        }
    }

    private IEnumerator WaitToResumeGame()
    {
        float endPause = Time.realtimeSinceStartup + 3;
        while (Time.realtimeSinceStartup < endPause)
        {
            countDown.text = "" + (int)(endPause - Time.realtimeSinceStartup - 1 * -1);
            yield return 0;
        }
        Time.timeScale = 1;
        CountDown_Panel.SetActive(false);
        soundManager.RemoveLowPassFilter();
    }
}
