using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    private float xOffset, yOffset, zOffset;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        if (player != null) transform.position = player.transform.position + new Vector3(xOffset, yOffset, zOffset);
    }
}
