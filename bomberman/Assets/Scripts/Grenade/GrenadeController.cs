using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
    [SerializeField]
    GrenadePool grenadePool;

    [SerializeField]
    Transform grenadePointTr;

    public void OnInstalGrenade()
    {
        var _grenade = grenadePool.GetGrenade();
        _grenade.Prepare(grenadePointTr.position, grenadePointTr.rotation);
        _grenade.InstalGrenade();
    }
}
