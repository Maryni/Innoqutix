using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    public int Index { get; set; }
    public bool IsSetted { get; set; }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
