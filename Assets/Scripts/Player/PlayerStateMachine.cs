using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;


public class PlayerStateMachine : StateMachine
{
    public Player player;
    public float movementSpeed {  get; private set; }
    public float movementSpeedModifier { get; set; }

    public GameObject target { get;  set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerChasingState chasingState { get; private set; }    
    public PlayerAttackState attackState { get; private set; }


    public PlayerStateMachine(Player player)
    {
        this.player = player;

        idleState = new PlayerIdleState(this);
        chasingState = new PlayerChasingState(this);
        attackState = new PlayerAttackState(this);

        movementSpeed = player.data.PlayerData.BaseSpeed;
    }
}
