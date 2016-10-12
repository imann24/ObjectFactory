/*
 * Author(s): Isaiah Mann
 * Description: Admin setup for Project4
 */

using System.Collections.Generic;
using UnityEngine;

public class Project4Admin : ProjectAdmin {

	void Start () {
		// Set the definitions of the kinds of boxes
		string redBox = "Red Box";
		string greenBox = "Green Box";
		string blueBox = "Blue Box";
		Dictionary<string, FactoryObjectDescriptorV1> objectDefinitions = new Dictionary<string, FactoryObjectDescriptorV1>() {
			{redBox, new FactoryObjectDescriptorV1(Color.red, "Fragile", "Priority", true)},
			{greenBox, new FactoryObjectDescriptorV1(Color.green, "Heavy", "Economy", false)},
			{blueBox, new FactoryObjectDescriptorV1(Color.blue, "Hazardous", "International", true)}};

		if (MessageController.Instance) {
			// Send message to UI about box types
			foreach (string boxName in objectDefinitions.Keys) {
				MessageController.Instance.ReceiveMessage(MessageUtil.GetSimpleObjectDefinitionMessage(boxName, objectDefinitions[boxName]));
			}
		}

		// Set the three required packages

		// Quota[] packageQuotas = new 

		// Send message to UI about package requirements



	}

}
