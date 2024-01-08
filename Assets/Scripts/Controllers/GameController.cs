using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private UIController uiController;
    [SerializeField] private WaveController waveController;
    [SerializeField] private MoveController moveController;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        if(objectPool == null)
        {
            objectPool = FindObjectOfType<ObjectPool>();
        }
        if (uiController == null)
        {
            uiController = FindObjectOfType<UIController>();
        }
        if (waveController == null)
        {
            waveController = FindObjectOfType<WaveController>();
        }
        if(moveController == null)
        {
            moveController = FindObjectOfType<MoveController>();
        }
        if(player == null)
        {
            player = FindObjectOfType<Player>();
        }

        waveController.SetListPlatforms(objectPool.GetListObjectsByType(ObjectType.FlyPlatform));
        waveController.InitSpawn();
    }
}
