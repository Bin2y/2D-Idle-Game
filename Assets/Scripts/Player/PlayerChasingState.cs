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
        stateMachine.movementSpeedModifier = 3;
        base.Enter();
        Debug.Log("Chasing Mode");
        StartAnimation(stateMachine.player.AnimationData.runParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.player.AnimationData.runParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if(stateMachine.target == null)
        {
            stateMachine.ChangeState(stateMachine.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Move();
    }
}
