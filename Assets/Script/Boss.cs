using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private Transform[] shotSpawn;

    [SerializeField]
    private GameObject shot;

    private float nextFire, fireRate;

    void Start()
    {
        fireRate = 0.5f;
    }

    void Update()
    {
        this.gameObject.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.transform.rotation * Quaternion.Euler(0, 90, 0), Time.deltaTime);
        if (Time.time > nextFire && Time.timeScale != 0)
        {
            nextFire = Time.time + fireRate;
            foreach (Transform clone in shotSpawn)
            {
                GameObject projectileClone = Instantiate(shot, clone.position, clone.rotation) as GameObject;
                Destroy(projectileClone, 2);
            }
        }
    }
}
