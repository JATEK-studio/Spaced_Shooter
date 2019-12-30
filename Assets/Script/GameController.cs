using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hazard;

    [SerializeField]
    private Vector3 spawnValues;

    [SerializeField]
    private float startHazardWait, hazardWaveWait;
    private float spawnHazardWait;

    [SerializeField]
    private GameObject[] SpaceShip;

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
        yield return new WaitForSeconds(startHazardWait);
        for(int i = 0; i < Random.Range(10, 25) ; i++)
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
        spawnHazardWait = 0.6f;
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
            GameObject cloneHazard_2 = Instantiate(hazard[1], spawnPosition, spawnRotation) as GameObject;   
            cloneHazard_2.transform.localScale = randomSize;
            Destroy(cloneHazard_2, 7);
            yield return new WaitForSeconds(spawnHazardWait);
        }
    }   
}
