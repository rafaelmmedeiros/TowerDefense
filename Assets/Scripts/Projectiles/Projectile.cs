using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 10f;

    private Enemy _enemyTarget;

    private void Update()
    {
        if (_enemyTarget != null)
        {
            RotateProjectile();
            MoveProjectile();
        }
    }

    private void MoveProjectile()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            _enemyTarget.transform.position,
            MoveSpeed * Time.deltaTime);
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
}
