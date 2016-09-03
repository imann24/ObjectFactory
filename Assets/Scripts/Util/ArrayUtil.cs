/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public static class ArrayUtil {
	public static T Random<T> (T[] source) {
		return source[UnityEngine.Random.Range(0, source.Length)];
	}
}
