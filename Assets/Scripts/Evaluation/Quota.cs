/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public abstract class Quota {
	public const char ITEM_DIVIDER_CHAR = '\n';
	public abstract bool CheckSatisfied(object [] arguments);
	public string[] ToStringArr () {
		return this.ToString().Split(ITEM_DIVIDER_CHAR);
	}
}
