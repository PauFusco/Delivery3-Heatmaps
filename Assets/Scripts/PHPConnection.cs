using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PHPConnection : MonoBehaviour
{
    private void OnEnable()
    {
    }

    private IEnumerator PHPWebRequest(WWWForm form, string link, Action<uint> callback)
    {
        UnityWebRequest webRequest = UnityWebRequest.Post(link, form);

        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success)
        {
        }
        else
        {
            uint callbackData = uint.Parse(webRequest.downloadHandler.text);
            callback?.Invoke(callbackData);
        }
    }

    private void SendDeath()
    {
        // death id
        // time (float Time.time)
        // position
        // reason of death
    }

    private void SendKill()
    {
        // kill id
        // time (float Time.time)
        // position
        // killed enemy
    }
}