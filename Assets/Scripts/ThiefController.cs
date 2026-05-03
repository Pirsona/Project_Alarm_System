using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefController : MonoBehaviour
{
    [SerializeField] private List<Point> _points;
    [SerializeField] private float _speed;

    private int _index = 0;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, _points[_index].transform.position) < 0.1f)
        {
            _index = (_index + 1) % _points.Count;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position = Vector3.MoveTowards(transform.position, _points[_index].transform.position, _speed * Time.deltaTime);
        }
    }
}