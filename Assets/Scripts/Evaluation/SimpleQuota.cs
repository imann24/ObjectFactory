/*
 * Author(s): Isaiah Mann
 * Description: Describes the requirements for a simple factory's production
 */

public class SimpleQuota : Quota {
	FactoryObjectDescriptorV1 descriptor;
	int count;
	public FactoryObjectDescriptorV1 IDescriptor {
		get {
			return descriptor;
		}
	}
	public int ICount {
		get {
			return count;
		}
	}
	public SimpleQuota (FactoryObjectDescriptorV1 descriptor, int count, int quotaIndex) : base (quotaIndex) {
		setup(descriptor, count);
	}

	public SimpleQuota (FactoryObjectDescriptorV1 descriptor, int count) {
		setup(descriptor, count);
	}

	void setup (FactoryObjectDescriptorV1 descriptor, int count) {
		this.descriptor = descriptor;
		this.count = count;
	}

	public override bool CheckSatisfied (params object[] arguments) {
		try {
			FactoryObjectDescriptorV1 argumentDescriptor = (FactoryObjectDescriptorV1) arguments[0];
			int argumentCount = (int) arguments[1];
			return descriptor.Equals(argumentDescriptor) && count == argumentCount;
		} 
		catch {
			return false;
		}
	}

	public override int CheckSimilarities (params object[] arguments) {
		try {
			FactoryObjectDescriptorV1 argumentDescriptor = (FactoryObjectDescriptorV1) arguments[0];
			return descriptor.CheckSimilarities(argumentDescriptor);
		}
		catch {
			return 0;
		}
	}

	public override string ToString () {
		return string.Format("{3}: {2}{1}{0}", descriptor.ToString(), ITEM_DIVIDER_CHAR, count, AMOUNT);
	}

	public bool SameDescriptor (SimpleQuota quota) {
		return quota.descriptor.Equals(descriptor);
	}
	public override bool Equals (object obj) {
		if (obj is SimpleQuota) {
			SimpleQuota otherQuota = obj as SimpleQuota;
			return SameDescriptor(otherQuota) && otherQuota.count == count;
		} else {
			return false;
		}
	}
		
	public override int GetHashCode () {
		return descriptor.GetHashCode() + count.GetHashCode();
	}
}
