/*
 * Author(s): Isaiah Mann
 * Description: Handles the displaying and sending messages to display to the player
 */

using UnityEngine;
using System.Collections;

public class MessageController : Controller {
	public static MessageController Instance;
	int firstMessageChildIndex;
	public GameObject MessagePrefab;

	public static bool HasInstance {
		get {
			return Instance != null;
		}
	}

	public static void SendMessageToInstance (Message message) {
		if (HasInstance) {
			Instance.ReceiveMessage(message);
		}
	}

	public void ReceiveMessage (Message message) {
		InitMessagePanel(message);
	}

	protected override void Init () {
		base.Init ();
		Instance = this;
		firstMessageChildIndex = transform.childCount;
	}

	void InitMessagePanel (Message message) {
		GameObject messagePanel = (GameObject) Instantiate(MessagePrefab);
		Transform messageTransform = messagePanel.transform;
		messageTransform.SetParent(transform);
		messageTransform.SetSiblingIndex(firstMessageChildIndex);
		messageTransform.localScale = Vector3.one;
		messageTransform.localPosition = Vector3.zero;
		MessageBehaviour messageBehaviour = messagePanel.GetComponent<MessageBehaviour>();
		messageBehaviour.InitWithMessage(message);
	}
}
