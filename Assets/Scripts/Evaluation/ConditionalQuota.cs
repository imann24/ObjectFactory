/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public abstract class ConditionalQuota : Quota {
	public delegate bool CheckCondition (params object [] arguments);
}
