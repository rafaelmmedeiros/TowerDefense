﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private Transform barPosition;

    [SerializeField] private float initialHealth = 10f;
    [SerializeField] private float maxHealth = 10f;
    
    //  REFERENCES
    public float CurrentHealth { get; set; }
    
    //  INTERNAL VARIABLES
    private Image _healthBar;
    
    //  ACTIONS
    //  EVENTS
    void Start()
    {
        CreateHealthBar();
        CurrentHealth = initialHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DealDamage(5f);
        }

        _healthBar.fillAmount = Mathf.Lerp(
            _healthBar.fillAmount,
            CurrentHealth/maxHealth,
            Time.deltaTime * 10f);
    }

    //  BEHAVIOR
    public void DealDamage(float damageReceived)
    {
        CurrentHealth -= damageReceived;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        CurrentHealth = initialHealth;
        _healthBar.fillAmount = 1f;
        ObjectPooler.ReturnToPool(gameObject);
    }
    
    //  AUX
    private void CreateHealthBar()
    {
        GameObject newBar = Instantiate(
            healthBarPrefab,
            barPosition.position,
            Quaternion.identity);
        newBar.transform.SetParent(transform);

        EnemyHealthContainer container = newBar.GetComponent<EnemyHealthContainer>();
        _healthBar = container.FillAmountImage;
    }
}
