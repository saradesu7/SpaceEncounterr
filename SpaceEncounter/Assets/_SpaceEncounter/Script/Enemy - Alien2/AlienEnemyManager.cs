using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEnemyManager : MonoBehaviour
{

    [SerializeField] private Animator AlienAnimator;
    [SerializeField] private AlienEnemyDamageTaken damageTaken;

    [SerializeField] private GameObject Gun1;
    [SerializeField] private GameObject Gun2;

    [SerializeField] public GameObject eneryOrb;


    public void ShootToEnrage()
    {
        
        AlienAnimator.SetBool("CanShoot", false);
        AlienAnimator.SetBool("InAttackShootRange", false);
        AlienAnimator.SetBool("IsEnraged", true);

        if (Gun1.transform.parent != null)
        {
            Gun1.transform.parent = null;
            Gun1.AddComponent<Rigidbody>();
        }

        if (Gun2.transform.parent != null)
        {
            Gun2.transform.parent = null;
            Gun2.AddComponent<Rigidbody>();
        }

    }

    private void Update()
    {
        /*if (damageTaken.alienHealth < 0)
        {
            AlienAnimator.SetBool("IsDead", true);
        }*/
    }
}
