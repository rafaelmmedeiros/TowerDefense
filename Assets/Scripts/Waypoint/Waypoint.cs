﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Vector3[] points;

    //
    public Vector3[] Points => points;
    public Vector3 CurrentPosition => _curretPosition;

    //
    private Vector3 _curretPosition;
    private bool _gameStarted;

    void Start()
    {
        _gameStarted = true;
        _curretPosition = transform.position;
    }

    public Vector3 GetWaypointPosition(int index)
    {
        return CurrentPosition + Points[index];
    }

    private void OnDrawGizmos()
    {
        if (!_gameStarted && transform.hasChanged)
        {
            _curretPosition = transform.position;
        }

        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(points[i] + _curretPosition, 0.5f);

            if (i < points.Length - 1)
            {
                Gizmos.color = Color.grey;
                Gizmos.DrawLine(points[i] + _curretPosition, points[i + 1] + _curretPosition);
            }
        }

    }
}
