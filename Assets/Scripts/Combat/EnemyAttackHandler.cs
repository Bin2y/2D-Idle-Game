using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHandler : AttackHandler
{
    private Enemy enemy;

    private void Awake()
    {
        //어택핸들러는 애니메이션에 부착해야하는 이벤트때문에 자식오브젝트에 붙어있음
        enemy = GetComponentInParent<Enemy>();
    }
    public override GameObject GetTarget()
    {
        return enemy.stateMachine.target;
    }

    public override void OnAttack()
    {
        GameObject go = GetTarget();
        int damage = (int)enemy.data.EnemyAttackInfoData.BaseDamage;
        if (go.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(damage);
        }
    }
}
