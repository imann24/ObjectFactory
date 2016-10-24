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
		FactoryController.SubscribeRunFactoryAction(spawnFactoryObjects);
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
}
