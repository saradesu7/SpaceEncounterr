using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushButton : MonoBehaviour
{
    [SerializeField] GameObject prefabToInstantiate;
    [SerializeField] GameObject parent;

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Instantiate(prefabToInstantiate, parent.transform);
    }
}
