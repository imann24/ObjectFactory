/*
 * Author(s): Isaiah Mann
 * Description: Admin scripts to control Project 5
 */

using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

public class Project5Admin : ProjectAdmin {
	int countPerType = 10;
	int beltCount = 3;
	float spawnDelay = 0.5f;
	void Start () {
		setupQuotas();
		FactoryController.SubscribeRunFactoryAction(spawnFactoryObjects);
		FactoryController.SubscribeRunFactoryAction(setBeltSpeed);
	}


	void setupQuotas () {
		// Set the three required packages
		PackageQuota[] quotas = new PackageQuota[beltCount];

		quotas[0] = new PackageQuota(
			new string[]{redBoxKey},
			new SimpleQuota[]{new SimpleQuota(redBox, countPerType)});
		quotas[1] = new PackageQuota(
			new string[]{greenBoxKey},
			new SimpleQuota[]{new SimpleQuota(greenBox, countPerType)});
		quotas[2] = new PackageQuota(
			new string[]{blueBoxKey},
			new SimpleQuota[]{new SimpleQuota(blueBox, countPerType)});

		FactoryController.InitInstancesWithQuotas(quotas);
		// Send message to UI about package requirements
		if (MessageController.Instance) {
			string packageKey = "Package";
			string[] packagePositions = {"Top", "Middle", "Bottom"};
			int index = 0;
			foreach (Quota quota in quotas) {
				MessageController.Instance.ReceiveMessage(new QuotaMessage(string.Format("{0} {1}", packagePositions[index], packageKey), quota));
				index++;
			}
		}
	}

	void spawnFactoryObjects () {
		List<FactoryObjectDescriptorV1> descriptors = new List<FactoryObjectDescriptorV1>();
		FactoryObjectDescriptorV1[] boxTypes = new FactoryObjectDescriptorV1[]{blackBox, redBox, greenBox, blueBox};
		foreach (FactoryObjectDescriptorV1 descriptorType in boxTypes) {
			for (int i = 0; i < countPerType; i++) {
				descriptors.Add(descriptorType);
			}
		}
		// Randomization code: http://stackoverflow.com/questions/19201489/correctly-using-linq-to-shuffle-a-deck
		descriptors = descriptors.OrderBy(sort => Guid.NewGuid()).ToList();
		AdvancedFactoryController.AddToBeltByDescriptor(0, descriptors.ToArray(), spawnDelay, 0, beltCount);
	}

	void setBeltSpeed () {
		FactoryController.SetConveyorBeltSpeeds(2.0f);
	}

}
