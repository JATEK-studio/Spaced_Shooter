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
    private float startHazardWait, spawnHazardWait, hazardWaveWait;

    private int score;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(StartSpawnHazardWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Restart()
    {
        if (Input.GetMouseButton(1))
        {
            score = 0;
            SceneManager.LoadScene(0);
        }
    }

    private IEnumerator StartSpawnHazardWave()
    {
        yield return new WaitForSeconds(startHazardWait);
        while (true)
        {
            for(int i = 0; i < 30; i++)
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
            yield return new WaitForSeconds(hazardWaveWait);
        }
    }

    private IEnumerator SpawnHazardWave(int hazardCount)
    {
        yield return new WaitForSeconds(startHazardWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
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
            yield return new WaitForSeconds(hazardWaveWait);
        }
    }
}
