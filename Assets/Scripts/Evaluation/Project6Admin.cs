/*
 * Author(s): Isaiah Mann
 * Description: Runs the controlling logic for Project 6: Designing Objects
 */

using System;
using System.Linq;
using System.Collections.Generic;

public class Project6Admin : ProjectAdmin {
	int countPerType = 5;
	int beltCount = 2;
	float spawnDelay = 0.5f;

	void Start () {
		FactoryController.SetConveyorBeltSpeeds(2.5f);
		FactoryController.SubscribeRunFactoryAction(spawnFactoryObjects);
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
