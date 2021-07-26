using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerITS : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(false);
        Time.timeScale = 1;
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.I) && !inventoryPanel.activeSelf)
        {
            Time.timeScale = 0;
            // Lock cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            inventoryPanel.SetActive(true);
        }*/
            
    }

    public void OnClickInventoryButton()
    {
        inventoryPanel.SetActive(true);
    }

    public void OnClickGOBackButton()
    {
        Time.timeScale = 1;
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        inventoryPanel.SetActive(false);
    }
}
