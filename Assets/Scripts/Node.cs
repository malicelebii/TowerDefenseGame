using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    private Renderer _rend;
    private GameObject _turret;
    [SerializeField] Color _hoverColor;
    [SerializeField] Vector3 positionOffset;
    private Color _startColor;
    BuildManager buildManager;
    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        buildManager = BuildManager._instance;
    }



    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
            
        if (buildManager.GetTurretToBuild() == null)
            return;

        if (_turret != null)
        {
            Debug.LogError("Can't build turret there - Display ");
            return;
        }

        GameObject _turretToBuild = buildManager.GetTurretToBuild();
        _turret = Instantiate(_turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;
        _rend.material.color = _hoverColor;
    }


    void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }


}
