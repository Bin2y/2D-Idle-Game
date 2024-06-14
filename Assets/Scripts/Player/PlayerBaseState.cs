using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        playerData = stateMachine.player.data.PlayerData;
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

    protected void StartAnimation(int animatorHash)
    {
        stateMachine.player.animator.SetBool(animatorHash, true);
    }

    protected void StopAnimation(int animatorHash)
    {
        stateMachine.player.animator.SetBool(animatorHash, false);
    }

    protected void Move()
    {
        Vector2 movementDirection = GetMovementDirection();
        Move(movementDirection);
        Rotate(movementDirection);
    }

    private Vector2 GetMovementDirection()
    {
        if (stateMachine.target == null) return Vector2.zero;
        Vector2 direction = (stateMachine.target.transform.position - stateMachine.player.transform.position).normalized;
        return direction;
    }
    private void TraceTarget()
    {
        stateMachine.target = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void Move(Vector2 direction)
    {
        float movementSpeed = GetMovementSpeed();
        stateMachine.player.controller.Move((direction * movementSpeed) * Time.deltaTime);
    }

    private float GetMovementSpeed()
    {
        float moveSpeed = stateMachine.movementSpeed * stateMachine.movementSpeedModifier;
        return moveSpeed;
    }

    private void Rotate(Vector2 direction)
    {
        //TODO : 좌우 방향에 따라서 flip 해보기?
    }

    

    protected bool IsInChasinginRange()
    {
        if(stateMachine.target == null) return false;
        float enemyDistanceSqr = (stateMachine.target.transform.position - stateMachine.target.transform.position).sqrMagnitude;
        return enemyDistanceSqr <= stateMachine.player.data.AttackData.EnemyChasingRange * stateMachine.player.data.AttackData.EnemyChasingRange;
    }

    protected bool IsInAttackinRange()
    {
        return false;
    }
}
