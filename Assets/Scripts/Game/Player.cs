using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private MoveController moveController;
    private Vector2 touchPos;

    private void Start()
    {
        moveController.DoJump();
    }

    private void FixedUpdate()
    {
        if(Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = touch.position;
        }

        if (IsRightPartOfScreen())
        {
            moveController.DoRightMove();
        }
        else
        {
            moveController.DoLeftMove();
        }
    }

    private void GetTouchPosition()
    {
        Touch touch = Input.GetTouch(0);
    }

    private bool IsRightPartOfScreen()
    {
        if(touchPos.x > (Screen.width /2))
        {
            return true;
        }
        return false;
    }
}
