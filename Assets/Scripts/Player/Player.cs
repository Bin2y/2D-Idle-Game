using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field : SerializeField] public PlayerSO data { get; private set; }
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }
    public Animator animator { get; private set; }

    private PlayerStateMachine stateMachine;
    public CharacterController2D controller { get; private set; }


    private void Awake()
    {
        AnimationData.Initialize();
        animator = GetComponentInChildren<Animator>();
        stateMachine = new PlayerStateMachine(this);
        controller = GetComponent<CharacterController2D>();
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
