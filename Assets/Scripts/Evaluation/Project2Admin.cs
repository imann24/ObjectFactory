/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class Project2Admin : ProjectAdmin {
	const int SPAWN_COUNT = 10;
	const float SPAWN_DELAY = 0.5f;

	void Start () {
		FactoryController.SubscribeRunFactoryAction(spawnFactoryObjects);
		MessageController.SendMessageToInstance(MessageUtil.GetShippingInstructions(
			ColorUtil.ToString(Color.red),
			string.Format("{1} {0} {2}", MessageUtil.AND, ColorUtil.ToString(Color.blue), ColorUtil.ToString(Color.yellow)),
			"Other Colors"));
		FactoryController.InitInstancesWithQuotas(new Quota[]{new CountQuota(SPAWN_COUNT)});
	}

	void spawnFactoryObjects () {
		FactoryObjectDescriptorV1[] descriptors = new FactoryObjectDescriptorV1[SPAWN_COUNT];
		bool[] isSealedPossibilities = new bool[]{true, false};
		for (int i = 0; i < SPAWN_COUNT; i++) {
			descriptors[i] = new FactoryObjectDescriptorV1(
				ColorUtil.RandomColor(), 
				FactoryTagController.RandomMaterialsTag(),
				FactoryTagController.RandomShippingTag(),
				ArrayUtil.Random(isSealedPossibilities));
		}
		FactoryController.AddToBeltByDescriptor(0, descriptors, SPAWN_DELAY);
	}
}
