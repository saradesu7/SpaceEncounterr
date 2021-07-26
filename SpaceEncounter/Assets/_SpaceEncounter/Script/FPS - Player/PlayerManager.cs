using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public GameObject grenade;
    public GameObject gun;
    public GameObject playerCamera;
    private float rotationXCam;
    private float rotationXGun;
    
    [SerializeField] private Animator headAnimator;
    [SerializeField] private List<GameObject> playerBulletObjectPool;

    [Header("Projectile")]
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firepoint;
    [SerializeField] float bulletSpeed;
    Rigidbody rb;

    [Header("CooldownTimer")]
    [SerializeField] float fireRate;
    float timeStamp;

    [Header("Health")]
    public float health = 100f;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        playerBulletObjectPool = new List<GameObject>();
        for (int i = 0; i < 20; i++)
        {
            GameObject temp = (GameObject)Instantiate(bulletPrefab);
            playerBulletObjectPool.Add(temp);
            temp.SetActive(false);
        }
        //gun.SetActive(false);
        //headAnimator.SetBool("Equip", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HITTT");
        if (other.tag == "EnemyBullet")
            health -= 0.15f;
        if(other.tag == "EnemyAlien")
            health -= 0.5f;
        if (other.tag == "EnemyOgre")
            health -= 1f;
    }
    
    private void Update()
    {
        //Look Around
        rotationXCam += -Input.GetAxis("Mouse Y") * CharacterMovement.LookSpeed;
        rotationXCam = Mathf.Clamp(rotationXCam, -CharacterMovement.LookXLimit, CharacterMovement.LookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationXCam, 0, 0);

        rotationXGun += -Input.GetAxis("Mouse Y") * (CharacterMovement.LookSpeed/2);
        rotationXGun = Mathf.Clamp(rotationXGun, -45, 30);
        gun.transform.localRotation = Quaternion.Euler(rotationXGun, 0, 0);



        /*//Equip/Unequip Gun
        if (Input.GetKeyDown(KeyCode.E) && gun.activeInHierarchy)
            headAnimator.SetBool("Unequip",true);
        if (Input.GetKeyDown(KeyCode.E) && !gun.activeInHierarchy)
        {
            gun.SetActive(true);
            headAnimator.SetBool("Equip", true);
        }*/




        //FireBulllet
        timeStamp += Time.deltaTime;
        if (Input.GetMouseButton(0) && headAnimator.GetBool("CanShoot"))
        {
            headAnimator.SetBool("IsShooting", true);
            if (timeStamp > fireRate)
                Shoot();
        }
        else 
            headAnimator.SetBool("IsShooting", false);




        /*//grenade
        if(Input.GetKeyDown(KeyCode.G))
        {
            GameObject temp = (GameObject)Instantiate(grenade, transform);
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 5);
        }*/

    }

    private void Shoot()
    {
        for (int i = 0; i < playerBulletObjectPool.Count; i++)
        {
            if (!playerBulletObjectPool[i].activeInHierarchy)
            {
                playerBulletObjectPool[i].transform.position = firepoint.position;
                playerBulletObjectPool[i].transform.rotation = firepoint.rotation;
                rb = playerBulletObjectPool[i].GetComponent<Rigidbody>();
                rb.velocity = firepoint.forward * bulletSpeed;
                playerBulletObjectPool[i].SetActive(true);
                break;
            }
        }

        
        muzzleFlash.Play();
        timeStamp = 0;
    }
}
