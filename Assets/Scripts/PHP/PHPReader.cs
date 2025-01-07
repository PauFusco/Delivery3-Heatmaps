using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class PHPReader : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ReadHits();
        }
    }

    private IEnumerator PHPWebRequest(string link, string fileToWritePath)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(link);

        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            // php request error handling
            Debug.Log(webRequest.downloadHandler.text);
        }
        else
        {
            File.WriteAllText(fileToWritePath, webRequest.downloadHandler.text);
        }
    }

    public void ReadHits()
    {
        string requestLink = "https://citmalumnes.upc.es/~victormb3/HITSREADER.php";

        string filePath = Application.dataPath + "/JSONResponse/hits.json";
        StartCoroutine(PHPWebRequest(requestLink, filePath));
    }
}