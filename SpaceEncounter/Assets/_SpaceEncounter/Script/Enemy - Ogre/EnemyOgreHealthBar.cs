using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyOgreHealthBar : MonoBehaviour
{
    [SerializeField] OgreEnemyDamageTaken damageTaken;
    private Image healthBar;
    float maxHealth;
    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = damageTaken.alienHealth;
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = damageTaken.alienHealth;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
