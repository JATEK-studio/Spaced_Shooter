using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingGun : MonoBehaviour
{
    [SerializeField]
    private float fireRate, nextFire;

    [SerializeField]
    private GameObject shot;

    [SerializeField]
    private Transform shotSpawn;

    void Start()
    {
        Destroy(this.gameObject, 10f);
    }

    void Update()
    {
        if (Time.timeScale != 0 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject projectileClone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
            Destroy(projectileClone, 2);
        }
    }
}
