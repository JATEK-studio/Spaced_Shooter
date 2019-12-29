[System.Serializable]
public class PlayerData_Save
{
    private int arrayLenght = PlayerData.Instance.SHIP_ID.Length;

    public bool[] TempSHIP_ID = new bool[PlayerData.Instance.SHIP_ID.Length];

    public PlayerData_Save()
    {
        for(int i = 0; i < arrayLenght; i++)
        {
            TempSHIP_ID[i] = PlayerData.Instance.SHIP_ID[i];
        }
    }
}
