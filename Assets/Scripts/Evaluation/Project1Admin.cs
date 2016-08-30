using UnityEngine;
using System.Collections;

public class Project1Admin : ProjectAdmin {
	const bool IS_SEALED = true;
	const int COUNT = 3;

	void Start () {
		MessageController.SendMessageToInstance(new QuotaMessage(new SimpleQuota(GetTarget(), COUNT)));
		FactoryController.InitInstancesWithQuotas(new Quota[]{new SimpleQuota(GetTarget(), COUNT)});
	}

	public FactoryObjectDescriptorV1 GetTarget () {
		return new FactoryObjectDescriptorV1(Color.blue, FactoryTagController.FRAGILE, FactoryTagController.PRIORITY, IS_SEALED);
	}
}
