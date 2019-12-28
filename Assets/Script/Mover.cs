using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float speed, tumble;
    private Rigidbody rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = this.transform.forward * speed;
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
