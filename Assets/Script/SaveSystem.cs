using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData_Save data = new PlayerData_Save();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData_Save LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData_Save data = formatter.Deserialize(stream) as PlayerData_Save;
            stream.Close();

            return data;
        }
        else
        {
            SavePlayer();
            return null;
        }
    }
}
