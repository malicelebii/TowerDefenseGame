using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    private Transform _target;
    private int _wavepointIndex = 0;

    void Start()
    {
        _target = Waypoints._points[0];
    }

    void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(_wavepointIndex>=Waypoints._points.Length-1){
            Destroy(gameObject);
            return;
        }
        
        _wavepointIndex++;
        _target=Waypoints._points[_wavepointIndex];
    }

}
