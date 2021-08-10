using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    [SerializeField] GameObject _impactEffect;
    [SerializeField] float _speed=70f;
    public void Seek(Transform target){
        _target=target;
    }
    // Update is called once per frame
    void Update()
    {
        if(_target==null){
            Destroy(gameObject);
            return;
        }


        Vector3 dir=_target.position-transform.position;
        float distanceThisFrame = _speed *Time.deltaTime;


        if(dir.magnitude<=distanceThisFrame){
            HitTarget();
            return;
        }


        transform.Translate(dir.normalized*distanceThisFrame,Space.World);

    }


    void HitTarget(){
        GameObject effectIns= Instantiate(_impactEffect,transform.position,transform.rotation);
        Destroy(effectIns,2f);
        Destroy(gameObject);
        Destroy(_target.gameObject);
        Debug.Log("We hit something");
    }


}
