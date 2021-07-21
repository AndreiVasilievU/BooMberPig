using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchFingerPoint1 : MonoBehaviour
{
    [SerializeField]
    GameObject touchFingerPoint;
    [SerializeField]
    GameObject touchPoint;
    [SerializeField]
    Animator targetMarkerAnim;

    Vector2 touchPos;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                touchFingerPoint.transform.position = touchPos;
            }            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Wall")
        {
            targetMarkerAnim.SetInteger("ChangeTarget",2);
        }
        if(collision.gameObject.tag == "Earth")
        {
            touchPoint.transform.position = touchFingerPoint.transform.position;
            targetMarkerAnim.SetInteger("ChangeTarget", 1);
        }
    }
}
