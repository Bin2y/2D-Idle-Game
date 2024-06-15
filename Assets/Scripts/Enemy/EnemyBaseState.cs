using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine stateMachine;
    protected EnemyData enemyData;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        enemyData = stateMachine.enemy.data.EnemyData;
    }
    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
        TraceTarget();
    }

    public virtual void PhysicsUpdate()
    {
    }

    private void TraceTarget()
    {
        stateMachine.target = GameObject.FindGameObjectWithTag("Player");
    }

    protected void StartAnimation(int animatorHash)
    {
        stateMachine.enemy.animator.SetBool(animatorHash, true);
    }

    protected void StopAnimation(int animatorHash)
    {
        stateMachine.enemy.animator.SetBool(animatorHash, false);
    }



    protected bool IsInAttackinRange()
    {
        if (stateMachine.target == null) return false;
        float enemyDistanceSqr = (stateMachine.target.transform.position - stateMachine.enemy.transform.position).sqrMagnitude;
        return enemyDistanceSqr <= stateMachine.enemy.data.EnemyAttackInfoData.AttackRange * stateMachine.enemy.data.EnemyAttackInfoData.AttackRange;
    }
}
