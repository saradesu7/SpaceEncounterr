using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirChamber : MonoBehaviour
{
    [SerializeField] GameObject airChamberPS;

    void Update()
    {
        int layerMask = 1 << 8;

        RaycastHit hit;
        Vector3 position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        if (Physics.Raycast(position, transform.TransformDirection(-Vector3.forward), out hit, 1.5f, layerMask) && airChamberPS != null)
        {
            airChamberPS.GetComponent<ParticleSystem>().Stop();
            Destroy(airChamberPS, 1);
        }
    }
}
