/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class DelegateConditionalQuota : ConditionalQuota {
	public GameObject DelegateConditionObject;

	public override bool CheckSatisfied (params object[] arguments) {
		return DelegateConditionObject.GetComponent<IDelegateConditionalQuota>().CheckSatisfied(arguments);
	}
}
