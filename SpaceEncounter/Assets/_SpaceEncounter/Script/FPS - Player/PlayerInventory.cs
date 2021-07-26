using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject slot1;
    [SerializeField] GameObject slot2;
    [SerializeField] GameObject slot3;
    Vector3 scaleTo = new Vector3(100, 100, 100);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (inventory.transform.childCount != 0)
        {
            if(slot1.transform.childCount == 0)
            {
                inventory.transform.GetChild(0).parent = slot1.transform;
                slot1.transform.GetChild(0).position = slot1.transform.position;
                slot1.transform.GetChild(0).localScale = scaleTo;
            }
        }
    }
}
