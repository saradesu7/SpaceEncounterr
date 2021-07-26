using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private GameObject blood;
    private GameObject bloodClone;
    LayerMask layer = 1 << 9;

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
        if (Physics.Raycast(transform.position, -Vector3.forward, out RaycastHit hit, Mathf.Infinity, layer))
        {

            bloodClone = Instantiate(blood, hit.point, Quaternion.FromToRotation(-Vector3.forward, hit.normal));
            bloodClone.transform.parent = hit.rigidbody.transform;


            Debug.Log("helllll");
            Destroy(bloodClone, 0.20f);
        }



        gameObject.SetActive(false);
    }

}