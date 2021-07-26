using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] Image imgChangeColor;
    private Image healthBar;
    private float maxHealth = 100f;
    PlayerManager playerManager;
    Color ogColor;

    // Start is called before the first frame update
    void Start()
    {
        ogColor = imgChangeColor.color;
        healthBar = GetComponent<Image>();
        playerManager = FindObjectOfType<PlayerManager>();
        StartCoroutine("ChangeColor");
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = playerManager.health;
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    IEnumerator ChangeColor()
    {
        while (true)
        {
            
            if (playerManager.health < 20)
            {
                if (imgChangeColor.color == ogColor)
                    imgChangeColor.color = Color.red;
                else
                    imgChangeColor.color = ogColor;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
