using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    static readonly PlayerData instance = new PlayerData();

    //unlocked
    public bool[] SHIP_ID = {true, false, false, false };

    //selected ship for main game
    public int selectedShip;

    //Condition player can unlock ship
    private int index_unlock_Type_B_0;

    public static PlayerData Instance
    {
        get
        {
            return instance;
        }
    }

    //get
    public void setIndex_UnlockType_B_0()
    {
        index_unlock_Type_B_0++;
        if(instance.index_unlock_Type_B_0 >= 10)
        {
            SHIP_ID[1] = true;
            index_unlock_Type_B_0 = 10;
        }
    }

    //set
    public int getIndex_UnlockType_B_0()
    {
        return instance.index_unlock_Type_B_0;
    }
}
