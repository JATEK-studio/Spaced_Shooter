using UnityEngine;

public class CheckUnlocked : MonoBehaviour
{
    [SerializeField]
    private Material unlocked, locked;

    private void Update()
    {
        if(PlayerData.Instance.SHIP_ID[2] && this.name == "Display_Type_A_1")
        {
            this.GetComponent<Renderer>().material = unlocked;
        }
        else if (PlayerData.Instance.SHIP_ID[1] && this.name == "Display_Type_B_0")
        {
            this.transform.GetChild(0).GetComponent<Renderer>().material = unlocked;
            this.transform.GetChild(1).GetComponent<Renderer>().material = unlocked;
            this.transform.GetChild(2).GetComponent<Renderer>().material = unlocked;
        }
        else if (PlayerData.Instance.SHIP_ID[3] && this.name == "Display_Type_C_0")
        {
            this.GetComponent<Renderer>().material = unlocked;
        }
    }
}
