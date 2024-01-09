using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum ObjectType
{
    FlyPlatform,
    EnemyBullet
}
public class ObjectPool : MonoBehaviour
{
    #region Inspector variables

    [Header("Prefabs for Init"), SerializeField] private List<GameObject> prefabsFlyPlatformList;
    [SerializeField] private List<GameObject> prefabsBulletsList;
    [Header("Inited objects"), SerializeField] private List<GameObject> initedFlyPlatformList;
    [SerializeField] private List<GameObject> initedBulletsList;
    [Header("Transform for pools"), SerializeField] private Transform transformFlyPlatformParent;
    [SerializeField] private Transform transformBulletsParent;
    [Header("Count inited object for each type"), SerializeField] private int countFlyPlatformExampleToInit;
    [SerializeField] private int countBulletsExampleToInit;

    #endregion Inspector variables

    #region private variables

    #endregion private variables

    #region properties

    public List<GameObject> PrefabsFlyPlatformList => prefabsFlyPlatformList;

    #endregion properties

    #region Unity functions

    private void Awake()
    {
        StartCoroutine(Init());
    }

    #endregion Unity functions

    #region public functions
    
    public GameObject GetObjectByType(ObjectType objectType)
    {
        if (objectType == ObjectType.FlyPlatform)
        {
            var findedObject = initedFlyPlatformList.Where(x => x.GetComponentInChildren<PlatformController>())
                .FirstOrDefault(x => !x.activeSelf);
            if (findedObject == null)
            {
                var exampleObject =
                    initedFlyPlatformList.FirstOrDefault(x => x.GetComponentInChildren<PlatformController>());
                var newObject = Instantiate(exampleObject, transformFlyPlatformParent);
                initedFlyPlatformList.Add(newObject);
                newObject.SetActive(true);
                return newObject;
            }
            findedObject.SetActive(true);
            return findedObject;
        }

        if(objectType == ObjectType.EnemyBullet)
        {
            var findedObject = initedBulletsList.FirstOrDefault(x => !x.activeSelf);
            if (findedObject == null)
            {
                var exampleObject = initedBulletsList.FirstOrDefault();
                var newObject = Instantiate(exampleObject, transformBulletsParent);
                initedBulletsList.Add(newObject);
                newObject.SetActive(true);
                return newObject;
            }
            findedObject.SetActive(true);
            return findedObject;
        }

        Debug.LogError("Incorrect Function GetObjectByType Work");
        return new GameObject();
    }

    public List<GameObject> GetListObjectsByType(ObjectType objectType)
    {
        if(objectType == ObjectType.FlyPlatform)
        {
            return initedFlyPlatformList;
        }

        if(objectType == ObjectType.EnemyBullet)
        {
            return initedBulletsList;
        }

        throw new Exception("There is no other type of return");
    }
    

    #endregion public functions

    #region private functions

    private IEnumerator Init()
    {
        if(countFlyPlatformExampleToInit > 0)
        {
            InitDefault(prefabsFlyPlatformList, countFlyPlatformExampleToInit, transformFlyPlatformParent, initedFlyPlatformList);
            InitDefault(prefabsBulletsList, countBulletsExampleToInit, transformBulletsParent, initedBulletsList);
        }
        yield break;
    }

    private void InitDefault(List<GameObject> list, int countGameObjectToInit, Transform transformParent, List<GameObject> exampleList)
    {
        for (int i = 0; i < countGameObjectToInit; i++)
        {
            for (int j = 0; j < list.Count; j++)
            {
                var obj = Instantiate(list[j], transformParent);
                obj.SetActive(false);
                exampleList.Add(obj);
            }
        }
    }

    #endregion private functions

}
