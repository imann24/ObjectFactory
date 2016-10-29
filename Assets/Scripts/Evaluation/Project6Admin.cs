/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class Project6Admin : ProjectAdmin {
	void Start () {
		FactoryController.SetConveyorBeltSpeeds(5.0f);
	}
}
