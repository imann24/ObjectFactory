/*
 * Author(s): Isaiah Mann
 * Description: Describes a certain quota that must be met in the factory
 */

public abstract class Quota {
	public const string AMOUNT = "Amount";
	public const char ITEM_DIVIDER_CHAR = '\n';
	public abstract bool CheckSatisfied(params object [] arguments);
	// Override in subclasses
	public virtual int CheckSimilarities(params object [] arguments) {
		return 0;
	}
	public string[] ToStringArr () {
		return this.ToString().Split(ITEM_DIVIDER_CHAR);
	}
}
