﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static Action<Enemy, float> OnEnemyHit;
    
    [SerializeField] protected float moveSpeed = 10f;
    [SerializeField] protected float damage = 2f;
    [SerializeField] private float minDistanceToDealDamage = 0.1f;

    public TurretProjectile TurretOwner { get; set; }

    protected Enemy _enemyTarget;

    protected virtual void Update()
    {
        if (_enemyTarget != null)
        {
            RotateProjectile();
            MoveProjectile();
        }
    }

    protected virtual void MoveProjectile()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            _enemyTarget.transform.position,
            moveSpeed * Time.deltaTime);
        float distanceToTarget = (_enemyTarget.transform.position - transform.position).magnitude;

        if (distanceToTarget < minDistanceToDealDamage)
        {
            OnEnemyHit?.Invoke(_enemyTarget, damage);
            _enemyTarget.EnemyHealth.DealDamage(damage);
            TurretOwner.ResetTurretProjectile();
            ObjectPooler.ReturnToPool(gameObject);
        }
    }

    private void RotateProjectile()
    {
        Vector3 enemyPosition = _enemyTarget.transform.position - transform.position;
        float angle = Vector3.SignedAngle(
            transform.up,
            enemyPosition, 
            transform.forward);
        transform.Rotate(0f,0f,angle);
    }

    public void SetEnemy(Enemy enemy)
    {
        _enemyTarget = enemy;
    }

    public void ResetProjectile()
    {
        _enemyTarget = null;
        transform.localRotation = Quaternion.identity;
    }
}
