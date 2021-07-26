using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEnemyBullet : MonoBehaviour
{
    private void Start()
    {
        transform.parent = null;
    }
    private void OnEnable()
    {
        Invoke("HideBullet", 2.0f);
    }

    void HideBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }
}
