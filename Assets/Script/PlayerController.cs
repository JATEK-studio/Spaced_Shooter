using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

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

    [HideInInspector]
    public int missileCount, battery, batteryUI;

    [SerializeField]
    private int max_Battery;

    private bool reloading;
     
    public PlayerBoundary boundary;

    private Rigidbody rb;

    private Vector3 movement;

    [SerializeField]
    private GameObject shot, vfx_explosion;

    [SerializeField]
    private Transform[] shotSpawn;

    public SpaceShipType shipType;

    private Button FireButton;

    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        rb = this.GetComponent<Rigidbody>();
        switch (shipType)
        {
            case SpaceShipType.TypeA:
                Input.gyro.enabled = false;
                speed = 3;
                break;
            case SpaceShipType.TypeB:
                Input.gyro.enabled = true;
                speed = 5;
                battery = max_Battery;
                sensitive = 5;
                break;
            case SpaceShipType.TypeC:
                Input.gyro.enabled = false;
                reloading = false;
                FireButton = GameObject.FindGameObjectWithTag("Type_C_Button").GetComponent<Button>();
                missileCount = 10;
                speed = 3;
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
            if (Input.GetButton("Fire1") && Time.time > nextFire && Time.timeScale != 0)
            {
                nextFire = Time.time + fireRate;
                foreach (Transform clone in shotSpawn)
                {
                    GameObject projectileClone = Instantiate(shot, clone.position, clone.rotation) as GameObject;
                    Destroy(projectileClone, 2);                    
                }
                soundManager.PlaySoundEffect(1);
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
                soundManager.PlaySoundEffect(1);
                if (battery > 1)battery--;
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
            if (battery >= max_Battery*0.7 && battery <= max_Battery)
            {
                fireRate = 0.1f;
                batteryUI = 5;
            }
            else if (battery >= max_Battery * 0.5 && battery < max_Battery * 0.7)
            {
                fireRate = 0.2f;
                batteryUI = 4;
            }
            else if (battery >= max_Battery * 0.3 && battery < max_Battery * 0.5)
            {
                fireRate = 0.4f;
                batteryUI = 3;
            }
            else if (battery >= max_Battery * 0.1 && battery < max_Battery * 0.3)
            {
                fireRate = 0.5f;
                sensitive = 2;
                batteryUI = 2;
            }
            else if (battery > 0 && battery < max_Battery * 0.1)
            {
                fireRate = 0.6f;
                sensitive = 1;
                batteryUI = 1;
            }
            else
            {
                batteryUI = 0;
            }
            #endregion
        }
        else if (shipType == SpaceShipType.TypeC)
        {
            //Control method
            #region
            //Fire
            FireButton.onClick.AddListener(Type_C_Firing);
            if (missileCount < 10 && !reloading)
            {
                StartCoroutine(Reloading(3));
                missileCount++;
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
        /*
        else if (shipType == SpaceShipType.TypeD)
        {
            //Control method

            #region
            int deployed = 0;

            //Shield Regeneration
            if (consumeableShield.current_health <= 0)
            {                
                consumeableShield.gameObject.SetActive(false);
                if (!reloading)
                {
                    StartCoroutine(Reloading(5));
                    consumeableShield.current_health++;
                }
            }
            else
            {
                consumeableShield.gameObject.SetActive(true);
            }

            //Deploy Floating gun
            if(deployed != shotSpawn.Length && !consumeableShield.deploy)
            {               
                GameObject DeployFloatingGunClone = Instantiate(shot, shotSpawn[deployed].position, shotSpawn[deployed].rotation) as GameObject;
                consumeableShield.deploy = false;
                deployed++;
                if(DeployFloatingGunClone == null)
                {
                    deployed--;
                }
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
        }
        */
    }

    private void FixedUpdate()
    {
        if(this.gameObject == null)
        {
            soundManager.AddLowPassFilter();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet") && !this.transform.GetChild(0).CompareTag("Shield"))
        {
            GameObject clone_vfx = Instantiate(vfx_explosion, this.transform.position, this.transform.rotation) as GameObject;
            Destroy(this.gameObject);
            Destroy(clone_vfx, 7);
            Destroy(other.gameObject);
            soundManager.PlaySoundEffect(3);
        }
    }

    private void Type_C_Firing()
    {
        if (Time.timeScale != 0 && Time.time > nextFire && missileCount > 0)
        {
            nextFire = Time.time + fireRate;
            soundManager.PlaySoundEffect(2);
            foreach (Transform clone in shotSpawn)
            {
                GameObject projectileClone = Instantiate(shot, clone.position, clone.rotation) as GameObject;
                Destroy(projectileClone, 2);
            }
            if (missileCount > 0) missileCount--;
            else missileCount = 0;
        }
    }

    private IEnumerator Reloading(int reloadingTime)
    {
        reloading = true;
        float endPause = Time.realtimeSinceStartup + reloadingTime;
        while (Time.realtimeSinceStartup < endPause)
        {          
            yield return 0;
        }
        reloading = false;
    }
}
