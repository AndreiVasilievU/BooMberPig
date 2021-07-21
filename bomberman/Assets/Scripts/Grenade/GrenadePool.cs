using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePool : MonoBehaviour
{
    [SerializeField]
    GameObject grenadePrefab;

    List<Grenade> grenades;

    private void Awake()
    {
        grenades = new List<Grenade>();
    }
    public Grenade GetGrenade()
    {
        Grenade _grenade = grenades.Find(_g => !_g.IsActive);
        if(_grenade == null)
        {
            _grenade = Instantiate(grenadePrefab, transform).GetComponent<Grenade>();
            grenades.Add(_grenade);
        }

        return _grenade;
    }
}
