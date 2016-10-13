/*
 * Author(s): Isaiah Mann
 * Description: Describes a factory package
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FactoryPackageDescriptorV1 : FactoryObjectDescriptor {
	public const string TYPE = "PackageV1";
	public FactoryObjectDescriptor[] Contents;

	public FactoryPackageDescriptorV1 (FactoryObjectDescriptor[] contents) : base (TYPE) {
		this.Contents = contents;
	}

	public override int CheckSimilarities (FactoryObjectDescriptor descriptor) {
		if (descriptor is FactoryPackageDescriptorV1) {
			FactoryPackageDescriptorV1 otherDescriptor = descriptor as FactoryPackageDescriptorV1;
			int similarities = 0;
			List<FactoryObjectDescriptor> contentsList = new List<FactoryObjectDescriptor>(Contents);
			foreach (FactoryObjectDescriptor containedObject in otherDescriptor.Contents) {
				if (contentsList.Contains(containedObject)) {
					similarities++;
				}
			}
			return similarities;
		} else {
			return base.CheckSimilarities (descriptor);
		}
	}

	public SimpleQuota[] GetContentsAsQuotas () {
		Dictionary<FactoryObjectDescriptorV1, int> containedObjects = new Dictionary<FactoryObjectDescriptorV1, int>();
		foreach (FactoryObjectDescriptorV1 descriptor in Contents) {
			if (containedObjects.ContainsKey(descriptor)) {
				containedObjects[descriptor]++;
			} else {
				containedObjects.Add(descriptor, 1);
			}
		}
		SimpleQuota[] quotas = new SimpleQuota[containedObjects.Count];
		int index = 0;
		foreach (FactoryObjectDescriptorV1 descriptor in containedObjects.Keys) {
			quotas[index++] = new SimpleQuota(descriptor, containedObjects[descriptor]);
		}
		return quotas;
	}
}
