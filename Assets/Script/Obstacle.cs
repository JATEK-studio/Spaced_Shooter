using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private GameObject vfx_explosion, vfx_playerExplosion;
    private SoundManager soundManager;
    [HideInInspector]
    public bool isGivenTracked;

    private void Awake()
    {
        isGivenTracked = false;
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //collide with player
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject vfxClone = Instantiate(vfx_playerExplosion, collision.transform.position, collision.transform.rotation) as GameObject;
            Destroy(collision.gameObject);
            Destroy(vfxClone, 7);
            Destroy(this.gameObject);
            soundManager.PlaySoundEffect(3);
            soundManager.PlaySoundEffect(4);
        }

        //normal obstacle collide with bullet
        else if (collision.gameObject.CompareTag("Missile") && this.gameObject.name == "meteor(Clone)")
        {
            PlayerData.Instance.setDestoryedMeteor();
            Debug.Log(PlayerData.Instance.getDestoryedMeteor());
            GameObject vfxClone = Instantiate(vfx_explosion, collision.transform.position, collision.transform.rotation) as GameObject;
            Destroy(collision.gameObject);
            Destroy(vfxClone, 7);
            Destroy(this.gameObject);
            soundManager.PlaySoundEffect(4);
        }
        else if (collision.gameObject.CompareTag("Missile") && this.gameObject.name == "Defender")
        {
            PlayerData.Instance.setDestoryedSatellite();
            Debug.Log(PlayerData.Instance.getDestoryedEnemySpaceShip());
            GameObject vfxClone = Instantiate(vfx_explosion, collision.transform.position, collision.transform.rotation) as GameObject;
            Destroy(collision.gameObject.transform.parent);
            Destroy(vfxClone, 7);
            Destroy(this.gameObject);
            soundManager.PlaySoundEffect(4);
        }        

        //water meteor collide with bullet
        else if (collision.gameObject.CompareTag("Missile") && this.gameObject.name == "meteor_water(Clone)")
        {
            PlayerData.Instance.setDestoryedWaterMeteor();
            GameObject vfxClone = Instantiate(vfx_explosion, collision.transform.position, collision.transform.rotation) as GameObject;
            Destroy(collision.gameObject);
            Destroy(vfxClone, 7);
            Destroy(this.gameObject);
            soundManager.PlaySoundEffect(4);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //collide with player
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject vfxClone = Instantiate(vfx_playerExplosion, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(other.gameObject);
            Destroy(vfxClone, 7);
            Destroy(this.gameObject);
            soundManager.PlaySoundEffect(3);
            soundManager.PlaySoundEffect(4);
        }

        if (other.gameObject.CompareTag("Shield"))
        {
            GameObject vfxClone = Instantiate(vfx_playerExplosion, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(vfxClone, 7);
            Destroy(this.gameObject);
            soundManager.PlaySoundEffect(4);
        }

        //normal obstacle collide with bullet
        if (other.gameObject.CompareTag("Bullet") && this.gameObject.name == "meteor(Clone)")
        {
            PlayerData.Instance.setDestoryedMeteor();
            Debug.Log(PlayerData.Instance.getDestoryedMeteor());
            GameObject vfxClone = Instantiate(vfx_explosion, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(other.gameObject);
            Destroy(vfxClone, 7);
            Destroy(this.gameObject);
            soundManager.PlaySoundEffect(4);
        }

        else if (other.gameObject.CompareTag("Bullet") && this.gameObject.name == "Defender")
        {
            PlayerData.Instance.setDestoryedSatellite();
            GameObject vfxClone = Instantiate(vfx_explosion, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(this.transform.parent.gameObject);
            Destroy(vfxClone, 7);
            soundManager.PlaySoundEffect(4);
        }

        //water meteor collide with bullet
        else if (other.gameObject.CompareTag("Bullet") && this.gameObject.name == "meteor_water(Clone)")
        {
            PlayerData.Instance.setDestoryedWaterMeteor();
            Debug.Log(PlayerData.Instance.getDestoryedWaterMeteor());
            GameObject vfxClone = Instantiate(vfx_explosion, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(other.gameObject);
            Destroy(vfxClone, 7);
            Destroy(this.gameObject);
            soundManager.PlaySoundEffect(4);
        }
    }
}
