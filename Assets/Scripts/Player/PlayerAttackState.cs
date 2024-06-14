using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Attack Mode");
        StartAnimation(stateMachine.player.AnimationData.attackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.player.AnimationData.attackParameterHash);
    }

    public override void Update()
    {
        base.Update();
    }
}
