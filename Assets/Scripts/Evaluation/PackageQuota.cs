/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using System.Collections.Generic;

public class PackageQuota  : Quota {
	SimpleQuota[] contents;

	// Each contained SimpleQuota represents one kind of package
	public PackageQuota (SimpleQuota[] contents) {
		this.contents = contents;
	}

	// The arguments should be an array of descriptors representing the contained objects in the package
	public override bool CheckSatisfied (params object[] arguments) {
		Dictionary<FactoryObjectDescriptorV1, int> counts = new Dictionary<FactoryObjectDescriptorV1, int>();
		foreach (FactoryObjectDescriptorV1 descriptor in arguments) {
			if (counts.ContainsKey(descriptor)) {
				counts[descriptor]++;
			} else {
				counts.Add(descriptor, 1);
			}
		}
		bool quotasAreSatisfied = false;
		for (int i = 0; i < contents.Length; i++) {
			bool isSatisfied = false;
			foreach (FactoryObjectDescriptorV1 descriptor in counts.Keys) {
				isSatisfied |= contents[i].CheckSatisfied(descriptor, counts[descriptor]);
			}
			quotasAreSatisfied &= isSatisfied;
		}
		return quotasAreSatisfied;
	}
}
