using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectShip : MonoBehaviour
{
    [SerializeField]
    private GameObject DisplayShip, MainGame, selectShipGame;

    private bool selectShip;

    private int index;

    private void Start()
    {
        index = 0;
    }

    //Button
    public void RightArrow()
    {
        if(index <= 10)
        {
            index++;
            Vector3 desiredPos = DisplayShip.transform.position + new Vector3(-30, 0, 0);
            //Vector3 smoothePos = Vector3.Lerp(DisplayShip.transform.position, desiredPos, 0.125f);
            DisplayShip.transform.position = desiredPos;
        }
    }

    public void LeftArrow()
    {
        if(index >= 0)
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