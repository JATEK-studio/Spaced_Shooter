using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMissile : MonoBehaviour
{
    private bool tracking = false;

    private Obstacle target;

    [SerializeField]
    private GameObject vfx_explosion;

    // Update is called once per frame
    private void Update()
    {        
        if (tracking)
        {
            if(target != null)
            {
                transform.LookAt(target.transform);
                this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position, 0.5f);
            }            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            if(tracking == false)
            {
                target = other.gameObject.GetComponent<Obstacle>();
                if (target.isGivenTracked == false)
                {
                    target.isGivenTracked = true;
                    tracking = true;
                }
            }
        }
        else if (other.name == "Defender(Clone)")
        {
            if (tracking == false)
            {
                target = other.gameObject.GetComponent<Obstacle>();
                if (target.isGivenTracked == false)
                {
                    target.isGivenTracked = true;
                    tracking = true;
                }
            }
        }
        else if (other.name == "meteor(Clone)" || other.name == "meteor_water(Clone)")
        {
            if (tracking == false)
            {
                target = other.gameObject.GetComponent<Obstacle>();
                if (target.isGivenTracked == false)
                {
                    target.isGivenTracked = true;
                    tracking = true;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        tracking = true;
    }
}
