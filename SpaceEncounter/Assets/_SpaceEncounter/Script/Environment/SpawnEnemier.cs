using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemier : MonoBehaviour
{
    public static SpawnEnemier Instance { get; private set; }

    public GameObject alien;
    [SerializeField] int alienCount;
    private List<GameObject> alienObjectPool = new List<GameObject>();
    public static List<GameObject> AlienObjectPool => Instance.alienObjectPool;

    public GameObject ogreEnemy;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < alienCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-48.0f, 19.0f), alien.transform.position.y, Random.Range(-72.0f, -5.0f));
            GameObject temp = (GameObject)Instantiate(alien, position, Quaternion.identity);
            temp.SetActive(false);
            alienObjectPool.Add(temp);
            Debug.Log(temp);
        }
        /*for(int i = 0; i < 5; i++)
        {
            alienObjectPool[i].SetActive(true);
        }*/
    }


    private void Update()
    {
        int count = 0;
        for( int i = 0; i< alienObjectPool.Count; i++)
        {
            if (alienObjectPool[i].transform.GetChild(1).GetComponent<Animator>().GetBool("IsDead") == true)
                count++;
        }
        if (count == alienObjectPool.Count)
            ogreEnemy.GetComponent<Animator>().SetBool("Enable", true);
    }

}
