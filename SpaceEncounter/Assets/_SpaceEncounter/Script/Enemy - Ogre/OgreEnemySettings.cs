using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreEnemySettings : MonoBehaviour
{
    public GameObject energyOrb;
    [SerializeField] OgreEnemyDamageTaken enemyDamageTaken;
    [SerializeField] ParticleSystem impactPS;

    [Header("Settings")]
    public float PlayerRange = 20;
    public float AttackRange = 7;
    public float ChaseSpeed = 5;
    public float WalkSpeed = 2;
    public float OgreHealth => enemyDamageTaken.alienHealth;

    Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(PowerAttack());
    }
    public void ShockWave()
    {
        impactPS.Play();
        Debug.Log("SHOWCKCWAVE");
        Collider[] colliders = Physics.OverlapSphere(transform.position, 100);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(150, transform.position, 100, 10);
            if(hit.CompareTag("Player"))
            {
                GameObject player = hit.gameObject;
                Vector3 moveDirection = transform.position - player.transform.position;
                //player.transform.position = Vector3.Lerp(player.transform.position, moveDirection.normalized * 0.05f, 2f);
                player.transform.Translate(moveDirection.normalized * 0.1f);
                player.GetComponent<PlayerManager>().health -= 2;
                //transform.parent.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * 50);
            }
        }
    }
    IEnumerator PowerAttack()
    {
        while(true)
        {
            yield return new WaitForSeconds(10);
            if (animator.GetBool ("Chase"))
                animator.SetBool("PowerAttack", true);
            if (animator.GetBool("Dead"))
            {
                animator.SetBool("PowerAttack", false);
                break;
            }
        }
        yield return null;
    }
    private void Update()
    {
        Debug.Log(OgreHealth);
    }
}
