using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public class WaveController : MonoBehaviour
{
    [Header("Wave Settings"),SerializeField] private float delayBetweenPlatforms;
    //[SerializeField] private int countAtLineMax;
    [SerializeField] private float minYToSpawn;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    private int indexSpawn = 0;
    [SerializeField] private List<GameObject> objects = new List<GameObject>();
    [SerializeField] private List<PlatformController> configuredObjects = new List<PlatformController>();

    public void InitSpawn()
    {
        Spawn();
        Spawn();
    }

    public void Spawn()
    {
        if(objects.Count > 0)
        {
            indexSpawn++;
        }
    }

    public void SetListPlatforms(List<GameObject> platforms)
    {
        objects = platforms;
    }

    public Vector3 GetPositionToMove()
    {
        if(configuredObjects.Count > 0)
        {
            var selected = configuredObjects.FirstOrDefault(x => x.Index == indexSpawn - 1);
            return selected.transform.position;
        }
        throw new Exception("There is no configurated objects");
    }
}

