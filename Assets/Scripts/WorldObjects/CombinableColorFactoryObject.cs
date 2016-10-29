/*
 * Author(s): Isaiah Mann
 * Description: An object that combines its color with another object
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// Color reference: http://color-wheel-artist.com/primary-colors.html
public class CombinableColorFactoryObject : CombinableFactoryObject {
	Color orange = Color.Lerp(Color.red, Color.yellow, 0.5f);
	Color purple = Color.Lerp(Color.blue, Color.red, 0.5f);

	// Potential inputs Red, Yellow, Blue
	Color getColorCombination (Color otherColor) {
		Color myColor = GetColor();
		HashSet<Color> colors = new HashSet<Color>(new Color[]{myColor, otherColor});
		// TODO: Return color combinations (secondary colors)
		if (colors.Contains(Color.blue) && colors.Contains(Color.yellow)) {
			return Color.green;
		} else if (colors.Contains(Color.red) && colors.Contains(Color.yellow)) {
			return orange;
		} else if (colors.Contains(Color.red) && colors.Contains(Color.blue)) {
			return purple;
		} else {
			return myColor;
		}
	}

	bool isSameColor (Color color) {
		// Return true if the color is one of the primary colors
		return color == GetColor();
	}

	public override FactoryObject Combine (CombinableFactoryObject factoryObject) {
		SetColor(getColorCombination(factoryObject.GetColor()));
		return base.Combine (factoryObject);
	}

	public override bool CanCombineWith (CombinableFactoryObject factoryObject) {
		if (factoryObject is CombinableColorFactoryObject) {
			CombinableColorFactoryObject combinable = factoryObject as CombinableColorFactoryObject;
			return !isSameColor(combinable.GetColor());
		} else {
			return base.CanCombineWith (factoryObject);
		}
	}
}
