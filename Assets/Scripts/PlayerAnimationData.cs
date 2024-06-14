using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string walkParmeterName = "Walk";
 
    public int idleParameterHash { get; private set; }
    public int walkParameterHash { get; private set; }

    public void Initialize()
    {
        idleParameterHash = Animator.StringToHash(idleParameterName);
        walkParameterHash = Animator.StringToHash(walkParmeterName);
    }
}
