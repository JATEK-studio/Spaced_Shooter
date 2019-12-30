using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMissile : MonoBehaviour
{
    private bool tracking;

    private Transform target;

    [SerializeField]
    private GameObject vfx_explosion;

    void Start()
    {
        tracking = false;
    }

    // Update is called once per frame
    void Update()
    {        
        if (tracking)
        {
            if(target != null)
            {
                Vector3 targetYAxis = new Vector3(0, target.position.y, 0);
                transform.rotation = Quaternion.Euler(targetYAxis);
                this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position, 0.5f);
            }            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "meteor(Clone)" && !tracking)
        {
            tracking = true;
            target = other.transform;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            GameObject vfxClone = Instantiate(vfx_explosion, collision.transform.position, collision.transform.rotation) as GameObject;
            Destroy(collision.gameObject);
            Destroy(vfxClone, 7);
            Destroy(this.gameObject);
        }
    }
}
