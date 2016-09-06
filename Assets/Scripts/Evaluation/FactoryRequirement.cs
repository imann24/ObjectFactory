/*
 * Author(s): Isaiah Mann
 * Description: Describes a factory requirement
 */

using UnityEngine;
using System.Collections;

public class FactoryRequirement : MonoBehaviour {
	public virtual bool CheckSatisifed () {
		// OVERRIDE in subclasses
		return false;
	}
}
