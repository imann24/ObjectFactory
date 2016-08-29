/*
 * Author(s): Isaiah Mann
 * Description: Controls a factory
 */

using UnityEngine;
using System.Collections;

public class FactoryController : Controller {
	public bool ShouldStartActive;

	static FactoryController Instance;

	public delegate void FactoryAction();
	FactoryAction onRun;
	public ConveyorBeltController[] ConveyorBelts;
	Quota[] quotas;

	void Awake () {
		Instance = this;
		if (!ShouldStartActive) {
			SetConveyorBeltSpeeds(0);		
		}
	}

	void OnDestroy () {
		onRun = null;
	}

	public static void SubscribeRunFactoryAction (FactoryAction onRunAction) { 
		if (Instance) {
			Instance.onRun += onRunAction;
		}
	}

	public static void SetConveyorBeltSpeeds (float beltSpeed) {
		if (Instance) {
			foreach (ConveyorBeltController beltController in Instance.ConveyorBelts) {
				beltController.SetBeltSpeed(beltSpeed);
			}
		}
	}

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

	public bool BeltsMoving () {
		bool anyBeltMoving = false;
		foreach (ConveyorBeltController beltController in ConveyorBelts) {
			anyBeltMoving |= beltController.BeltsMoving();
		}
		return anyBeltMoving;
	}

	public void RunFactory () {
		CallOnRun();
		if (!BeltsMoving()) {
			MessageController.SendMessageToInstance(MessageUtil.ZeroBeltSpeedMessage);
		}
	}
		
	void CallOnRun () {
		if (onRun != null) {
			onRun();
		}
	}
}
