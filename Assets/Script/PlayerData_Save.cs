[System.Serializable]
public class PlayerData_Save
{
    private int arrayLenght = PlayerData.Instance.SHIP_ID.Length;

    public bool[] TempSHIP_ID = new bool[PlayerData.Instance.SHIP_ID.Length];

    public int TempMeteorDestory, TempDestroyedMeteorWater, TempDestroyedEnemySpaceShip, TempDestroyedBoss, TempWatchAdsTimes;

    public PlayerData_Save()
    {
        TempMeteorDestory = PlayerData.Instance.getDestoryedMeteor();
        TempDestroyedMeteorWater = PlayerData.Instance.getDestoryedWaterMeteor();
        TempDestroyedEnemySpaceShip = PlayerData.Instance.getDestoryedEnemySpaceShip();
        TempDestroyedBoss = PlayerData.Instance.getDestoryedBoss();
        TempWatchAdsTimes = PlayerData.Instance.getWatchedAdsTime();
        for (int i = 0; i < arrayLenght; i++)
        {
            TempSHIP_ID[i] = PlayerData.Instance.SHIP_ID[i];
        }
    }
}
