/*
 * Author(s): Isaiah Mann
 * Description: Hides this object in editor
 */

using UnityEngine;
using System.Collections;

public class ProjectAdmin : MonoBehaviour {
	protected string grayBoxKey = "Gray Box";
	protected string blackBoxKey = "Black Box";
	protected string redBoxKey = "Red Box";
	protected string greenBoxKey = "Green Box";
	protected string blueBoxKey = "Blue Box";

	protected FactoryObjectDescriptorV1 blackBox = new FactoryObjectDescriptorV1(Color.black, "None", "None", false);
	protected FactoryObjectDescriptorV1 grayBox = new FactoryObjectDescriptorV1(Color.gray, "None", "None", false);
	protected FactoryObjectDescriptorV1 redBox = new FactoryObjectDescriptorV1(Color.red, "Fragile", "Priority", true);
	protected FactoryObjectDescriptorV1 greenBox = new FactoryObjectDescriptorV1(Color.green, "Heavy", "Economy", false);
	protected FactoryObjectDescriptorV1 blueBox = new FactoryObjectDescriptorV1(Color.blue, "Hazardous", "International", true);

	public void HideInInspector () {
		gameObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.NotEditable | HideFlags.HideInInspector;
	}
}
