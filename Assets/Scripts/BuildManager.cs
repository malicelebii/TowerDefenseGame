using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager _instance;
    private GameObject _turretToBuild;
    public GameObject _standardTurretPrefab;
    public GameObject _anotherTurretPrefab;

    void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("More than one BuildManager");
        }
        _instance = this;
    }

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        _turretToBuild=turret;
    }


}
