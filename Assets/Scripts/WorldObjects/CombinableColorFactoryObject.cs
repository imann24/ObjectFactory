/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

// Color reference // http://color-wheel-artist.com/primary-colors.html
public class CombinableColorFactoryObject : CombinableFactoryObject {
	Color _objectColor;
	Color objectColor {
		get {
			return _objectColor;
		}
		set {
			_objectColor = value;
		}
	}

	// Potential inputs Red, Yellow, Blue
	Color getColorCombination (Color otherColor) {
		// TODO: Return color combinations (secondary colors)

		return Color.gray;
	}

	bool isPrimaryColor (Color color) {
		// Return true if the color is one of the primary colors
		return false;
	}

	public override bool CanCombineWith (CombinableFactoryObject factoryObject) {
		if (factoryObject is CombinableColorFactoryObject) {
			CombinableColorFactoryObject combinable = factoryObject as CombinableColorFactoryObject;
			return isPrimaryColor(combinable.objectColor);
		} else {
			return base.CanCombineWith (factoryObject);
		}
	}
}
