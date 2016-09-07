/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public static class ColorUtil {
	const float FULL_OPACITY = 1f;
	const float NO_OPACITY = 0f;
	const string RED_KEY = "Red";
	const string BLUE_KEY = "Blue";
	const string YELLOW_KEY = "Yellow";
	const string GREEN_KEY = "Green";

	public static UnityEngine.Color trueYellow {
		get {
			return new UnityEngine.Color(FULL_OPACITY, FULL_OPACITY, NO_OPACITY);
		}
	}

	public static UnityEngine.Color[] Colors = new UnityEngine.Color[]{
		UnityEngine.Color.red, 
		UnityEngine.Color.blue, 
		ColorUtil.trueYellow, 
		UnityEngine.Color.green};
	
	public static string ToString (UnityEngine.Color color) {
		if (color == UnityEngine.Color.red) {
			return RED_KEY;
		} else if (color == UnityEngine.Color.blue) {
			return BLUE_KEY;
		} else if (color == UnityEngine.Color.yellow) {
			return YELLOW_KEY;
		} else if (color == UnityEngine.Color.green) {
			return GREEN_KEY;
		} else {
			return color.ToString();
		}
	}

	public static UnityEngine.Color RandomColor () {
		return ArrayUtil.Random(Colors);
	}
}
