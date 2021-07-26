using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrenade : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    void Start()
    {
        transform.parent = null;
        
        StartCoroutine(Grenade());
    }

    IEnumerator Grenade()
    {
        yield return new WaitForSeconds(4);
        explosion.Play();
        Collider[] colliders = Physics.OverlapSphere(transform.position, 50);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(100, transform.position, 50, 10);
            if (hit.CompareTag("Player"))
            {
                GameObject player = hit.gameObject;
                Vector3 moveDirection = transform.position - player.transform.position;
                //player.transform.position = Vector3.Lerp(player.transform.position, moveDirection.normalized * 0.05f, 2f);
                player.transform.Translate(moveDirection.normalized * 0.5f);
                //transform.parent.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * 50);
            }
            if(hit.CompareTag("EnemyAlien"))
            {
                hit.gameObject.transform.GetChild(1).GetComponent<AlienEnemyDamageTaken>().alienHealth -= 2;
            }
            if(hit.CompareTag("EnemyOgre"))
            {
                hit.gameObject.transform.GetChild(2).GetComponent<OgreEnemyDamageTaken>().alienHealth -= 3;
            }
        }
        
        Destroy(gameObject, 10);
    }
}
