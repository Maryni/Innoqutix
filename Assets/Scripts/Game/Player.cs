using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private MoveController moveController;
    private Vector2 touchPos;

    private void FixedUpdate()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = touch.position;
            Debug.Log($"[Touch] mousePos = {touchPos}");
            ChooseMove();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            touchPos = Input.mousePosition;
            Debug.Log($"[Mouse] mousePos = {touchPos}");
            ChooseMove();
        }
    }

    private void ChooseMove()
    {
        if (IsRightPartOfScreen())
        {
            moveController.DoMoveRight();
            Debug.Log("Right");
        }
        else
        {
            moveController.DoMoveLeft();
            Debug.Log("Left");
        }
    }

    private bool IsRightPartOfScreen()
    {
        if (Camera.main.WorldToScreenPoint(touchPos).x >= (Screen.width /2))
        {
            return true;
        }
        return false;
    }
}
