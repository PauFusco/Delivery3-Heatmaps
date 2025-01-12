using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class PHPReader : MonoBehaviour
{
    public void ReadAll()
    {
        ReadHits();
        ReadDeaths();
        ReadPositions();
        ReadAttacks();
        ReadDefeats();
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

    private void ReadHits()
    {
        string requestLink = "https://citmalumnes.upc.es/~victormb3/HITSREADER.php";

        string filePath = Application.dataPath + "/JSONResponse/hits.json";
        StartCoroutine(PHPWebRequest(requestLink, filePath));
    }

    private void ReadDeaths()
    {
        string requestLink = "https://citmalumnes.upc.es/~victormb3/DEATHSREADER.php";

        string filePath = Application.dataPath + "/JSONResponse/deaths.json";
        StartCoroutine(PHPWebRequest(requestLink, filePath));
    }

    private void ReadPositions()
    {
        string requestLink = "https://citmalumnes.upc.es/~victormb3/POSITIONSREADER.php";

        string filePath = Application.dataPath + "/JSONResponse/positions.json";
        StartCoroutine(PHPWebRequest(requestLink, filePath));
    }

    private void ReadAttacks()
    {
        string requestLink = "https://citmalumnes.upc.es/~victormb3/ATTACKSREADER.php";

        string filePath = Application.dataPath + "/JSONResponse/attacks.json";
        StartCoroutine(PHPWebRequest(requestLink, filePath));
    }

    private void ReadDefeats()
    {
        string requestLink = "https://citmalumnes.upc.es/~victormb3/DEFEATSREADER.php";

        string filePath = Application.dataPath + "/JSONResponse/defeats.json";
        StartCoroutine(PHPWebRequest(requestLink, filePath));
    }
}