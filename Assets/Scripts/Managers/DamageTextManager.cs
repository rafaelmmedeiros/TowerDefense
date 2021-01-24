using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class DamageTextManager : Singleton<DamageTextManager>
{
    public ObjectPooler Pooler { get; set; }

    void Start()
    {
        Pooler = GetComponent<ObjectPooler>();
    }
}
