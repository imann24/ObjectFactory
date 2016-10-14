/*
 * Author(s): Isaiah Mann
 * Description: Admin setup for Project4
 */

using System.Collections.Generic;
using UnityEngine;

public class Project4Admin : ProjectAdmin {
	int quotaCount = 3;

	void Start () {
		// Set the definitions of the kinds of boxes
		string redBox = "Red Box";
		string greenBox = "Green Box";
		string blueBox = "Blue Box";
		string[] boxNames = new string[]{redBox, greenBox, blueBox};
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
		PackageQuota[] quotas = new PackageQuota[quotaCount];

		quotas[0] = new PackageQuota(
			boxNames,
			new SimpleQuota[]{
			new SimpleQuota(objectDefinitions[redBox], 2), 
			new SimpleQuota(objectDefinitions[greenBox], 1), 
			new SimpleQuota(objectDefinitions[blueBox], 3)}, 1);

		quotas[1] = new PackageQuota(
			boxNames,
			new SimpleQuota[]{
			new SimpleQuota(objectDefinitions[redBox], 4), 
			new SimpleQuota(objectDefinitions[greenBox], 2), 
			new SimpleQuota(objectDefinitions[blueBox], 1)}, 2);

		quotas[2] = new PackageQuota(
			boxNames,
			new SimpleQuota[]{new SimpleQuota(objectDefinitions[redBox], 1), 
			new SimpleQuota(objectDefinitions[greenBox], 3), 
			new SimpleQuota(objectDefinitions[blueBox], 2)}, 3);

		FactoryController.InitInstancesWithQuotas(quotas);

		// Send message to UI about package requirements
		if (MessageController.Instance) {
			string packageKey = "Package";
			int index = 1;
			foreach (Quota quota in quotas) {
				MessageController.Instance.ReceiveMessage(new QuotaMessage(string.Format("{0} {1}", packageKey, index++), quota));
			}
		}
	}
		
}
