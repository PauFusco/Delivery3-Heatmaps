using Gamekit3D;
using Gamekit3D.Message;
using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;

public class PHPConnection : MonoBehaviour, IMessageReceiver
{
    public void OnReceiveMessage(MessageType type, object sender, object msg)
    {
        Damageable senderObj = (Damageable)sender;
        Damageable.DamageMessage dmgmsg = (Damageable.DamageMessage)msg;

        switch (type)
        {
            case MessageType.DAMAGED:
                SendDamaged(senderObj.transform.position, dmgmsg.time, 0);
                break;

            case MessageType.DEAD:

                break;

            case MessageType.RESPAWN:

                break;
        }
    }

    private IEnumerator PHPWebRequest(WWWForm form, string link)
    {
        UnityWebRequest webRequest = UnityWebRequest.Post(link, form);

        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            // php request error handling
            Debug.Log(webRequest.responseCode);
        }
        else
        {
            Debug.Log(webRequest.responseCode);
        }
    }

    public void SendDamaged(Vector3 position, float time, DamagerType type)
    {
        string sendablePositionX = position.x.ToString(CultureInfo.InvariantCulture);
        string sendablePositionY = position.y.ToString(CultureInfo.InvariantCulture);
        string sendablePositionZ = position.z.ToString(CultureInfo.InvariantCulture);
        string sendableTime = time.ToString(CultureInfo.InvariantCulture);
        string sendableType = ((int)type).ToString();

        WWWForm form = new();
        form.AddField("X", sendablePositionX);
        form.AddField("Y", sendablePositionY);
        form.AddField("Z", sendablePositionZ);
        form.AddField("Time", sendableTime);
        form.AddField("Type", sendableType);

        string requestLink = "https://citmalumnes.upc.es/~victormb3/DAMAGED.php";

        StartCoroutine(PHPWebRequest(form, requestLink));
    }

    public void SendDeath(Vector3 position, float time, DamagerType type)
    {
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