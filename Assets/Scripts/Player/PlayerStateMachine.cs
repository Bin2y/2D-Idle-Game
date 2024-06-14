using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStateMachine : StateMachine
{
    public Player player;
    public float movementSpeed {  get; private set; }
    public float movementSpeedModifier { get; set; } = 1f;

    public GameObject target { get;  set; }

    public PlayerChasingState chasingState { get; private set; }    


    public PlayerStateMachine(Player player)
    {
        this.player = player;
        

        chasingState = new PlayerChasingState(this);
        movementSpeed = player.data.PlayerData.BaseSpeed;
    }
}
