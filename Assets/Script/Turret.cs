using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private GameObject shot;

    [SerializeField]
    private float nextFire, fireRate;

    private Transform target;

    private bool tracking = false;

    // Update is called once per frame
    private void Update()
    {
        if (tracking)
        {
            transform.LookAt(target);
            this.transform.rotation = this.transform.rotation * Quaternion.Euler(0.1f, 0.1f, 0.1f);
            if (Time.time > nextFire && Time.timeScale != 0)
            {
                nextFire = Time.time + fireRate;
                GameObject projectileClone = Instantiate(shot, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
                Destroy(projectileClone, 2);
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tracking = true;
            target = other.transform;
        }
    }
}
