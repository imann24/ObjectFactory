/*
 * Author(s): [Insert Your Name Here], Isaiah Mann
 * Description: The first assignment for CS112-1: Intro to Programming with Unity
 */

using UnityEngine;
using System.Collections;

public class Project1 : ProjectTemplate {
	const float WAIT_TIME = 0.5f;
	const float SPAWN_OFFSET = 10f;

	public GameObject FactoryObjectPrefab;
	public ConveyorBeltController BeltController;

	// Tunable Variables:
	Color color;
	int count;
	string materials;
	string shipping;
	bool isSealed;
	float beltSpeed;

	void SetupFactoryObjects () {
		/*
		 * 
		 * 
		 * 
		 */
		// START HERE:	Replace all code to the right hand sign of the "=" sign (called an "assignment operator") with the correct values

		color = Color.blue;
		count = 3;
		materials = default(string);
		shipping = default(string);
		isSealed = default(bool);
		beltSpeed = 1.0f;

		// END HERE
		/*
		 * 
		 * 
		 * 
		 */
		BeltController.SetBeltSpeed(beltSpeed);
		StartCoroutine(SpawnFactoryObjects());
	}

	IEnumerator SpawnFactoryObjects () {
		yield return new WaitForSeconds(WAIT_TIME);
		for (int i = 0; i < count; i++) {
			FactoryObjectDescriptorV1 descriptor = new FactoryObjectDescriptorV1(color, materials, shipping, isSealed);
			GameObject factoryObject = (GameObject) Instantiate(FactoryObjectPrefab, Vector3.up * SPAWN_OFFSET, Quaternion.identity);
			FactoryObject factoryObjectController = factoryObject.GetComponent<FactoryObject>();
			factoryObjectController.Descriptor = descriptor;
			BeltController.AddToBelt(factoryObjectController);
			yield return new WaitForSeconds(WAIT_TIME);
		}
	}

	// Use this for initialization
	void Start () {
		SetupFactoryObjects();
	}
}
