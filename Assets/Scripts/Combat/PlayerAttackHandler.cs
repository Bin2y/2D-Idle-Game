using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHandler : AttackHandler
{
    private Player player;

    private void Awake()
    {
        //어택핸들러는 애니메이션에 부착해야하는 이벤트때문에 자식오브젝트에 붙어있음
        player = GetComponentInParent<Player>();
    }
    public override GameObject GetTarget()
    {
        return player.stateMachine.target;
    }

    public override void OnAttack()
    {
        GameObject go = GetTarget();
        int damage = (int)player.data.AttackData.BaseDamage +(int)player.data.AttackData.DamageModifier;
        if (go.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(damage);
        }  
    }



    
}
