using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyOrb : MonoBehaviour
{
    PlayerManager playerManager;
    void Start()
    {
        transform.parent = null;
        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            transform.position = Vector3.Slerp(transform.position, newPos, 0.7f);
            playerManager.health += 2f;
            Destroy(gameObject, 0.2f);
        }
    }
}
