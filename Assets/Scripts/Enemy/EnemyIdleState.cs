using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        stateMachine.movementSpeedModifier = 0f;
        base.Enter();
        Debug.Log("IdleMode");
        StartAnimation(stateMachine.enemy.AnimationData.idleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("idleOut");
        StopAnimation(stateMachine.enemy.AnimationData.idleParameterHash);

    }

    public override void Update()
    {
        base.Update();
        if (IsInAttackinRange())
        {
            stateMachine.ChangeState(stateMachine.attackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
