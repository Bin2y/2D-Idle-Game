using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy enemy;

    public float movementSpeed { get; private set; }
    public float movementSpeedModifier { get; set; }

    public bool isChasing { get; set; }


    public GameObject target { get; set; }

    public EnemyIdleState idleState { get; private set; }
    public EnemyAttackState attackState { get; private set; }

    public EnemyStateMachine(Enemy enemy)
    {
        this.enemy = enemy;

        idleState = new EnemyIdleState(this);
        attackState = new EnemyAttackState(this);

        movementSpeed = enemy.data.EnemyData.BaseSpeed;
    }
}
