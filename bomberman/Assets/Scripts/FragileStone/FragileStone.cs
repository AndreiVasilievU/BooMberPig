using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileStone : MonoBehaviour
{
    public virtual void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
        if (other.name == "Parctical")
        {
            gameObject.SetActive(false);
        }
    }
}
