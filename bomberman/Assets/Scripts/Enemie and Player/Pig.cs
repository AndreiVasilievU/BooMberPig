using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : EnemyPathFinder
{
    [SerializeField]
    GameObject touchPoint;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    Animator animPig;

    [SerializeField]
    SoundManager soundMgr;


    int animId;
    private void Start()
    {
        FindTarget();
    }
    void Update()
    {
        Moving();
        ChangeAnim();
    }
    private void OnDisable()
    {
        soundMgr.PlaySound(2);
    }
    void ChangeAnim()
    {
        animPig.SetInteger("Change", animId);
    }
    public override GameObject Target
    {
        get
        {
            return touchPoint;
        }
        set
        {
            touchPoint = value;
        }
    }
    public override float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
        set
        {
            moveSpeed = value;
        }
    }
    public override int AnimId
    {
        get
        {
            return animId;
        }
        set
        {
            animId = value;
        }
    }
}
