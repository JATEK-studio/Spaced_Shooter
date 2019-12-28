using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class PlayerBoundary
{
    public float xMax, xMin;
}

public class PlayerController : MonoBehaviour
{
    //Which type of Ship is this
    public enum SpaceShipType
    {
        TypeA,
        TypeB,
        TypeC,
        TypeD
    }


    public float fireRate, tilt;

    private float speed, nextFire, deltaX;

    private int shield;

    private int battery;

    public PlayerBoundary boundary;

    private Rigidbody rb;

    private Vector3 movement;

    [SerializeField]
    private GameObject shot;

    [SerializeField]
    private Transform[] shotSpawn;

    [SerializeField]
    private SpaceShipType shipType;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();

        switch (shipType)
        {
            case SpaceShipType.TypeA:
                Input.gyro.enabled = false;
                speed = 3;
                battery = 150;
                break;
            case SpaceShipType.TypeB:
                Input.gyro.enabled = true;
                battery = 200;
                break;
            case SpaceShipType.TypeC:
                battery = 300;
                break;
            case SpaceShipType.TypeD:
                battery = 100;
                break;
        }
    }


    private void Update()
    {
        //Different ship, different control
        if (shipType == SpaceShipType.TypeA)
        {
            //Control method
            #region
            //Fire
            if (Input.GetButton("Fire1") && Time.time > nextFire && battery > 0 && Time.timeScale != 0)
            {
                nextFire = Time.time + fireRate;
                foreach (Transform clone in shotSpawn)
                {
                    GameObject projectileClone = Instantiate(shot, clone.position, clone.rotation) as GameObject;
                    Destroy(projectileClone, 2);
                }
                //battery--;
            }

            //Movement
            float moveHorizontalAndroid = CrossPlatformInputManager.GetAxis("Horizontal");
            movement = new Vector3(moveHorizontalAndroid, 0f, 0f);
            rb.velocity = movement * speed;
            rb.position = new Vector3(
                   Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                   0f,
                   0f
            );

            //Rotate
            rb.rotation = Quaternion.Euler(0f, 0f, rb.velocity.x * -tilt);
            #endregion
        }
        else if (shipType == SpaceShipType.TypeB)
        {
            #region
            //Movement
            movement = new Vector3(Input.acceleration.x, 0f, 0f);
            rb.velocity = movement * speed;
            rb.position = new Vector3(
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0f,
                0f
                );

            //Rotate
            rb.rotation = Quaternion.Euler(0f, 0f, rb.velocity.x * -tilt);
            #endregion
        }

        //Battery control
        #region
        if (battery >= 80 && battery <= 100)
        {
            battery = 5;
            fireRate = 0.2f;
            speed = 6;
        }
        else if (battery >= 60)
        {
            battery = 4;
            fireRate = 0.3f;
            speed = 5;
        }
        else if (battery >= 30)
        {
            battery = 3;
            fireRate = 0.5f;
            speed = 5;
        }
        else if (battery >= 10)
        {
            battery = 2;
            fireRate = 0.7f;
            speed = 4;
        }
        else if (battery > 0)
        {
            battery = 1;
            fireRate = 0.9f;
            speed = 3;
        }
        else
        {
            battery = 0;
            speed = 0;
        }
        #endregion
    }
}
