using Gamekit3D;
using Gamekit3D.Message;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PHPConnection : MonoBehaviour, IMessageReceiver
{
    public void OnReceiveMessage(MessageType type, object sender, object msg)
    {
        GameObject senderObj = sender as GameObject;
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

    public void SendDamaged(Vector3 position, float time, DamagerType type)
    {
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