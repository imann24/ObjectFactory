/*
 * Author(s): Isaiah Mann
 * Description: Utility classes to assist with using arrays
 */

using System;

using System.Collections.Generic;

public static class ArrayUtil {
	// Fetches the first index of an array element
	public static int IndexOf<T> (T[] source, T element) where T : IComparable {
		for (int i = 0; i < source.Length; i++) {
			if (source[i].CompareTo(element) == 0) {
				return i;
			}
		}

		throw new KeyNotFoundException();
	}

	public static T Random<T> (T[] source) {
		return source[UnityEngine.Random.Range(0, source.Length)];
	}

	public static T [] RemoveNullElements<T> (T[] original) {
		List<T> modified = new List<T>();
		for (int i = 0; i < original.Length; i++) {
			if (original[i] != null) {
				modified.Add(original[i]);
			}
		}
		return modified.ToArray();
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
