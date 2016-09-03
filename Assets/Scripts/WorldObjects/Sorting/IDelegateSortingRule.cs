/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public interface IDelegateSortingRule {
	int DetermineSortIndex (WorldObject objectToSort, WorldSocket[] possibleOuputs);
	int PeekSortIndex (WorldObject objectToSort, WorldSocket[] possibleOutputs);
	int TickSortIndex (WorldObject objectToSort, WorldSocket[] possibleOutputs);
}
