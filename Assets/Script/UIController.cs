using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    //Get player ship info
    private PlayerController playerController;

    [SerializeField]
    private GameObject Type_A_Panel, Type_B_Panel, Type_C_Panel, Type_D_Panel;

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
    }

    private void Update()
    {
        
    }
}
