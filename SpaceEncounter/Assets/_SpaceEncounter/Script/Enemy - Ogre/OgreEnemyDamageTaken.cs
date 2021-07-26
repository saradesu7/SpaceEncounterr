using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreEnemyDamageTaken : MonoBehaviour
{
    public float alienHealth = 10f;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("PlayerFoot").transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            //MoveBack for Hurt
            Vector3 moveDirection = transform.parent.position - playerTransform.position;
            transform.parent.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * 10f);

            alienHealth -= 1f;
        }
    }
}
