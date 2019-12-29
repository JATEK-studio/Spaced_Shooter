using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //Get player ship info
    private PlayerController playerController;

    [SerializeField]
    private GameObject Type_A_Panel, Type_B_Panel, Type_C_Panel, Type_D_Panel, Pause_Panel, CountDown_Panel;

    [SerializeField]
    private Text countDown;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        switch (playerController.shipType)
        {
            case PlayerController.SpaceShipType.TypeA:
                Type_A_Panel.SetActive(true);
                Type_B_Panel.SetActive(false);
                Type_C_Panel.SetActive(false);
                Type_D_Panel.SetActive(false);
                break;
            case PlayerController.SpaceShipType.TypeB:
                Type_A_Panel.SetActive(false);
                Type_B_Panel.SetActive(true);
                Type_C_Panel.SetActive(false);
                Type_D_Panel.SetActive(false);
                break;
            case PlayerController.SpaceShipType.TypeC:
                Type_A_Panel.SetActive(false);
                Type_B_Panel.SetActive(false);
                Type_C_Panel.SetActive(true);
                Type_D_Panel.SetActive(false);
                break;
            case PlayerController.SpaceShipType.TypeD:
                Type_A_Panel.SetActive(false);
                Type_B_Panel.SetActive(false);
                Type_C_Panel.SetActive(false);
                Type_D_Panel.SetActive(true);
                break;
        }
        Pause_Panel.SetActive(false);
        CountDown_Panel.SetActive(false);


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
    }

    public void Pause()
    {
        Time.timeScale = 0;
        Pause_Panel.SetActive(true);
    }

    private void Resume()
    {       
        Pause_Panel.SetActive(false);
        countDown.text = "";
        StartCoroutine(WaitToResumeGame());
    }

    private IEnumerator WaitToResumeGame()
    {
        float endPause = Time.realtimeSinceStartup + 3;
        while (Time.realtimeSinceStartup < endPause)
        {
            countDown.text = "" + (int)(endPause - Time.realtimeSinceStartup -1*-1);
            yield return 0;
        }
        Time.timeScale = 1;
        CountDown_Panel.SetActive(false);
    }
}
