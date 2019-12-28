using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    private GameObject target;

    //Mode
    private const int maxMode = 2;
    private int nowMode = 0;

    //Different perspectives
    private Vector3[] position = {
        new Vector3(0, 2.5f, -3f), //ThirdPerspective
        new Vector3(0, 0f, 0.5f) //FirstPerspective
    };
    private Quaternion[] rotation = {
        Quaternion.Euler(30f, 0, 0), //ThirdPerspective
        Quaternion.Euler(0, 0, 0), //FirstPerspective
    };

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        SetPosition();
        SetRotation();
        SetScale();
    }

    // Update is called once per frame
    private void Update()
    {
        if (target != null)
        {
            if (CheckStatus())
            {
                TogglePerspective();
                SetRotation();
                SetScale();
            }
            SetPosition();
        }
    }

    private void TogglePerspective()
    {
        nowMode = ++nowMode % maxMode;
    }

    private void SetPosition()
    {
        position[nowMode].x = target.transform.position.x;
        transform.position = position[nowMode];
    }

    private void SetRotation()
    {
        transform.rotation = rotation[nowMode];
    }

    private void SetScale()
    {
        transform.localScale = Vector3.one;
    }

    private bool CheckStatus()
    {
        return Input.GetMouseButtonDown(2) && Time.timeScale != 0;
    }
}
