using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveLoadController : MonoBehaviour
{
    #region Inspector variables

    //[SerializeField] private List<LevelData> levelDatas;
    [SerializeField] private int lastCompleteLevel;

    #endregion Inspector variables

    #region properties

    public int LastCompleteLevel => lastCompleteLevel;

    #endregion properties
    
    #region Unity functions

    #endregion Unity functions
    
    #region public functions
    /*
    public LevelData GetFullLevelData(int index)
    {
        return levelDatas[index];
    }

    public int GetCountWavesOnLevelData(int indexLevel)
    {
        return levelDatas[indexLevel].GetWaveCount();
    }
    */

    #endregion public functions

    #region private functions

    #endregion private functions

}
