using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private GameObject vfx_explosion, vfx_playerExplosion;

    [SerializeField]
    private GameObject[] debuff;

    private void OnCollisionEnter(Collision collision)
    {
        //collide with player
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject vfxClone = Instantiate(vfx_playerExplosion, collision.transform.position, collision.transform.rotation) as GameObject;
            Destroy(collision.gameObject);
            Destroy(vfxClone, 7);
            Destroy(this.gameObject);
        }
        //normal meteor collide with bullet
        else if (collision.gameObject.CompareTag("Missile") && this.gameObject.name == "meteor(Clone)")
        {
            PlayerData.Instance.setIndex_Unlock();
            Debug.Log(PlayerData.Instance.getIndex_Unlock());
            GameObject vfxClone = Instantiate(vfx_explosion, collision.transform.position, collision.transform.rotation) as GameObject;
            Destroy(collision.gameObject);
            Destroy(vfxClone, 7);
            Destroy(this.gameObject);
        }
        //water meteor collide with bullet
        else if (collision.gameObject.CompareTag("Missile") && this.gameObject.name == "meteor_water(Clone)")
        {
            GameObject vfxClone = Instantiate(vfx_explosion, collision.transform.position, collision.transform.rotation) as GameObject;
            GameObject debuffClone = Instantiate(debuff[0], collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(vfxClone, 7);
            Destroy(debuffClone, 7);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.name == "Debuff_Water(Clone)")
        {
            other.gameObject.GetComponent<PlayerController>().battery--;
            Destroy(this.gameObject);
        }
        else if(other.gameObject.CompareTag("Player") && this.gameObject.name == "Debuff_Fire(Clone)")
        {
            GameObject vfxClone = Instantiate(vfx_playerExplosion, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(other.gameObject);
            Destroy(vfxClone, 7);
            Destroy(this.gameObject);
        }

        //normal meteor collide with bullet
        else if (other.gameObject.CompareTag("Bullet") && this.gameObject.name == "meteor(Clone)")
        {
            PlayerData.Instance.setIndex_Unlock();
            Debug.Log(PlayerData.Instance.getIndex_Unlock());
            GameObject vfxClone = Instantiate(vfx_explosion, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(other.gameObject);
            Destroy(vfxClone, 7);
            Destroy(this.gameObject);
        }
        //water meteor collide with bullet
        else if (other.gameObject.CompareTag("Bullet") && this.gameObject.name == "meteor_water(Clone)")
        {
            GameObject vfxClone = Instantiate(vfx_explosion, other.transform.position, other.transform.rotation) as GameObject;
            GameObject debuffClone = Instantiate(debuff[0], other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(vfxClone, 7);
            Destroy(debuffClone, 7);
            Destroy(this.gameObject);
        }
    }
}
