using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemyAliens : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(enumerator());
    }
    void Update()
    {
        int layerMask = 1 << 8;

        RaycastHit hit;
        Vector3 position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        if (Physics.Raycast(position, transform.TransformDirection(-Vector3.forward), out hit, 0.5f, layerMask) && SpawnEnemier.AlienObjectPool[0].transform.GetChild(1).GetComponent<Animator>().GetBool("Enable") == false)
        {
            /*for(int i=0; i<SpawnEnemier.AlienObjectPool.Count; i++)
            {
                if(SpawnEnemier.AlienObjectPool[i].activeSelf)
                    SpawnEnemier.AlienObjectPool[i].transform.GetChild(1).GetComponent<Animator>().SetBool("Enable", true);
            }*/
        }
    }

    IEnumerator enumerator()
    {
        while (true)
        {
            if (SpawnEnemier.AlienObjectPool.Count < 4)
            {
                for (int i = 0; i < SpawnEnemier.AlienObjectPool.Count; i++)
                    if (!SpawnEnemier.AlienObjectPool[i].activeSelf)
                    {
                        SpawnEnemier.AlienObjectPool[i].SetActive(true);
                        SpawnEnemier.AlienObjectPool[i].transform.GetChild(1).GetComponent<Animator>().SetBool("Enable", true);
                    }
            }
            else
            {
                int count = Random.Range(2, 6);
                int count2 = 0;
                for (int i = 0; i < SpawnEnemier.AlienObjectPool.Count; i++)
                {
                    if (!SpawnEnemier.AlienObjectPool[i].activeSelf)
                    {
                        SpawnEnemier.AlienObjectPool[i].SetActive(true);
                        SpawnEnemier.AlienObjectPool[i].transform.GetChild(1).GetComponent<Animator>().SetBool("Enable", true);
                        count2++;
                    }
                    if (count == count2)
                        break;
                }
            }
            Debug.Log("hey");
            yield return new WaitForSeconds(30);
        }
    }
}
