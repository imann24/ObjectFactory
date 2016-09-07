/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class Project3Admin : ProjectAdmin {
	static int[] QUOTA_COUNTS = new int[]{5, 10, 7};

	void Start () {	
		int quotaIndex = 1;
		int zeroIndexed = 1;
		Quota[] factoryQuotas = new Quota[] {
			new SimpleQuota(new FactoryObjectDescriptorV1(Color.red, FactoryTagController.PRIORITY, FactoryTagController.FRAGILE, true),
				QUOTA_COUNTS[quotaIndex-zeroIndexed],
				quotaIndex++),
			new SimpleQuota(new FactoryObjectDescriptorV1(Color.blue, FactoryTagController.INTERNATIONAL, FactoryTagController.HEAVY, false),
				QUOTA_COUNTS[quotaIndex-zeroIndexed],
				quotaIndex++),
			new SimpleQuota(new FactoryObjectDescriptorV1(Color.green, FactoryTagController.ECONOMY, FactoryTagController.HAZARDOUS, true),
				QUOTA_COUNTS[quotaIndex-zeroIndexed],
				quotaIndex)
		};
		quotaIndex = 1;
		MessageController.SendMessageToInstance(new QuotaMessage(
			factoryQuotas[quotaIndex - zeroIndexed],
			quotaIndex++));
		MessageController.SendMessageToInstance(new QuotaMessage(
			factoryQuotas[quotaIndex - zeroIndexed],
			quotaIndex++));
		MessageController.SendMessageToInstance(new QuotaMessage(
			factoryQuotas[quotaIndex - zeroIndexed],
			quotaIndex));	
		FactoryController.InitInstancesWithQuotas(factoryQuotas);
	}
}
