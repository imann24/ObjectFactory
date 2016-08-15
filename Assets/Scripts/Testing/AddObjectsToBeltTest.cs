/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class AddObjectsToBeltTest : MonoBehaviour {
	public FactoryObject[] FObjects;
	public ConveyorBelt Belt;
	public float Delay = 0.5f;
	// Use this for initialization
	void Start () {
		StartCoroutine(AddToBeltWithDelay(Delay));
	}

	IEnumerator AddToBeltWithDelay (float delay) {
		yield return new WaitForSeconds(delay);
		for (int i = 0; i < FObjects.Length; i++) {
			Belt.AddObjectToBelt(FObjects[i]);
			yield return new WaitForSeconds(delay);
		}
	}
}
