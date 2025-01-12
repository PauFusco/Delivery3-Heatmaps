using Gamekit3D;
using Gamekit3D.Message;
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;

public class PHPConnection : MonoBehaviour, IMessageReceiver
{
    public void OnReceiveMessage(MessageType messageType, object sender, object msg)
    {
        Damageable senderObj = (Damageable)sender;
        Damageable.DamageMessage dmgmsg = (Damageable.DamageMessage)msg;

        DamagerType damagedType = DamagerType.UNDEFINED;
        if (senderObj.TryGetComponent<Damager>(out var damager)) { damagedType = damager.type; }

        switch (messageType)
        {
            case MessageType.DAMAGED:
                SendDamaged(damagedType, senderObj.transform.position, dmgmsg.time, dmgmsg.damagerType);
                break;

            case MessageType.DEAD:
                if (damagedType == DamagerType.PLAYER)
                    SendDeath(senderObj.transform.position, dmgmsg.time, dmgmsg.damagerType);
                else
                    SendKill(senderObj.transform.position, dmgmsg.time);

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
            Debug.Log(webRequest.downloadHandler.text);
        }
    }

    private void SendDamaged(DamagerType damagedType, Vector3 position, float time, DamagerType type)
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

        string requestLink = "";

        switch (damagedType)
        {
            case DamagerType.PLAYER:
                requestLink = "https://citmalumnes.upc.es/~victormb3/DAMAGED.php";
                break;

            case DamagerType.SPITTER:
                requestLink = "https://citmalumnes.upc.es/~victormb3/ENEMYDAMAGED.php";
                break;

            case DamagerType.CHOMPER:
                requestLink = "https://citmalumnes.upc.es/~victormb3/ENEMYDAMAGED.php";
                break;
        }

        if (requestLink != "") StartCoroutine(PHPWebRequest(form, requestLink));
    }

    private void SendDeath(Vector3 position, float time, DamagerType type)
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

        string requestLink = "https://citmalumnes.upc.es/~victormb3/DEATH.php";

        StartCoroutine(PHPWebRequest(form, requestLink));
    }

    private void SendKill(Vector3 position, float time)
    {
        string sendablePositionX = position.x.ToString(CultureInfo.InvariantCulture);
        string sendablePositionY = position.y.ToString(CultureInfo.InvariantCulture);
        string sendablePositionZ = position.z.ToString(CultureInfo.InvariantCulture);
        string sendableTime = time.ToString(CultureInfo.InvariantCulture);

        WWWForm form = new();
        form.AddField("X", sendablePositionX);
        form.AddField("Y", sendablePositionY);
        form.AddField("Z", sendablePositionZ);
        form.AddField("Time", sendableTime);

        string requestLink = "https://citmalumnes.upc.es/~victormb3/ENEMYDEFEATED.php";

        StartCoroutine(PHPWebRequest(form, requestLink));
    }

    public void SendPosition(Vector3 position, float time)
    {
        string sendablePositionX = position.x.ToString(CultureInfo.InvariantCulture);
        string sendablePositionY = position.y.ToString(CultureInfo.InvariantCulture);
        string sendablePositionZ = position.z.ToString(CultureInfo.InvariantCulture);
        string sendableTime = time.ToString(CultureInfo.InvariantCulture);

        WWWForm form = new();
        form.AddField("X", sendablePositionX);
        form.AddField("Y", sendablePositionY);
        form.AddField("Z", sendablePositionZ);
        form.AddField("Time", sendableTime);

        string requestLink = "https://citmalumnes.upc.es/~victormb3/POSITION.php";

        StartCoroutine(PHPWebRequest(form, requestLink));
    }

    public void TruncateAll()
    {
        WWWForm form = new();

        string requestLink = "https://citmalumnes.upc.es/~victormb3/TRUNCATEALL.php";

        StartCoroutine(PHPWebRequest(form, requestLink));
    }
}