/*
 * Author(s): Isaiah Mann
 * Description: Controls a factory
 */

using UnityEngine;
using System.Collections;

public class FactoryController : Controller {
	Quota[] quotas;

	public void InitWithQuotas (Quota[] quotas) {
		this.quotas = quotas;
	}

	public bool HasQuotas () {
		return this.quotas != null;
	}

	public bool AreQuotasSatisfied (object[] arguments) {
		bool areQuotasSatisfied = true;
		foreach (Quota quota in quotas) {
			if (!quota.CheckSatisfied(arguments)) {
				areQuotasSatisfied = false;
			}
		}
		return areQuotasSatisfied;
	}
}
