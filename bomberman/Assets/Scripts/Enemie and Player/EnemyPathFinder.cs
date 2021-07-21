using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyPathFinder : MonoBehaviour
{
    private List<Vector2> PathToTarget = new List<Vector2>();
    private PathFinder PathFinder;
    private bool isMoving;
    public virtual void FindTarget()
    {
        if (Target != null)
        {
            PathFinder = GetComponent<PathFinder>();
            PathToTarget = PathFinder.GetPath(Target.transform.position);
            isMoving = true;
        }
    }

    public virtual void Moving()
    {
        if (Target == null) return;

        if (PathToTarget.Count == 0 && Vector2.Distance(transform.position, Target.transform.position) > 0.5f)
        {
            PathToTarget = PathFinder.GetPath(Target.transform.position);
            isMoving = true;
        }

        if (PathToTarget.Count == 0)
        {
            return;
        }

        if (isMoving)
        {
            if (Vector2.Distance(transform.position, PathToTarget[PathToTarget.Count - 1]) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, PathToTarget[PathToTarget.Count - 1], MoveSpeed * Time.deltaTime);
                if(Mathf.Round(PathToTarget[PathToTarget.Count - 1].x - transform.position.x) > 0)
                {
                    AnimId = 1;
                }
                else if(Mathf.Round(PathToTarget[PathToTarget.Count - 1].x - transform.position.x) < 0)
                {
                    AnimId = 2;
                }
                else if (Mathf.Round(PathToTarget[PathToTarget.Count - 1].y - transform.position.y) > 0)
                {
                    AnimId = 3;
                }
                else if(Mathf.Round(PathToTarget[PathToTarget.Count - 1].y - transform.position.y) < 0)
                {
                    AnimId = 4;
                }
            }
            if (Vector2.Distance(transform.position, PathToTarget[PathToTarget.Count - 1]) <= 0.1f)
            {
                isMoving = false;
            }
        }
        else
        {
            PathToTarget = PathFinder.GetPath(Target.transform.position);
            isMoving = true;
        }
    }

    public virtual void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
        if (other.name == "Parctical")
        {
            gameObject.SetActive(false);
        }
    }
    public abstract int AnimId { get; set; }
    public abstract GameObject Target { get; set; }
    public abstract float MoveSpeed { get; set; }
}
