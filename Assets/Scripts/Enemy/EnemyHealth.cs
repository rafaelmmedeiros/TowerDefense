using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private Transform barPosition;

    [SerializeField] private float initialHealth = 10f;
    [SerializeField] private float maxHealth = 10f;

    
    // Start is called before the first frame update
    void Start()
    {
        CreateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateHealthBar()
    {
        GameObject newBar = Instantiate(
            healthBarPrefab,
            barPosition.position,
            Quaternion.identity);
        newBar.transform.SetParent(transform);
    }
}
