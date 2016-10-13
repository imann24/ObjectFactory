/*
 * Author(s): Isaiah Mann
 * Description: Used to describe a factory object
 */

public class FactoryObjectDescriptor : Descriptor {
	public string Type;

	public FactoryObjectDescriptor (string type) {
		this.Type = type;
	}

	// Override in subclasses
	public virtual int CheckSimilarities (FactoryObjectDescriptor descriptor) {
		return 0;
	}
}
