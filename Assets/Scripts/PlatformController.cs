using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SideType
{
    None,
    Left,
    Right
}

public class PlatformController : MonoBehaviour
{
    [SerializeField] private BoxCollider defaultBoxCollider;
    [SerializeField] private BoxCollider triggerBoxCollider;
    [SerializeField] private Transform pointToMoveOn;
    [SerializeField] private SideType sideType;


}
