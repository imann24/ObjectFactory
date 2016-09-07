/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public static class FactoryTagController {

	#region Shipping Tags

	public const string PRIORITY = "Priority";
	public const string INTERNATIONAL = "International";
	public const string ECONOMY = "Economy";
	public static string[] ShippingTags = new string[]{PRIORITY, INTERNATIONAL, ECONOMY};

	#endregion

	#region Materials Tags

	public const string HAZARDOUS = "Hazardous";
	public const string FRAGILE = "Fragile";
	public const string HEAVY = "Heavy";
	public static string[] MaterialsTags = new string[]{HAZARDOUS, FRAGILE, HEAVY};

	#endregion

	#region Tag Methods

	public static string RandomShippingTag () {
		return ArrayUtil.Random(ShippingTags);
	}

	public static string RandomMaterialsTag () {
		return ArrayUtil.Random(MaterialsTags);
	}

	#endregion

}
