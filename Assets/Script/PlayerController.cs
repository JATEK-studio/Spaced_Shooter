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

    [SerializeField]
    private float fireRate, tilt;

    private float speed, nextFire, deltaX, sensitive;

    private int shield;

    public int battery;

    public PlayerBoundary boundary;

    private Rigidbody rb;

    private Vector3 movement;

    [SerializeField]
    private GameObject shot;

    [SerializeField]
    private Transform[] shotSpawn;

    public SpaceShipType shipType;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        battery = 100;
        switch (shipType)
        {
            case SpaceShipType.TypeA:
                Input.gyro.enabled = false;
                speed = 3;
                break;
            case SpaceShipType.TypeB:
                Input.gyro.enabled = true;
                speed = 3;
                sensitive = 3;
                break;
            case SpaceShipType.TypeC:
                break;
            case SpaceShipType.TypeD:
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
                battery--;
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


            //Battery control        
            #region
            if (battery >= 80 && battery <= 100)
            {
                //battery = 5;
                fireRate = 0.5f;
            }
            else if (battery >= 60)
            {
                //battery = 4;
                fireRate = 0.6f;
            }
            else if (battery >= 30)
            {
                //battery = 3;
                fireRate = 0.7f;
            }
            else if (battery >= 10)
            {
                //battery = 2;
                fireRate = 0.8f;
                speed = 2;
            }
            else if (battery > 0)
            {
                //battery = 1;
                fireRate = 0.9f;
                speed = 2;
            }
            else
            {
                //battery = 0;
                speed = 1;
            }
            #endregion
        }
        else if (shipType == SpaceShipType.TypeB)
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
            movement = new Vector3(Input.acceleration.x * sensitive, 0f, 0f);
            rb.velocity = movement * speed;
            rb.position = new Vector3(
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0f,
                0f
                );

            //Rotate
            rb.rotation = Quaternion.Euler(0f, 0f, rb.velocity.x * -tilt);
            #endregion


            //Battery control        
            #region
            if (battery >= 80 && battery <= 100)
            {
                //battery = 5;
                fireRate = 0.3f;
            }
            else if (battery >= 60)
            {
                //battery = 4;
                fireRate = 0.35f;
            }
            else if (battery >= 30)
            {
                //battery = 3;
                fireRate = 0.4f;
            }
            else if (battery >= 10)
            {
                //battery = 2;
                fireRate = 0.45f;
                sensitive = 2;
            }
            else if (battery > 0)
            {
                //battery = 1;
                fireRate = 0.5f;
                sensitive = 2;
            }
            else
            {
                //battery = 0;
                sensitive = 1;
            }
            #endregion
        }
    }
}
