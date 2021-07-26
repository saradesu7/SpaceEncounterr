using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreEnemyWalkState : StateMachineBehaviour
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
        if (distance < settings.PlayerRange)
            animator.SetBool("Chase", true);
        else
            rigidbody.MovePosition(animator.transform.position + animator.transform.forward * settings.WalkSpeed * Time.fixedDeltaTime);
            //rigidbody.AddRelativeForce(animator.transform.forward * settings.WalkSpeed);
            //animator.transform.Translate(Vector3.forward * settings.WalkSpeed * Time.fixedDeltaTime);
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
