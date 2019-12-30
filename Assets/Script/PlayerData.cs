using System.Collections;
using System.Collections.Generic;

public class PlayerData
{
    //unlocked
    public bool[] SHIP_ID = { true, false, false, false, false, false, false, false};

    //selected ship for main game
    public int selectedShip;

    //Condition player can unlock ship
    private int index_unlock;

    //record
    private int destroyedMeteor, destroyedMeteorWater, destroyedEnemySpaceShip, destroyedBoss;

    static readonly PlayerData instance = new PlayerData();

    public static PlayerData Instance
    {
        get
        {
            return instance;
        }
    }

    //set
    public void setIndex_Unlock()
    {
        index_unlock++;
        if (instance.index_unlock >= 10)
        {
            SHIP_ID[1] = true;
            SaveSystem.SavePlayer();
        }
        else if (instance.index_unlock >= 3)
        {
            SHIP_ID[3] = true;
            SaveSystem.SavePlayer();
        }
        
    }

    //get
    public int getIndex_Unlock()
    {
        return instance.index_unlock;
    }
}
