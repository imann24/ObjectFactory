/*
 * Author(s): Isaiah Mann
 * Description: Describes a factory object that can be combined with another object 
 */

public class CombinableFactoryObject : ModifiableFactoryObject, IFactoryObjectModifier {
	public override void Modify (ModifiableFactoryObject factoryObject) {
		if (factoryObject is CombinableFactoryObject) {
			Combine(factoryObject as CombinableFactoryObject);
		} else {
			base.Modify (factoryObject);
		}
	}

	public FactoryObject Combine (CombinableFactoryObject factoryObject) {
		// TODO: Implement the logic for combining two objects
		return this;
	}

	// Determines which combination the two objects produce
	FactoryObject getCombination (CombinableFactoryObject combineWith) {
		return CombinationController.Instance.GetCombination(this, combineWith);
	}

	public virtual bool CanCombineWith (CombinableFactoryObject factoryObject) {
		// TODO Implement the logic for whether this object is compatible with other objects
		return false;
	}

	// Overloaded method to check a list of objects instead of a single object
	// Read more about overloading here: http://csharpindepth.com/Articles/General/Overloading.aspx
	public virtual bool CanCombineWith (params CombinableFactoryObject[] factoryObjects) {
		bool canCombine = true;
		foreach (CombinableFactoryObject factoryObject in factoryObjects) {
			canCombine &= CanCombineWith(factoryObject);
		}
		return canCombine;
	}
}
