using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameOverPanel;
    PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        playerManager = player.GetComponent<PlayerManager>();

        Time.timeScale = 1;
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerManager.health < 0)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameOverPanel.SetActive(true);
        }

        
    }

    public void OnClickRetryButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("level - Basement boss fight");
        gameOverPanel.SetActive(false);
    }

}
