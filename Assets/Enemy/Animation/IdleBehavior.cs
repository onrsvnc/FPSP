using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : StateMachineBehaviour
{
    [SerializeField] private float timeUntilBored;
    private bool isIdle;
    private float idleTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       ResetIdle(animator);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(isIdle == false)
        {
            idleTime += Time.deltaTime;

            if(idleTime > timeUntilBored)
            {
                isIdle = true;
                int idleAnim = Random.Range(0,2);

                animator.SetFloat("IdleAnimation", idleAnim);
            }

            
        }
        else if(stateInfo.normalizedTime % 1 > 0.98)
        {
            ResetIdle(animator);
        }
        
        
       
    }

    private void ResetIdle(Animator animator)
    {
        isIdle = false;
        idleTime = 0;
        animator.SetFloat("IdleAnimation", 0);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
       
    // }

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
