using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field : SerializeField] public PlayerSO data { get; private set; }
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }
    public Animator animator { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }

    public PlayerStateMachine stateMachine;
    public CharacterController2D controller { get; private set; }

    public AttackHandler attackHandler { get; private set; }
    public Health health { get; private set; }

    public bool isChasing = false;


    private void Awake()
    {
        GameManager.Instance.player = this;
        AnimationData.Initialize();
        animator = GetComponentInChildren<Animator>();
        stateMachine = new PlayerStateMachine(this);
        controller = GetComponent<CharacterController2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        health = GetComponent<Health>();
        attackHandler = GetComponentInChildren<AttackHandler>();
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
