/*
 * Author(s): Isaiah Mann
 * Description: Allows a delegate function from any class to be subscribed as sorting rule
 */

using UnityEngine;
using System.Collections;

public class DelegateSortingRule : SortingRule {
	public GameObject DelegateSortingRuleObject;

	protected override void assignActions () {
		IDelegateSortingRule delegateRule = DelegateSortingRuleObject.GetComponent<IDelegateSortingRule>();
		if (delegateRule != null) {
			determineSort = delegateRule.DetermineSortIndex;
			peekSort = delegateRule.PeekSortIndex;
			tickSort = delegateRule.TickSortIndex;
		}
	}
}
