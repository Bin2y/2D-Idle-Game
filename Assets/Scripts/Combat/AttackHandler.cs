using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackHandler : MonoBehaviour
{
    public abstract void OnAttack();
    public abstract GameObject GetTarget();
}
