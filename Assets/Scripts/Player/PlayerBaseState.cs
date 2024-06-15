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
        if (stateMachine.isChasing)
            Move();
        else
            StopMove();
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

    protected void StopMove()
    {
        Move(Vector2.zero);
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
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        stateMachine.player.spriteRenderer.flipX = angle > 90 ? true : false;
    }

    

    protected bool IsInChasinginRange()
    {
        if(stateMachine.target == null) return false;
        float enemyDistanceSqr = (stateMachine.target.transform.position - stateMachine.player.transform.position).sqrMagnitude;
        return enemyDistanceSqr <= stateMachine.player.data.AttackData.EnemyChasingRange * stateMachine.player.data.AttackData.EnemyChasingRange;
    }

    protected bool IsInAttackinRange()
    {
        if (stateMachine.target == null) return false;
        float enemyDistanceSqr = (stateMachine.target.transform.position - stateMachine.player.transform.position).sqrMagnitude;
        return enemyDistanceSqr <= stateMachine.player.data.AttackData.AttackRange * stateMachine.player.data.AttackData.AttackRange;
    }
}
