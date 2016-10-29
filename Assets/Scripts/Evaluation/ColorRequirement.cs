/*
 * Author(s): Isaiah Mann
 * Description: Describes which colors a drop zone will satisfy
 */

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DropZone))]
public class ColorRequirement : FactoryRequirement {
	public bool AcceptsAnyColor = false;
	public bool AcceptsAnyNonExcludedColor = false;
	public Color[] AcceptedColors;
	public Color[] ExcludedColors;

	public override bool CheckSatisifed () {
		if (AcceptsAnyColor) {
			return true;
		}
		Color[] objectColors = GetComponent<DropZone>().GetStoredColors();
		bool acceptedColorsIsSatsified = true;
		bool excludedColorsIsSatisfied = true;
		foreach (Color objectColor in objectColors) {
			if (!AcceptsAnyNonExcludedColor) {
				acceptedColorsIsSatsified &= ArrayUtil.Contains(AcceptedColors, objectColor);
				if (!acceptedColorsIsSatsified) {
					return false;
				}
			}
			excludedColorsIsSatisfied &= !ArrayUtil.Contains(ExcludedColors, objectColor);
			if (!excludedColorsIsSatisfied) {
				return false;
			}	
		}
		return acceptedColorsIsSatsified && excludedColorsIsSatisfied;
	}

	public void Set (Color[] acceptsColors, Color[] excludedColors) {
		this.AcceptedColors = acceptsColors;
		this.ExcludedColors = excludedColors;
	}
}
