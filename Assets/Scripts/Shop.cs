using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    void Start()
    {
        buildManager=BuildManager._instance;
    }


    public void PurchaseStandardItem()
    {
        Debug.Log("Purchased Standard Item");
        buildManager.SetTurretToBuild(buildManager._standardTurretPrefab);
    }
    public void PurchaseAnotherItem()
    {
        Debug.Log("Purchased Another Item");
        buildManager.SetTurretToBuild(buildManager._anotherTurretPrefab);
    }
}
