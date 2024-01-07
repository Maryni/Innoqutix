using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private MoveController moveController;

    public float X { get; private set; }
    public float Y { get; private set; }

    private void FixedUpdate()
    {
        SetXY();
    }

    private void SetXY()
    {
        if (X != gameObject.transform.position.x)
        {
            X = transform.position.x;
        }
        if (Y != gameObject.transform.position.y)
        {
            Y = transform.position.y;
        }
    }

}
