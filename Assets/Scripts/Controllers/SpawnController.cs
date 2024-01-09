using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private int min;
    [SerializeField] private int max;

    private ObjectPool objectPool;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        if (objectPool == null)
        {
            objectPool = FindObjectOfType<ObjectPool>();
        }
        Spawn();
    }

    private void Spawn()
    {
        var number = Random.Range(min, max+1);
        for(int i=0; i < number; i++)
        {
            var x = Random.Range(250f, Screen.width - 250f);
            var y = Random.Range(100f, Screen.height - 350f);

            var item = objectPool.GetObjectByType(ObjectType.FlyPlatform);
            item.transform.position = new Vector3(x,y);
            item.SetActive(true);
        }
        Debug.Log($"Spawn for {number} finished");
    }
}

