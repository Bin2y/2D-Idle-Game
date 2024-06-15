using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerChasingState : PlayerBaseState
{
    public PlayerChasingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.movementSpeedModifier = 10;
        base.Enter();
        Debug.Log("Chasing Mode");
        StartAnimation(stateMachine.player.AnimationData.runParameterHash);
        stateMachine.isChasing = true;

    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.player.AnimationData.runParameterHash);
        stateMachine.isChasing = false;
    }

    public override void Update()
    {
        base.Update();
        if (stateMachine.target == null || !IsInChasinginRange())
        {
            stateMachine.ChangeState(stateMachine.idleState);
            return;
        }
        if (IsInAttackinRange())
        {
            stateMachine.ChangeState(stateMachine.attackState);
            return;
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
