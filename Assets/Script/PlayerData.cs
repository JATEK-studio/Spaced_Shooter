using System.Collections;
using System.Collections.Generic;

public class PlayerData
{
    //unlocked
    public bool[] SHIP_ID = { true, false, false, false };

    //selected ship for main game
    public int selectedShip;

    //Condition player can unlock ship
    private int index_unlock_Type_B_0;

    static readonly PlayerData instance = new PlayerData();

    public static PlayerData Instance
    {
        get
        {
            return instance;
        }
    }

    //set
    public void setIndex_UnlockType_B_0(bool unlocked)
    {
        if (!unlocked)
        {
            index_unlock_Type_B_0++;
            if (instance.index_unlock_Type_B_0 >= 10)
            {
                SHIP_ID[1] = true;
                index_unlock_Type_B_0 = 10;
                SaveSystem.SavePlayer();
            }
        }
        else
        {
            SHIP_ID[1] = true;
            index_unlock_Type_B_0 = 10;
        }

    }

    //get
    public int getIndex_UnlockType_B_0()
    {
        return instance.index_unlock_Type_B_0;
    }
}
