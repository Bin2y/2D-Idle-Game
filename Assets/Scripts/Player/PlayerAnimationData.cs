using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string runParmeterName = "Run";
    [SerializeField] private string attackParameterName = "Attack";
 
    public int idleParameterHash { get; private set; }
    public int runParameterHash { get; private set; }
    public int attackParameterHash { get; private set; }

    public void Initialize()
    {
        idleParameterHash = Animator.StringToHash(idleParameterName);
        runParameterHash = Animator.StringToHash(runParmeterName);
        attackParameterHash = Animator.StringToHash(attackParameterName);
    }
}
