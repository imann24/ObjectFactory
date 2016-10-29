/*
 * Author(s): Isaiah Mann
 * Description: Runs the controlling logic for Project 6: Designing Objects
 */

using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

public class Project6Admin : ProjectAdmin {
	int countPerType = 5;
	int beltCount = 2;
	float spawnDelay = 0.5f;
	int ZONE_QUOTA = 7;

	void Start () {
		FactoryController.SetConveyorBeltSpeeds(2.5f);
		FactoryController.SubscribeRunFactoryAction(spawnFactoryObjects);
		FactoryController.SetAllColorRequirements(
			new Color[]{Color.Lerp(Color.red, Color.blue, 0.5f), Color.Lerp(Color.yellow, Color.red, 0.5f), Color.green},
			new Color[]{Color.red, Color.yellow, Color.blue});
			MessageController.SendMessageToInstance(new Message("Combine Colors", new string[]{"Combine primary colors to create the secondary colors they produce"}));
		MessageController.SendMessageToInstance(new Message("Factory Requirement", new string[]{"Only secondary colors should be placed in the drop zone"}));
		FactoryController.InitInstancesWithQuotas(new Quota[]{new CountQuota(ZONE_QUOTA)});
	}

	void spawnFactoryObjects () {
		List<CombinableFactoryObjectDescriptor> descriptors = new List<CombinableFactoryObjectDescriptor>();
		CombinableFactoryObjectDescriptor[] boxTypes = new CombinableFactoryObjectDescriptor[]{combinableBlueBox, combinableYellowBox, combinableRedBox};
		foreach (CombinableFactoryObjectDescriptor descriptorType in boxTypes) {
			for (int i = 0; i < countPerType; i++) {
				descriptors.Add(descriptorType);
			}
		}
		// Randomization code: http://stackoverflow.com/questions/19201489/correctly-using-linq-to-shuffle-a-deck
		descriptors = descriptors.OrderBy(sort => Guid.NewGuid()).ToList();
		CombinationFactoryController.AddToBeltByDescriptor(0, descriptors.ToArray(), spawnDelay, 0, beltCount);
	}
}
