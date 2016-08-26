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
		return base.GetHashCode ();
	}
}
