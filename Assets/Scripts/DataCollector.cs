using Gamekit3D;
using Gamekit3D.Message;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCollector : MonoBehaviour, IMessageReceiver
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnReceiveMessage(MessageType type, object sender, object msg)
	{
		switch (type)
		{
			case MessageType.DEAD:
				//Death((Damageable.DamageMessage)msg);
				break;
			case MessageType.DAMAGED:
				//ApplyDamage((Damageable.DamageMessage)msg);
				break;
			case MessageType.RESPAWN:
				//OnRespawnReceived();
				break;
			default:
				break;
		}
	}

}
