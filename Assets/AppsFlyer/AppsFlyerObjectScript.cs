using System.Collections.Generic;
using UnityEngine;
using AppsFlyerSDK;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections;



// This class is intended to be used the the AppsFlyerObject.prefab

public class AppsFlyerObjectScript : MonoBehaviour, IAppsFlyerConversionData
{

    public string devKey;
    public string appID;
    public string UWPAppID;
    public string macOSAppID;
    public string playerDataURL;
    public string signalAppId;
    public string packageName;
    public bool isDebug;
    public bool getConversionData;
    public string resultUserData;
    public string BigData;

    public Dictionary<string, object> Data = new Dictionary<string, object>();
    public List<string> dataResult = new List<string>();
    public List<string> userDataResult = new List<string>();
    public string neededWebEye;
    public Action onSuccess;

    void Start()
    {
        AppsFlyer.setIsDebug(isDebug);
#if UNITY_WSA_10_0 && !UNITY_EDITOR
        AppsFlyer.initSDK(devKey, UWPAppID, getConversionData ? this : null);
#elif UNITY_STANDALONE_OSX && !UNITY_EDITOR
    AppsFlyer.initSDK(devKey, macOSAppID, getConversionData ? this : null);
#elif UNITY_ANDROID
        AppsFlyer.initSDK(devKey, null, getConversionData ? this : null);
#elif UNITY_IOS
        AppsFlyer.initSDK(devKey, appID, getConversionData ? this : null);
#endif
        AppsFlyer.startSDK();

        GetPublicData();
    }

    public async void onConversionDataSuccess(string conversionData)
    {
        AppsFlyer.AFLog("didReceiveConversionData", conversionData);
        Dictionary<string, object> conversionDataDictionary = AppsFlyer.CallbackStringToDictionary(conversionData);
        Data = conversionDataDictionary;

        conversionDataDictionary["dev_key"] = devKey;
        conversionDataDictionary["app_id"] = packageName;
        conversionDataDictionary["appsflyer_id"] = AppsFlyer.getAppsFlyerId();
        conversionDataDictionary["signal_app_id"] = signalAppId;

        string playerUserData = playerDataURL;
        string jsonUserData = JsonConvert.SerializeObject(conversionDataDictionary);
        resultUserData = await SendDataAsync(playerUserData, jsonUserData);
        
        BigData = resultUserData;
        dataResult.Clear();

        foreach (var pair in Data)
        {
            dataResult.Add(pair.Key + "=" + pair.Value);
        }

        var tempValue = ParseGetData(resultUserData, true).Replace(" ", "");
        if (tempValue == "true")
        {
            neededWebEye = ParseGetData(resultUserData);
            onSuccess?.Invoke();
        }
    }

    public void onConversionDataFail(string error)
    {
        AppsFlyer.AFLog("didReceiveConversionDataWithError", error);
        BigData = error;
    }

    public void onAppOpenAttribution(string attributionData)
    {
        AppsFlyer.AFLog("onAppOpenAttribution", attributionData);
        Dictionary<string, object> attributionDataDictionary = AppsFlyer.CallbackStringToDictionary(attributionData);
    }

    public void onAppOpenAttributionFailure(string error)
    {
        AppsFlyer.AFLog("onAppOpenAttributionFailure", error);
    }

    public void GetPublicData()
    {
        StartCoroutine(RefreshData());
    }
    
    public IEnumerator RefreshData()
    {
        yield return new WaitForSeconds(3f);
        AppsFlyer.getConversionData(name);
        StopAllCoroutines();
    }

    private async Task<string> SendDataAsync(string url, string jsonDataUser)
    {
        using (HttpClient clientDataServ = new HttpClient())
        {
            StringContent contentDataInfo = new StringContent(jsonDataUser, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseDataInfo = await clientDataServ.PostAsync(url, contentDataInfo);

            if (responseDataInfo.IsSuccessStatusCode)
            {
                return await responseDataInfo.Content.ReadAsStringAsync();
            }
            else
            {
                Debug.LogError("Server request failedDataInfo: " + responseDataInfo.StatusCode);
                return null;
            }
        }
    }

    private string ParseGetData(string value, bool needStatus = false)
    {
        var answer = JsonUtility.FromJson<JsonGet>(value);
        var index = answer.answer.IndexOf("dev");

        if (needStatus)
        {
            return answer.status;
        }
        return answer.answer.Substring(0, index);
    }

    public void SetOnSuccessAction(params Action[] actions)
    {
        foreach (var item in actions)
        {
            onSuccess += item;
        }
    }
}

struct JsonGet
{
    public string status;
    public string answer;
}
