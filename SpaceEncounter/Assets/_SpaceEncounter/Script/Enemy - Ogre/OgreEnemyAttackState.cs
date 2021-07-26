using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreEnemyAttackState : StateMachineBehaviour
{
    Transform playerTransform;
    Rigidbody rigidbody;
    OgreEnemySettings settings;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = GameObject.FindGameObjectWithTag("PlayerFoot").transform;
        rigidbody = animator.GetComponent<Rigidbody>();
        settings = animator.GetComponent<OgreEnemySettings>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var distance = Vector3.Distance(animator.transform.position, playerTransform.transform.position);

        Quaternion toRotation = Quaternion.LookRotation(playerTransform.position - animator.transform.position);
        rigidbody.MoveRotation(Quaternion.Slerp(animator.transform.rotation, toRotation, 2 * Time.fixedDeltaTime));

        if (distance > settings.AttackRange)
            animator.SetBool("Attack", false);

        if(distance < 4)
        {
            Vector3 direction = (animator.transform.position - playerTransform.position).normalized;
            rigidbody.MovePosition(animator.transform.position + direction * settings.ChaseSpeed * Time.fixedDeltaTime);
        }

        if (settings.OgreHealth < 0)
        {
            animator.SetBool("PowerAttack", false);
            animator.SetBool("Dead", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
