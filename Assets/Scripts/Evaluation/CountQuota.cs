/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public class CountQuota : Quota {
	int count;
	public int ICount {
		get {
			return count;
		}
	}

	public CountQuota (int count) {
		this.count = count;
	}

	public override bool CheckSatisfied (params object[] arguments) {
		try {
			int countArg = IntUtil.ParseObj(arguments[0]);
			return countArg >= count;
		}
		catch {
			return false;
		}
	}
}
