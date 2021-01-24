using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class DamageTextManager : MonoBehaviour
{
    public ObjectPooler Pooler { get; set; }
    public static DamageTextManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Pooler = GetComponent<ObjectPooler>();
    }
}
