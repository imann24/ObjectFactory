/*
 * Author(s): Isaiah Mann
 * Description: Preset messages
 */

public static class MessageUtil {
	public static Message ZeroBeltSpeedMessage {
		get {
			return new Message("Quota Failed", new string[]{"Belts Not Running", "Conveyor belt speed is set to zero"});
		}
	}
}
