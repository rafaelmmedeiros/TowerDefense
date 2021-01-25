using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTurretProjectile : TurretProjectile
{
    [SerializeField] private bool isDualMachine;
    [SerializeField] private float spreadRange;
    
    protected override void Update()
    {
        if (Time.time> _nextAttackTime)
        {
            if (_turret.CurrentEnemyTarget != null)
            {
                Vector3 dirToTarget = _turret.CurrentEnemyTarget.transform.position - transform.position;
                FireProjectile(dirToTarget);
            }

            _nextAttackTime = Time.time + delayBetweenAttacks;
        }
    }

    protected override void LoadProjectile() {}

    private void FireProjectile(Vector3 direction)
    {
        var instance = _pooler.GetInstanceFromPool();
        instance.transform.position = projectileSpawnPosition.position;

        var projectile = instance.GetComponent<MachineProjectile>();
        projectile.Direction = direction;

        if (isDualMachine)
        {
            var randomSpread = Random.Range(-spreadRange, spreadRange);
            var spread = new Vector3(0f, 0f, randomSpread);
            var spreadValue = Quaternion.Euler(spread);
            var newDirection = spreadValue * direction;
            projectile.Direction = newDirection;
        }
        
        instance.SetActive(true);
    }
}