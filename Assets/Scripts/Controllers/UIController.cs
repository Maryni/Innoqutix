using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private GameObject buttonOpen;
    [SerializeField] private GameObject buttonClose;

    #endregion Inspector variables

    #region Unity functions

    private void Start()
    {
        //SceneManager.sceneLoaded += SetActionWhenSceneLoaded;
    }

    #endregion Unity functions
    
    #region private functions

    public void ChangeVisibleState(GameObject item) => item.SetActive(!gameObject.activeSelf);

    #endregion private functions
}
