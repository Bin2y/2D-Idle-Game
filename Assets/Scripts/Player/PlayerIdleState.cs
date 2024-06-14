using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("IdleMode");
        StartAnimation(stateMachine.player.AnimationData.idleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("idleOut");
        StopAnimation(stateMachine.player.AnimationData.idleParameterHash);

    }

    public override void Update()
    {
        base.Update();
        if(IsInChasinginRange())
        {
            stateMachine.ChangeState(stateMachine.chasingState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}