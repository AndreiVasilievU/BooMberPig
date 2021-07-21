using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dumping = 1.5f;
    public Vector2 offSet = new Vector2(2f, 1f);
    public bool isLeft;
    private Transform player;
    private int lastX;

    [SerializeField]
    float rightLimit;
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float upperLimit;
    [SerializeField]
    float bottomLimit;

    private void Start()
    {
        offSet = new Vector2(Mathf.Abs(offSet.x), offSet.y);
        FindPig(isLeft);
    }

    public void FindPig(bool pigIsLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (pigIsLeft)
        {
            transform.position = new Vector3(player.position.x - offSet.x, player.position.y - offSet.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offSet.x, player.position.y + offSet.y, transform.position.z);
        }
    }

    private void Update()
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX) isLeft = false;
            else if (currentX < lastX) isLeft = true;
            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if (isLeft)
            {
                target = new Vector3(player.position.x - offSet.x, player.position.y - offSet.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offSet.x, player.position.y + offSet.y, transform.position.z);
            }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y,bottomLimit,upperLimit),
            transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, upperLimit), new Vector2(rightLimit, bottomLimit));
    }
}
