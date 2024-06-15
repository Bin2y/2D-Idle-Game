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
        stateMachine.movementSpeedModifier = 0;
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.player.AnimationData.attackParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (IsInAttackinRange()) return; //조건 더 추가해서 계속 몬스터를 추적시켜야함 가까이 있을경우
        if(IsInChasinginRange())
        {
            stateMachine.ChangeState(stateMachine.chasingState);
            return;
        }
        else
        {
            stateMachine.ChangeState(stateMachine.idleState);
            return;
        }
    }
}
