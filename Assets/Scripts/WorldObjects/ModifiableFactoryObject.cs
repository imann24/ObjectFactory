/*
 * Author(s): Isaiah Mann
 * Description: Describes a factory object that can be modified
 */

public class ModifiableFactoryObject : FactoryObject {
	public virtual void Modify (ModifiableFactoryObject factoryObject) {
		UnityEngine.Debug.Log("Override the modify method in the subclasses");
	}
}
