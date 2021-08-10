using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform _target;
    [Header("Attributes")]
    [SerializeField] float _range = 15f;
    [SerializeField] float _fireRate = 1f;
    private float _fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    [SerializeField] float _turnSpeed = 15f;
    [SerializeField] Transform partToRotate;

    [SerializeField] string _enemy = "Enemy";

    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _firePoint;




    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    void UpdateTarget()
    {
        GameObject[] _enemies = GameObject.FindGameObjectsWithTag(_enemy);
        float _shortestDistance = Mathf.Infinity;
        GameObject _nearestEnemy = null;
        foreach (GameObject _enemy in _enemies)
        {
            float _distanceToEnemy = Vector3.Distance(transform.position, _enemy.transform.position);
            if (_distanceToEnemy < _shortestDistance)
            {
                _shortestDistance = _distanceToEnemy;
                _nearestEnemy = _enemy;
            }
        }


        if (_nearestEnemy != null && _shortestDistance <= _range)
        {
            _target = _nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (_target == null)
        {
            return;
        }


        Vector3 _dir = _target.position - transform.position;
        Quaternion _lookRotation = Quaternion.LookRotation(_dir);
        Vector3 _rotation = Quaternion.Lerp(partToRotate.rotation, _lookRotation, Time.deltaTime * _turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, _rotation.y, 0f);

        if (_fireCountdown <= 0)
        {
            Shoot();
            _fireCountdown = 1f / _fireRate;
        }

        _fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet!=null){
            bullet.Seek(_target);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }


}
