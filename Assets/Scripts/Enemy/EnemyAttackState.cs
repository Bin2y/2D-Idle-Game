using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enemy Attack Mode");
        StartAnimation(stateMachine.enemy.AnimationData.attackParameterHash);
        stateMachine.movementSpeedModifier = 0;
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.enemy.AnimationData.attackParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (IsInAttackinRange()) return; 
        stateMachine.ChangeState(stateMachine.idleState);
        return;
    }
}
