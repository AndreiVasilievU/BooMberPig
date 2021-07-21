using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    SpriteRenderer grenadeSr;
    Rigidbody2D grenadeRB;
    [SerializeField]
    GameObject explosion;
    SoundManager soundMgr;

    private void Awake()
    {
        soundMgr = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        grenadeSr = GetComponent<SpriteRenderer>();
        grenadeRB = GetComponent<Rigidbody2D>();
    }
    public void Prepare(Vector2 _position, Quaternion _rotation)
    {
        transform.position = _position;
        transform.rotation = _rotation;
        gameObject.SetActive(true);
        explosion.gameObject.SetActive(false);
    }

    public void InstalGrenade()
    {
        grenadeRB.AddForce(transform.forward);

        StartCoroutine(DeactivateDelayed(2.5f));
        StartCoroutine(Explosion(2f));
    }

    IEnumerator DeactivateDelayed(float _time)
    {
        yield return new WaitForSeconds(_time);
        gameObject.SetActive(false);
    }
    
    IEnumerator Explosion(float _time)
    {
        yield return new WaitForSeconds(_time);
        soundMgr.PlaySound(0);
        explosion.gameObject.SetActive(true);
    }

    public bool IsActive => gameObject.activeSelf;
}
