/*
 * Author(s): Isaiah Mann
 * Description: Describes the requirements for a simple factory's production
 */

public class SimpleQuota : Quota {
	FactoryObjectDescriptorV1 descriptor;
	int count;

	public SimpleQuota (FactoryObjectDescriptorV1 descriptor, int count) {
		this.descriptor = descriptor;
		this.count = count;
	}

	public override bool CheckSatisfied (object[] arguments) {
		try {
			FactoryObjectDescriptorV1 argumentDescriptor = (FactoryObjectDescriptorV1) arguments[0];
			int argumentCount = (int) arguments[1];
			return descriptor.Equals(argumentDescriptor) && count == argumentCount;
		} 
		catch {
			return false;
		}
	}

	public override string ToString () {
		return string.Format("Amount: {2}{1}{0}", descriptor.ToString(), ITEM_DIVIDER_CHAR, count);
	}
}
