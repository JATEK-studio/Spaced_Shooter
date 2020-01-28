using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hazard, fight2unlockShip, boss;

    [SerializeField]
    private Vector3 spawnValues;

    [SerializeField]
    private float startHazardWait, hazardWaveWait;
    private float spawnHazardWait;

    [SerializeField]
    private GameObject[] SpaceShip;

    private bool fight2getShip = false;

    private void Awake()
    {        
        Instantiate(SpaceShip[PlayerData.Instance.selectedShip], Vector3.zero, Quaternion.identity);
    }

    // Start is called before the first frame update
    private void Start()
    {
        spawnHazardWait = 1f;
        StartCoroutine(StartSpawnHazardWave());
    }

    private IEnumerator StartSpawnHazardWave()
    {
        while (true)
        {
            //Wave 1            
            yield return new WaitForSeconds(startHazardWait);
            for (int i = 0; i < Random.Range(10, 25); i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                //hazard
                GameObject cloneHazard = Instantiate(hazard[0], spawnPosition, spawnRotation) as GameObject;

                //random size
                int size = (int)Random.Range(15, 30);
                Vector3 randomSize = new Vector3(size, size, size);
                cloneHazard.transform.localScale = randomSize;
                Destroy(cloneHazard, 7);
                yield return new WaitForSeconds(spawnHazardWait);
            }
            spawnHazardWait = 0.5f;
            //Wave 2
            yield return new WaitForSeconds(startHazardWait);
            for (int i = 0; i < Random.Range(10, 25); i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                //hazard
                GameObject cloneHazard = Instantiate(hazard[0], spawnPosition, spawnRotation) as GameObject;

                //random size
                int size = (int)Random.Range(15, 30);
                Vector3 randomSize = new Vector3(size, size, size);
                cloneHazard.transform.localScale = randomSize;
                Destroy(cloneHazard, 7);
                yield return new WaitForSeconds(spawnHazardWait);
            }
            spawnHazardWait = 0.4f;
            //Wave 3
            yield return new WaitForSeconds(startHazardWait);
            for (int i = 0; i < Random.Range(20, 25); i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                //hazard
                GameObject cloneHazard = Instantiate(hazard[0], spawnPosition, spawnRotation) as GameObject;
                int size = (int)Random.Range(15, 30);
                Vector3 randomSize = new Vector3(size, size, size);
                cloneHazard.transform.localScale = randomSize;
                Destroy(cloneHazard, 7);
                yield return new WaitForSeconds(spawnHazardWait);

                //hazard 2
                Vector3 spawnPosition_2 = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                GameObject cloneHazard_2 = Instantiate(hazard[1], spawnPosition_2, spawnRotation) as GameObject;
                cloneHazard_2.transform.localScale = randomSize;
                Destroy(cloneHazard_2, 7);
                yield return new WaitForSeconds(spawnHazardWait);
            }
            spawnHazardWait = 0.3f;
            //Wave 4
            yield return new WaitForSeconds(startHazardWait);
            for (int i = 0; i < Random.Range(20, 25); i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                //hazard
                GameObject cloneHazard = Instantiate(hazard[0], spawnPosition, spawnRotation) as GameObject;
                int size = (int)Random.Range(15, 30);
                Vector3 randomSize = new Vector3(size, size, size);
                cloneHazard.transform.localScale = randomSize;
                Destroy(cloneHazard, 7);
                yield return new WaitForSeconds(spawnHazardWait);

                //hazard 2
                Vector3 spawnPosition_2 = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                GameObject cloneHazard_2 = Instantiate(hazard[1], spawnPosition_2, spawnRotation) as GameObject;
                cloneHazard_2.transform.localScale = randomSize;
                Destroy(cloneHazard_2, 7);
                yield return new WaitForSeconds(spawnHazardWait);

                if ((int)Random.Range(0, 100) < 10 && !PlayerData.Instance.SHIP_ID[2] && !fight2getShip)
                {
                    Vector3 spawnPosition_3 = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    GameObject cloneEnemy = Instantiate(fight2unlockShip[0], spawnPosition_3, fight2unlockShip[0].transform.rotation) as GameObject;
                    Destroy(cloneEnemy, 7);
                }
            }
            spawnHazardWait = 0.9f;
            //Wave 5
            yield return new WaitForSeconds(startHazardWait);
            for (int i = 0; i < Random.Range(15, 35); i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                //hazard
                GameObject cloneHazard = Instantiate(hazard[2], spawnPosition, spawnRotation) as GameObject;
                Destroy(cloneHazard, 7);

                yield return new WaitForSeconds(spawnHazardWait);

                if ((int)Random.Range(0, 100) < 10 && !PlayerData.Instance.SHIP_ID[2] && !fight2getShip)
                {
                    Vector3 spawnPosition_3 = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    GameObject cloneEnemy = Instantiate(fight2unlockShip[0], spawnPosition_3, fight2unlockShip[0].transform.rotation) as GameObject;
                    Destroy(cloneEnemy, 7);
                }
            }
            spawnHazardWait = 1.5f;
            //Wave 6
            yield return new WaitForSeconds(startHazardWait);
            for (int i = 0; i < Random.Range(10, 15); i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                //hazard
                GameObject cloneHazard = Instantiate(hazard[3], spawnPosition, hazard[3].transform.rotation) as GameObject;
                Destroy(cloneHazard, 7);

                yield return new WaitForSeconds(spawnHazardWait);

                if ((int)Random.Range(0, 100) < 10 && !PlayerData.Instance.SHIP_ID[2] && !fight2getShip)
                {
                    Vector3 spawnPosition_3 = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    GameObject cloneEnemy = Instantiate(fight2unlockShip[0], spawnPosition_3, fight2unlockShip[0].transform.rotation) as GameObject;
                    Destroy(cloneEnemy, 7);
                }
            }
            spawnHazardWait = 0.7f;
            //Wave 7
            yield return new WaitForSeconds(startHazardWait);
            for (int i = 0; i < Random.Range(25, 50); i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                int size = (int)Random.Range(15, 30);
                Vector3 randomSize = new Vector3(size, size, size);

                //hazard
                GameObject cloneHazard = Instantiate(hazard[0], spawnPosition, spawnRotation) as GameObject;
                cloneHazard.transform.localScale = randomSize;
                Destroy(cloneHazard, 7);
                yield return new WaitForSeconds(spawnHazardWait);

                //hazard 2
                Vector3 spawnPosition_2 = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                GameObject cloneHazard_2 = Instantiate(hazard[2], spawnPosition_2, spawnRotation) as GameObject;
                Destroy(cloneHazard_2, 7);
                yield return new WaitForSeconds(spawnHazardWait);

                //Enemy
                GameObject cloneHazard_3 = Instantiate(hazard[3], spawnPosition, hazard[3].transform.rotation) as GameObject;
                Destroy(cloneHazard_3, 7);
                yield return new WaitForSeconds(spawnHazardWait);

                if ((int)Random.Range(0, 100) < 5 && !PlayerData.Instance.SHIP_ID[2] && !fight2getShip)
                {
                    Vector3 spawnPosition_4 = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    GameObject cloneEnemy = Instantiate(fight2unlockShip[0], spawnPosition_4, fight2unlockShip[0].transform.rotation) as GameObject;
                    Destroy(cloneEnemy, 7);
                }
            }          
            /*
            //Boss Wave
            GameObject cloneBoss = Instantiate(boss[0], new Vector3(0, 0, 15f), Quaternion.identity) as GameObject;
            while(cloneBoss != null)
            {
                yield return new WaitForSeconds(1f);
            }
            */
        }
    }
}
