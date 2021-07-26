using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOgre : MonoBehaviour
{
    void Update()
    {

        int layerMask = 1 << 8;

        RaycastHit hit;
        Vector3 position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        if (Physics.Raycast(position, transform.TransformDirection(Vector3.forward), out hit, 5, layerMask))
        {
            SpawnEnemier.Instance.ogreEnemy.GetComponent<Animator>().SetBool("Enable", true);
        }
    }
}
