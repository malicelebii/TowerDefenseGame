using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Renderer _rend;
    private GameObject _turret;
    [SerializeField] Color _hoverColor;
    [SerializeField] Vector3 positionOffset;
    private Color _startColor;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
    }



    void OnMouseDown()
    {
        if (_turret != null)
        {
            Debug.LogError("Can't build turret there - Display ");
            return;
        }

        GameObject _turretToBuild = BuildManager._instance.GetTurretToBuild();
        _turret = Instantiate(_turretToBuild,transform.position+positionOffset,transform.rotation);
    }

    void OnMouseEnter()
    {
        _rend.material.color = _hoverColor;
    }


    void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }


}
