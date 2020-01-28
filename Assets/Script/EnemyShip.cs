using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyBoundary
{
    public float xMax, xMin;
}

public class EnemyShip : MonoBehaviour
{
    private Shield shield;

    private Rigidbody rb;

    public EnemyBoundary boundary;

    [SerializeField]
    private Transform[] shotSpawn;

    [SerializeField]
    private GameObject shot, vfx_explosion;

    [SerializeField]
    private float nextFire, fireRate;

    private PlayerController player;

    private int randDir;

    private Vector3 movement;

    private void Start()
    {
        randDir = Random.Range(1, -1);
        shield = transform.GetChild(0).GetComponent<Shield>();
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody>();
        movement = new Vector3(randDir, 0f, 0f);
    }

    private void Update()
    {
        if(this.gameObject != null)
        {
            //Firing
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

    private void OnCollisionEnter(Collision collision)
    {
        //For Fight 2 get Ship
        if(collision.gameObject.CompareTag("Missile") && this.gameObject.name == "Type_A_1(Clone)" && !PlayerData.Instance.SHIP_ID[2])
        {
            PlayerData.Instance.SHIP_ID[2] = true;
            GameObject vfxClone = Instantiate(vfx_explosion, collision.transform.position, collision.transform.rotation) as GameObject;
            Destroy(collision.gameObject);
            Destroy(vfxClone, 7);
            Destroy(this.gameObject);
            SaveSystem.SavePlayer();
        }

        //Destory by missile
        if (collision.gameObject.CompareTag("Missile"))
        {
            GameObject vfxClone = Instantiate(vfx_explosion, collision.transform.position, collision.transform.rotation) as GameObject;
            PlayerData.Instance.setDestoryedEnemySpaceShip();
            Destroy(collision.gameObject);
            Destroy(vfxClone, 7);
            if (this.gameObject.name == "Enemy_SpaceShip_0") Destroy(this.transform.parent.gameObject);
            else Destroy(this.gameObject);
        }

        //collide wiv player
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject vfxClone = Instantiate(vfx_explosion, collision.transform.position, collision.transform.rotation) as GameObject;
            Destroy(collision.gameObject);
            Destroy(vfxClone, 7);
            if (this.gameObject.name == "Enemy_SpaceShip_0") Destroy(this.transform.parent.gameObject);
            else Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //For Fight 2 get Ship
        if (other.gameObject.CompareTag("Bullet") && this.gameObject.name == "Type_A_1(Clone)" && !PlayerData.Instance.SHIP_ID[2])
        {
            PlayerData.Instance.SHIP_ID[2] = true;
            GameObject vfxClone = Instantiate(vfx_explosion, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(other.gameObject);
            Destroy(vfxClone, 7);
            Destroy(this.gameObject);
            SaveSystem.SavePlayer();
        }

        //Destory by bullet
        if (other.gameObject.CompareTag("Bullet"))
        {
            GameObject vfxClone = Instantiate(vfx_explosion, other.transform.position, other.transform.rotation) as GameObject;
            PlayerData.Instance.setDestoryedEnemySpaceShip();
            Destroy(other.gameObject);
            Destroy(vfxClone, 7);
            if (this.gameObject.name == "Enemy_SpaceShip_0") Destroy(this.transform.parent.gameObject);
            else Destroy(this.gameObject);
        }

    }
}
