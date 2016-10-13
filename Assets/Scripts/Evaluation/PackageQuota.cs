/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using System.Collections.Generic;

public class PackageQuota : Quota {
	string[] quotaTypes;
	SimpleQuota[] contents;

	public string[] IQuotaTypes {
		get {
			return quotaTypes;
		}
	}
	public SimpleQuota[] IContainedQuotas {
		get {
			return contents;
		}
	}

	// Each contained SimpleQuota represents one kind of package
	public PackageQuota (string[] quotaTypes, SimpleQuota[] contents) {
		this.contents = contents;
		this.quotaTypes = quotaTypes;
	}

	public PackageQuota (SimpleQuota[] contents) {
		this.contents = contents;
		this.quotaTypes = new string[0];
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

	public override int CheckSimilarities (params object[] arguments) {
		return base.CheckSimilarities (arguments);
	}

	public override string ToString () {
		string quotaCounts = string.Empty;
		for (int i = 0; i < quotaTypes.Length; i++) {
			quotaCounts += string.Format("{0} ({1}x){2}", quotaTypes[i], contents[i].ICount, Quota.ITEM_DIVIDER_CHAR); 
		}
		return quotaCounts;
	}
}
