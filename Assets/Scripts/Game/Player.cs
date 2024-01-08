using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rig2D;
    [SerializeField] private float jumpSpeed;

    public float X { get; private set; }
    public float Y { get; private set; }

    public void Jump(Vector2 direction)
    {
        rig2D.AddForce(direction * jumpSpeed, ForceMode2D.Impulse);
        Debug.Log($"direction = {direction}");
    }
}
