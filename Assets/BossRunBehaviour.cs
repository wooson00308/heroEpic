using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRunBehaviour : StateMachineBehaviour
{
    private Character _character;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _character = animator.GetComponentInParent<Character>();
        animator.SetFloat("MoveDuration", 0);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_character == null) return;

        var player = GameManager.Instance.Player;
        if (player == null)
        {
            animator.SetBool("Run", false);

            return;
        }

        float attackDelaying = animator.GetFloat("AttackDelaying");
        if (attackDelaying > 0)
        {
            animator.SetFloat("AttackDelaying", attackDelaying - Time.deltaTime);
            animator.SetBool("Run", false);
            return;
        }

        Vector3 direction = player.transform.position - _character.transform.position;
        direction.Normalize();

        var ai = _character.controller as AIController;
        float moveDuration = animator.GetFloat("MoveDuration");
        animator.SetFloat("MoveDuration", moveDuration+Time.deltaTime);

        if (moveDuration >= ai.moveDuration)
        {
            _character.Attack(direction);
            return;
        }

        float distance = Vector2.Distance(_character.transform.position, player.transform.position);
        if(distance <= ai.attackDistance)
        {
            _character.Attack(direction);
        }
        else
        {
            _character.Move(direction);
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
