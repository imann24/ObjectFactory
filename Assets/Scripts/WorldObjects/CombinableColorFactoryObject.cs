/*
 * Author(s): [Insert Your Name Here], Isaiah Mann
 * Description: An object that can combine with another object. 
 * Description (cont.): It assumes the color produced by mixing its color and the other object's color
 * Description (cont.): CombinationColorFactoryObject's should be created with primary colors
 * Time to Complete: [Insert How Long This Project Took You to Complete]
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombinableColorFactoryObject : CombinableFactoryObject {

	// Color reference: http://color-wheel-artist.com/primary-colors.html

	// Use these predefined colors when setting the object's new color
	protected Color orange = Color.Lerp(Color.red, Color.yellow, 0.5f); // Color.red + Color.yellow
	protected Color purple = Color.Lerp(Color.blue, Color.red, 0.5f); // Color.blue + Color.red
	protected Color green = Color.green; // Color.yellow + Color.blue

	/*
	 * HELPER METHODS:
	 * Color GetColor(); --> Returns the current color of this factory object
	 * void SetColor(Color color); --> Sets the object to a certain color
	 * 
	 * Read more about what a helper method is here: http://forums.devshed.com/java-help-9/helper-method-350163.html
	 */

	// Potential inputs to this function: Color.red, Color.yellow, Color.blue
	Color getColorCombination (Color otherColor) {
		// TODO: Check this object's color against the other color 
		// (this object also only has the potential values of Color.red, Color.yellow, Color.blue)

		// TODO: Return the secondary color that is a result of combining these two primary colors 
		// (With a correct implementation the two colors will never be the same color)

		// TODO: Include an else statement that returns gray (or any other color)
		// This statement should never be used, it's just here to satisfy the compiler
		return Color.gray;
	}

	bool isSameColor (Color color) {
		// TODO: Return true if the color matches the color of this object

		// TODO: Return false if the colors do not match
		return false;
	}

	public override FactoryObject Combine (CombinableFactoryObject factoryObject) {
		// TODO: Set this object's color to the combination of the other object's color and its own

		// NOTE: This function should use the getColorCombination function
		// NOTE: Use GetColor() to determine which color the two objects are

		return base.Combine (factoryObject);
	}

	// This method is already implemented for you
	// However, it relies on the isSameColor method to function correctly
	public override bool CanCombineWith (CombinableFactoryObject factoryObject) {
		if (factoryObject is CombinableColorFactoryObject) {
			CombinableColorFactoryObject combinable = factoryObject as CombinableColorFactoryObject;
			return !isSameColor(combinable.GetColor());
		} else {
			return base.CanCombineWith (factoryObject);
		}
	}
}
