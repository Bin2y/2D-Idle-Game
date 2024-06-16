using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public EnemySO data { get; set; }
    public Animator animator { get; private set; }
    public EnemyStateMachine stateMachine;
    public EnemyAttackHandler attackHandler { get; private set; }
    public Health health { get; private set; }


    private void Awake()
    {
        GameManager.Instance.enemy = this;
        animator = GetComponentInChildren<Animator>();
        stateMachine = new EnemyStateMachine(this);
        attackHandler = GetComponentInChildren<EnemyAttackHandler>();  
        health = GetComponent<Health>();  
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.idleState);
        //일단 코인보상은 몬스터의 체력만큼주는것으로
        data.GoldReward = health.maxHealth;
        health.OnDie += Die;
        health.OnDie += GameManager.Instance.NextWave;
    }

    private void Die()
    {
        GameManager.Instance.gold += data.GoldReward;
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
