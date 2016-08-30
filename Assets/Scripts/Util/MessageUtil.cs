/*
 * Author(s): Isaiah Mann
 * Description: Preset messages
 */

public static class MessageUtil {
	public const string QUOTA_FAILED = "Quota Failed";
	public const string QUOTA_MET = "Quota Met";

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
}
