using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectShip : MonoBehaviour
{
    [SerializeField]
    private GameObject DisplayShip, MainGame, selectShipGame;

    [SerializeField]
    private Text lockText;

    [SerializeField]
    private GameObject leftArrow, rightArrow;

    private bool selectShip;

    private int index;

    private void Start()
    {
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
        }
        index = 0;
    }

    private void FixedUpdate()
    {
        //Text
        if (!PlayerData.Instance.SHIP_ID[index])
        {
            lockText.text = "LOCKED";
        }
        else
        {
            lockText.text = "";
        }

        //UI arrow
        if(index == 10)
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
    }

    //Button
    public void RightArrow()
    {
        if (index < 10)
        {
            index++;
            Vector3 desiredPos = DisplayShip.transform.position + new Vector3(-30, 0, 0);
            //Vector3 smoothePos = Vector3.Lerp(DisplayShip.transform.position, desiredPos, 0.125f);
            DisplayShip.transform.position = desiredPos;
        }
    }

    public void LeftArrow()
    {
        if(index > 0)
        {
            index--;
            Vector3 desiredPos = DisplayShip.transform.position + new Vector3(30, 0, 0);
            //Vector3 smoothePos = Vector3.Lerp(DisplayShip.transform.position, desiredPos, 0.125f);
            DisplayShip.transform.position = desiredPos;
        }
    }

    public void comfirmSelectedShip()
    {
        if (PlayerData.Instance.SHIP_ID[index])
        {
            PlayerData.Instance.selectedShip = index;
            selectShipGame.SetActive(false);
            MainGame.SetActive(true);
        }
        else
        {
            //a text tell player that this ship is not yet unlock
        }
    }
}