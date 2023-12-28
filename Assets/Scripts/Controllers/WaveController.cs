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
            var obj1 = objects.FirstOrDefault(x => !x.activeSelf);
            SetPosition(obj1, SideType.Left);

            var obj2 = objects.FirstOrDefault(x => !x.activeSelf);
            SetPosition(obj2, SideType.Right);

            indexSpawn++;
        }
    }

    public void SetListPlatforms(List<GameObject> platforms)
    {
        objects = platforms;
    }

    public Vector3 GetPositionToMove(SideType sideType)
    {
        Vector3 posToMove;
        if(configuredObjects.Count > 0)
        {
            var selected = configuredObjects.FirstOrDefault(x => x.Index == indexSpawn - 1 && x.SideType == sideType);
            return selected.transform.position;
        }
        throw new Exception("There is no configurated objects");
    }

    private void SetPosition(GameObject item, SideType sideType)
    {

        item.SetActive(true);
        var currentPos = item.transform.position;
        if(currentPos.y >= 0)
        {
            float randX = 0;
            if(sideType == SideType.Left)
            {
                 randX = Random.Range(-2f, 0f);
            }
            if(sideType == SideType.Right)
            {
                 randX = Random.Range(0f, 2f);
            }

            item.transform.position = new Vector3(randX, delayBetweenPlatforms * indexSpawn);

            var platform = item.GetComponent<PlatformController>();
            platform.SideType = sideType;
            platform.Index = indexSpawn;

            configuredObjects.Add(platform);
            Debug.Log($"SET | {item} |{item.transform.position}|");
        }
    }
}

