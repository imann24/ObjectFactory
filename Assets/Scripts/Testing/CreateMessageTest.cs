/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class CreateMessageTest : MonoBehaviour {
	public MessageController controller;

	// Use this for initialization
	void Start () {
		AddMessageToControlelr(CreateSimpleMessage());
	}

	Message CreateSimpleMessage () {
		return new Message("Foo", new string[]{"Hello World", "Banjo Kazooie", "Banjo Kazooie", "Banjo Kazooie", "Banjo Kazooie", "Banjo Kazooie", "Banjo Kazooie", "Banjo Kazooie", "Banjo Kazooie", "Banjo Kazooie", "Banjo Kazooie", "Banjo Kazooie", "Banjo Kazooie", "Banjo Kazooie", "Banjo Kazooie", "Banjo Kazooie", "Banjo Kazooie", "Banjo Kazooie", "Banjo Kazooie"});
	}

	void AddMessageToControlelr (Message message) {
		controller.ReceiveMessage(message);
	}
}
