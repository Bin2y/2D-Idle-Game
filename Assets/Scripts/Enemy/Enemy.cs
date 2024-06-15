using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public EnemySO data { get; private set; }
    public Animator animator { get; private set; }
    public EnemyStateMachine stateMachine;
    public EnemyAttackHandler attackHandler { get; private set; }
    public Health health { get; private set; }


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        stateMachine = new EnemyStateMachine(this);
        attackHandler = GetComponentInChildren<EnemyAttackHandler>();  
        health = GetComponent<Health>();  
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.idleState);
    }
    private void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }
}
