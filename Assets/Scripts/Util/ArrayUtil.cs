/*
 * Author(s): Isaiah Mann
 * Description: Utility classes to assist with using arrays
 */

public static class ArrayUtil {
	public static T Random<T> (T[] source) {
		return source[UnityEngine.Random.Range(0, source.Length)];
	}

	public static bool Contains<T> (T[] source, T target) {
		bool containsElement = false;
		foreach (T element in source) {
			containsElement |= (element.Equals(target));
		}
		return containsElement;
	}

	public static string ToString<T> (T[] source) {
		string arrayAsString = string.Empty;
		for (int i = 0; i < source.Length; i++) {
			arrayAsString += source[i] + ",\n";
		}
		return arrayAsString;
	}
}
