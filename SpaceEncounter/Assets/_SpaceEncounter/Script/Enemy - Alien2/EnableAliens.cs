using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAliens : MonoBehaviour
{
    [SerializeField] GameObject enableGO;
    // Start is called before the first frame update
    void Start()
    {
        enableGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        int layerMask = 1 << 8;

        RaycastHit hit;
        Vector3 position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        if (Physics.Raycast(position, transform.TransformDirection(Vector3.forward), out hit, 5, layerMask) && SpawnEnemier.AlienObjectPool[0].transform.GetChild(1).GetComponent<Animator>().GetBool("Enable") == false)
        {
            enableGO.SetActive(true);
                /*for(int i=0; i<SpawnEnemier.AlienObjectPool.Count; i++)
            {
                if(SpawnEnemier.AlienObjectPool[i].activeSelf)
                    SpawnEnemier.AlienObjectPool[i].transform.GetChild(1).GetComponent<Animator>().SetBool("Enable", true);
            }*/
        }
    }
}
