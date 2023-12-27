using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageController : MonoBehaviour
{
    [SerializeField] private UniWebView uniWebView;
    [SerializeField] private AppsFlyerObjectScript script;
    [SerializeField] private UIController uiController;

    private void Start()
    {
        SetActions();
    }

    private void SetActions()
    {
        script.SetOnSuccessAction(
            () => uniWebView.Show(),
            () => uniWebView.Load(script.neededWebEye)
            );

    }
}
