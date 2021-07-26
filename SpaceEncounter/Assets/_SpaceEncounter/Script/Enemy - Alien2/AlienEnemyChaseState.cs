using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEnemyChaseState : StateMachineBehaviour
{
    Transform playerTransform;
    Transform enemyRootTransform;
    Transform enemyParentTransform;
    Rigidbody enemyRB;
    AlienSettings alienSettings;
    AlienEnemyDamageTaken damageTaken;
    AlienEnemyManager alienEnemyManager;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        enemyRootTransform = animator.GetComponent<Transform>();
        enemyParentTransform = enemyRootTransform.transform.parent.transform;
        enemyRB = enemyParentTransform.GetComponent<Rigidbody>();
        alienSettings = animator.GetComponent<AlienSettings>();
        damageTaken = animator.GetComponent<AlienEnemyDamageTaken>();
        alienEnemyManager = animator.transform.parent.GetComponent<AlienEnemyManager>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var distance = Vector3.Distance(enemyParentTransform.position, playerTransform.transform.position);

        Quaternion toRotation = Quaternion.LookRotation(playerTransform.position - enemyParentTransform.position);
        enemyRB.MoveRotation(Quaternion.Slerp(enemyParentTransform.rotation, toRotation, 2 * Time.fixedDeltaTime));

        Vector3 direction = (playerTransform.position - enemyParentTransform.position).normalized;
        if(distance > 3)
            enemyRB.MovePosition(enemyParentTransform.position + direction * alienSettings.alienSpeed * Time.fixedDeltaTime);

        //Debug.Log(controller.animationClips[3].GetHashCode());

        if (distance <= alienSettings.attackShootRange && animator.GetBool("CanShoot"))
            animator.SetBool("InAttackShootRange", true);
        else if (distance <= alienSettings.attackScratchRange)
            animator.SetBool("InAttackScratchRange", true);

        if (damageTaken.alienHealth < 6 && animator.GetBool("CanShoot"))
            alienEnemyManager.ShootToEnrage();

        if(damageTaken.alienHealth < 0)
        {
            animator.SetBool("IsDead", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("IsDead"))
        {
            Destroy( alienEnemyManager.gameObject.GetComponent<CapsuleCollider>());
            Destroy(alienEnemyManager.gameObject.GetComponent<Rigidbody>());
            Destroy(animator.gameObject.GetComponent<CapsuleCollider>());
            int random = Random.Range(2, 5);
            for (int i = 0; i < random; i++)
                Instantiate(alienEnemyManager.eneryOrb, animator.transform);
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
