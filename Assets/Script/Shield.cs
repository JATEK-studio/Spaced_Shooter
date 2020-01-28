using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int health;

    private SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void FixedUpdate()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Player
        if (other.gameObject.CompareTag("EnemyBullet") && this.transform.parent.CompareTag("Player"))
        {
            health--;
            Destroy(other.gameObject);
            soundManager.PlaySoundEffect(3);
        }
        else if (other.gameObject.name == "meteor(Clone)" || other.gameObject.name == "meteor_water(Clone)" || other.gameObject.name == "Defender" && this.transform.parent.CompareTag("Player"))
        {
            health--;
            Destroy(other.gameObject);
            soundManager.PlaySoundEffect(3);
        }

        //Enemy shield
        else if (other.gameObject.CompareTag("Bullet") && this.transform.parent.CompareTag("Enemy"))
        {
            health--;
            Destroy(other.gameObject);
            soundManager.PlaySoundEffect(3);
        }
        else if (other.gameObject.CompareTag("Missile") && this.transform.parent.CompareTag("Enemy"))
        {
            health--;
            Destroy(other.gameObject);
            soundManager.PlaySoundEffect(3);
        }
        else if (other.gameObject.CompareTag("Player") && this.transform.parent.CompareTag("Enemy"))
        {
            health--;
            Destroy(other.gameObject);
            soundManager.PlaySoundEffect(3);
        }
    }
}
