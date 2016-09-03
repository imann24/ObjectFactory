/*
 * Author(s): Isaiah Mann
 * Description: Preset messages
 */

public static class MessageUtil {
	public const string QUOTA_FAILED = "Quota Failed";
	public const string QUOTA_MET = "Quota Met";
	public const string AND = "and";

	const string SEALED = "Sealed";
	const string NOT_SEALED = "Not Sealed";

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
			return new Message(QUOTA_FAILED, new string[]{"Belts Not Running", "Conveyor belt speed is set to zero"});
		}
	}

	public static Message InsufficentItemsMessage {
		get {
			return new Message(QUOTA_FAILED, new string[]{"Quota count not met"});
		}
	}

	public static Message QuotaMetMessage {
		get {
			return new Message(QUOTA_MET, new string[]{"The factory quota has been meet"});
		}
	}

	public static Message GetSimpleQuotaMismatchMessage (SimpleQuota correctQuota, SimpleQuota suppliedQuota) {
		FactoryObjectDescriptorV1 expected = correctQuota.IDescriptor;
		FactoryObjectDescriptorV1 received = suppliedQuota.IDescriptor;
		string countMessage = expectedReceivedString(Quota.AMOUNT, correctQuota.ICount, suppliedQuota.ICount);
		string colorMessage = expectedReceivedString(FactoryObject.COLOR_TAG, ColorUtil.ToString(expected.Color), ColorUtil.ToString(received.Color));
		string materialsMessage = expectedReceivedString(FactoryObject.MATERIALS_TAG, expected.Materials, received.Materials);
		string shippingMessage = expectedReceivedString(FactoryObject.SHIPPING_TAG, expected.Shipping, received.Shipping);
		string isSealedMessage = expectedReceivedString(FactoryObject.SEALED_TAG, expected.IsSealed, received.IsSealed);
		return new Message(QUOTA_FAILED, new string[]{countMessage, colorMessage, materialsMessage, shippingMessage, isSealedMessage});
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

}
