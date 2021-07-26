using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEnemyShoot : MonoBehaviour
{
    [SerializeField] Animator alienAnimator;

    [Header("Projectile")]
    [SerializeField] private List<GameObject> alienBulletObjectPool;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] Transform firepoint;
    Rigidbody rb;

    [Header("CooldownTimer")]
    [SerializeField] float fireRate;
    float timeStamp;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject temp = (GameObject)Instantiate(bulletPrefab,transform);
            alienBulletObjectPool.Add(temp);
            temp.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 look = (Random.insideUnitSphere/2f) + GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        firepoint.LookAt(look);*/
        firepoint.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform);
        //FireBulllet
        timeStamp += Time.deltaTime;
        if (alienAnimator.GetBool("InAttackShootRange"))
        {
            if (timeStamp > fireRate)
                Shoot();
        }
    }
    private void Shoot()
    {
        for (int i = 0; i < alienBulletObjectPool.Count; i++)
        {
            if (!alienBulletObjectPool[i].activeInHierarchy)
            {
                alienBulletObjectPool[i].transform.position = firepoint.position;
                alienBulletObjectPool[i].transform.rotation = firepoint.rotation;
                rb = alienBulletObjectPool[i].GetComponent<Rigidbody>();
                rb.velocity = firepoint.forward * bulletSpeed;
                alienBulletObjectPool[i].SetActive(true);
                break;
            }
        }


        muzzleFlash.Play();
        timeStamp = 0;
    }
}
