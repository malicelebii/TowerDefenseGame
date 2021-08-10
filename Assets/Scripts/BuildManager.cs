using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager _instance;
    private GameObject _turretToBuild;
    [SerializeField] GameObject _turretPrefab;

    void Awake()
    {
        if(_instance !=null){
            Debug.LogError("More than one BuildManager");
        }
        _instance = this;
    }

    void Start(){
        _turretToBuild=_turretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }

}
