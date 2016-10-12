/*
 * Author(s): Isaiah Mann
 * Description: Preset messages
 */

public static class MessageUtil {
	
	public const string REQUIREMENTS_FAILED = "Requirements Failed";
	public const string AND = "and";

	const string SEALED = "Sealed";
	const string NOT_SEALED = "Not Sealed";

	const string QUOTA = "Quota";
	const string MET = "MET";
	const string EXPECTED = "Expected";
	const string RECEIVED = "Received";
	const string SATISFIED = "SATISFIED";
	const string FAILED = "FAILED";
	const string REQUIREMENT = "Requirement";

	const string SHIPPING_INSTRUCTIONS = "Shipping Instructions";
	const string SHIP = "Ship";
	const string ON = "On";

	public static Message ZeroBeltSpeedMessage {
		get {
			return new Message(getQuotaFailed(), new string[]{"Belts Not Running", "Conveyor belt speed is set to zero"});
		}
	}

	public static Message InsufficentItemsMessage {
		get {
			return new Message(getQuotaFailed(), new string[]{"Quota count not met"});
		}
	}

	public static Message QuotaMetMessage {
		get {
			return new Message(getQuotaMet(), new string[]{"The factory quota has been meet"});
		}
	}

	public static Message RequirementsFailedMessage {
		get {
			return new Message(REQUIREMENTS_FAILED, new string[]{"The factory has failed the specified requirements"});
		}
	}

	public static Message GetSimpleObjectDefinitionMessage (string definitionName, FactoryObjectDescriptorV1 descriptor) {
		return new Message(definitionName, descriptor.ToStringArr());
	}

	public static Message GetSimpleQuotaMismatchMessage (SimpleQuota correctQuota, SimpleQuota suppliedQuota) {
		FactoryObjectDescriptorV1 expected = correctQuota.IDescriptor;
		FactoryObjectDescriptorV1 received = suppliedQuota.IDescriptor;
		string countMessage = expectedReceivedString(Quota.AMOUNT, correctQuota.ICount, suppliedQuota.ICount);
		string colorMessage = expectedReceivedString(FactoryObject.COLOR_TAG, ColorUtil.ToString(expected.Color), ColorUtil.ToString(received.Color));
		string materialsMessage = expectedReceivedString(FactoryObject.MATERIALS_TAG, expected.Materials, received.Materials);
		string shippingMessage = expectedReceivedString(FactoryObject.SHIPPING_TAG, expected.Shipping, received.Shipping);
		string isSealedMessage = expectedReceivedString(FactoryObject.SEALED_TAG, expected.IsSealed, received.IsSealed);
		string title;
		if (correctQuota.HasQuotaIndex) {
			title = getQuotaFailed(correctQuota.IQuotaIndex);
		} else {
			title = getQuotaFailed();
		}
		return new Message(title, new string[]{countMessage, colorMessage, materialsMessage, shippingMessage, isSealedMessage});
	}

	public static Message GetShippingInstructions (string shipOnAirplane, string shipOnBoat, string shipOnTruck) {
		return new Message(SHIPPING_INSTRUCTIONS, new string[] {
			getShippingLine(shipOnAirplane, ShippingMethod.Plane),
			getShippingLine(shipOnBoat, ShippingMethod.Boat),
			getShippingLine(shipOnTruck, ShippingMethod.Ground)
		});
	}

	static string getShippingLine (string itemToShip, ShippingMethod method) {
		return string.Format("{0} {2} {1} {3}", SHIP, ON, itemToShip, method.ToString());
	}

	static string expectedReceivedString (string key, object expectedValue, object receivedValue) {
		return string.Format("{3} {0}\n- {1}: {4}\n- {2}: {5}\n {6}", key, EXPECTED, RECEIVED, REQUIREMENT, 
			expectedValue, receivedValue, expectedValue.Equals(receivedValue) ? SATISFIED : FAILED);
	}

	static string getQuotaFailed () {
		return getQuotaFailed(string.Empty);
	}

	static string getQuotaFailed (int quotaIndex) {
		return getQuotaFailed(quotaIndex.ToString());
	}

	static string getQuotaFailed (string quotaIndex) {
		return string.Format("{0} {1} {2}", QUOTA, quotaIndex, FAILED);
	}

	static string getQuotaMet () {
		return getQuotaMet(string.Empty);
	}

	static string getQuotaMet (int quotaIndex) {
		return getQuotaMet(quotaIndex.ToString());
	}

	static string getQuotaMet (string quotaIndex) {
		return string.Format("{0} {1} {2}", QUOTA, quotaIndex, MET);
	}
}
