using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float speedMod;

    private Vector3 moveToPos = Vector3.zero;
    private Action onLeftMove;
    private Action onRightMove;

    private void Update()
    {
        DoMove();
    }

    public void DoMove()
    {
        if(moveToPos != Vector3.zero)
        {
            float step = speedMod * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, moveToPos, step);

        }
    }

    public void DoMoveRight()
    {
        onRightMove?.Invoke();
        Debug.Log($"movePos = {moveToPos}");
    }

    public void DoMoveLeft()
    {
        onLeftMove?.Invoke();
        Debug.Log($"movePos = {moveToPos}");
    }

    public void SetMovePosition(Vector3 pos) => moveToPos = pos;

    public void SetActionOnRightMove(params Action[] actions)
    {
        foreach(var item in actions)
        {
            onRightMove += item;
        }
    }

    public void SetActionOnLeftMove(params Action[] actions)
    {
        foreach (var item in actions)
        {
            onLeftMove += item;
        }
    }

}
