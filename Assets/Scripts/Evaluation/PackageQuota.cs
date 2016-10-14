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
	public PackageQuota (string[] quotaTypes, SimpleQuota[] contents, int quotaIndex) : base(quotaIndex) {
		setup(quotaTypes, contents);	
	}

	// Each contained SimpleQuota represents one kind of package
	public PackageQuota (string[] quotaTypes, SimpleQuota[] contents) {
		setup(quotaTypes, contents);
	}

	void setup (string[] quotaTypes, SimpleQuota[] contents) {
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
		bool quotasAreSatisfied = true;
		for (int i = 0; i < contents.Length; i++) {
			bool isSatisfied = false;
			foreach (FactoryObjectDescriptorV1 descriptor in counts.Keys) {
//				UnityEngine.Debug.LogFormat("Comparing {0} \n\n to \n\n {1} \n\n and it's a match{2}", contents[i], descriptor, contents[i].CheckSatisfied(descriptor, counts[descriptor]));
				isSatisfied |= contents[i].CheckSatisfied(descriptor, counts[descriptor]);
			}
			quotasAreSatisfied &= isSatisfied;
		}
		return quotasAreSatisfied;
	}

	public override int CheckSimilarities (params object[] arguments) {
		if (arguments[0] is FactoryPackageDescriptorV1) {
			FactoryPackageDescriptorV1 descriptor = arguments[0] as FactoryPackageDescriptorV1;
			List<FactoryObjectDescriptor> difference = new List<FactoryObjectDescriptor>();
			difference.AddRange(descriptor.Contents);
			foreach (SimpleQuota quota in contents) {
				for (int i = 0; i < quota.ICount; i++) {
					if (difference.Contains(quota.IDescriptor)) {	
						difference.Remove(quota.IDescriptor);
					} else {
						continue;
					}
				}
			}
			return descriptor.Contents.Length - difference.Count;
		} else {
			return base.CheckSimilarities (arguments);
		}
	}

	public override string ToString () {
		string quotaCounts = string.Empty;
		for (int i = 0; i < quotaTypes.Length; i++) {
			quotaCounts += string.Format("{0} ({1}x){2}", quotaTypes[i], contents[i].ICount, Quota.ITEM_DIVIDER_CHAR); 
		}
		return quotaCounts;
	}

	public override bool Equals (object obj) {
		if (obj is PackageQuota) {
			PackageQuota otherQuota = obj as PackageQuota;
			List<SimpleQuota> difference = new List<SimpleQuota>();
			difference.AddRange(otherQuota.contents);
			foreach (SimpleQuota quota in contents) {
				if (difference.Contains(quota)) {
					difference.Remove(quota);
				}
			}
			return difference.Count == 0;
		} else {
			return base.Equals (obj);
		}
	}

	public override int GetHashCode () {
		int hashCode = 0;
		foreach (SimpleQuota quota in contents) {
			hashCode += quota.GetHashCode();
		}
		return hashCode;
	}
}
