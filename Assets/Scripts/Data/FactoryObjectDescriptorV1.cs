/*
 * Author(s): Isaiah Mann
 * Description: Simple way to describe a factory object
 */

public class FactoryObjectDescriptorV1 : FactoryObjectDescriptor {
	public const string TYPE = "V1";

	public UnityEngine.Color Color;
	public string Materials;
	public string Shipping;
	public bool IsSealed;

	public FactoryObjectDescriptorV1 (UnityEngine.Color color, string materials, string shipping, bool isSealed) : base (TYPE) {
		this.Color = color;
		this.Materials = materials;
		if (this.Materials == null) {
			this.Materials = string.Empty;
		}
		this.Shipping = shipping;
		if (this.Shipping == null) {
			this.Shipping = string.Empty;
		}
		this.IsSealed = isSealed;
	}

	public override bool Equals (object obj) {
		try {
			FactoryObjectDescriptorV1 otherDescriptor = (FactoryObjectDescriptorV1) obj;
			return this.Color == otherDescriptor.Color &&
				this.Materials.ToLower() == otherDescriptor.Materials.ToLower() &&
				this.Shipping.ToLower() == otherDescriptor.Shipping.ToLower() &&
				this.IsSealed == otherDescriptor.IsSealed;
		} 
		catch {
			return false;
		}
	}

	public int CheckSimilariaties (FactoryObjectDescriptorV1 otherDescriptor) {
		int similaritities = this.Color == otherDescriptor.Color ? 1 : 0;
		similaritities += this.Materials == otherDescriptor.Materials ? 1 : 0;
		similaritities += this.Shipping == otherDescriptor.Shipping ? 1 : 0;
		similaritities += this.IsSealed == otherDescriptor.IsSealed ? 1 : 0;
		return similaritities;
	}

	public override int GetHashCode () {
		int hashCode = this.Color.GetHashCode() + this.IsSealed.GetHashCode();
		if (this.Materials != null) {
			hashCode += this.Materials.GetHashCode();
		}
		if (this.Shipping != null) {
			hashCode += this.Shipping.GetHashCode();
		}
		return hashCode;
	}

	public override string ToString () {
		return string.Format ("{1}: {2}{0}{3}: {4}{0}{5}: {6}{0}{7}: {8}",
			SimpleQuota.ITEM_DIVIDER_CHAR,
			FactoryObject.COLOR_TAG, ColorUtil.ToString(Color),
			FactoryObject.MATERIALS_TAG, Materials,
			FactoryObject.SHIPPING_TAG, Shipping,
			FactoryObject.SEALED_TAG, IsSealed);
	}
}
