using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogs : EnemyPathFinder
{
    [SerializeField]
    GameObject pig;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    Animator animDog;
    [SerializeField]
    GameController gameController;

    [SerializeField]
    SoundManager soundMgr;

    int animId;
    private void Start()
    {
        FindTarget();
    }
    private void Update()
    {
        Moving();
        ChangeAnim();
    }
    private void OnDisable()
    {
        gameController.countDogs++;
        if(pig != null)
        {
            soundMgr.PlaySound(1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
        }
    }
    void ChangeAnim()
    {
        animDog.SetInteger("Change", animId);
    }
    public override GameObject Target
    {
        get
        {
            return pig;
        }
        set
        {
            pig = value;
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
