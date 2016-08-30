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
		this.Shipping = shipping;
		this.IsSealed = isSealed;
	}

	public override bool Equals (object obj) {
		try {
			FactoryObjectDescriptorV1 otherDescriptor = (FactoryObjectDescriptorV1) obj;
			return this.Color == otherDescriptor.Color &&
				this.Materials == otherDescriptor.Materials &&
				this.Shipping == otherDescriptor.Shipping &&
				this.IsSealed == otherDescriptor.IsSealed;
		} 
		catch {
			return false;
		}
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
