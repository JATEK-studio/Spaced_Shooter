using System.Collections;
using System.Collections.Generic;

public class PlayerData
{
    //unlocked
    public bool[] SHIP_ID = { true, false, false, false, false, false, false, false, false};

    //selected ship for main game
    public int selectedShip;

    //record
    public int destoryedMeteor, destoryedMeteorWater, destoryedEnemySpaceShip, destoryedSatellite, destoryedBoss, WatchedAds;

    static readonly PlayerData instance = new PlayerData();

    public static PlayerData Instance
    {
        get
        {
            return instance;
        }
    }

    //set
    public void setDestoryedMeteor()
    {
        instance.destoryedMeteor++;
        if (instance.destoryedMeteor == 50)
        {
            instance.SHIP_ID[1] = true;
        }
        if (instance.destoryedMeteor == 100)
        {
            instance.SHIP_ID[3] = true;
        }
        /*
        if(instance.destoryedMeteor == 150)
        {
            instance.SHIP_ID[7] = true;
        }
        */
        SaveSystem.SavePlayer();
    }

    public void setDestoryedSatellite()
    {
        instance.destoryedSatellite++;
    }

    public void setDestoryedWaterMeteor()
    {
        instance.destoryedMeteorWater++;
        if (instance.destoryedMeteorWater == 50)
        {
            instance.SHIP_ID[6] = true;
        }
        if(instance.destoryedMeteorWater == 150)
        {
            instance.SHIP_ID[7] = true;
        }
        SaveSystem.SavePlayer();
    }

    public void setDestoryedEnemySpaceShip()
    {
        instance.destoryedEnemySpaceShip++;
    }

    public void setDestoryedBoss()
    {
        instance.destoryedBoss++;
    }

    public void setWatchedAds()
    {
        instance.WatchedAds++;
        if (instance.WatchedAds == 5)
        {
            instance.SHIP_ID[4] = true;
        }
        if (instance.WatchedAds == 15)
        {
            instance.SHIP_ID[5] = true;
        }
        SaveSystem.SavePlayer();
    }

    //get
    public int getDestoryedSatellite()
    {
        return instance.destoryedSatellite;
    }

    public int getDestoryedMeteor()
    {
        return instance.destoryedMeteor;
    }

    public int getDestoryedWaterMeteor()
    {
        return instance.destoryedMeteorWater;
    }

    public int getDestoryedEnemySpaceShip()
    {
        return instance.destoryedEnemySpaceShip;
    }

    public int getDestoryedBoss()
    {
        return instance.destoryedBoss;
    }

    public int getWatchedAdsTime()
    {
        return instance.WatchedAds;
    }
}
