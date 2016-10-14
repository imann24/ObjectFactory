/*
 * Author(s): Isaiah Mann
 * Description: Describes a certain quota that must be met in the factory
 */

public abstract class Quota {
	bool _hasQuota;
	int _quotaIndex;
	public int IQuotaIndex {
		get {
			return _quotaIndex;
		}
	}
	public bool IHasQuotaIndex {
		get {
			return _hasQuota;
		}
	}

	public Quota () {
		_quotaIndex = -1;
		_hasQuota = false;
	}

	public Quota (int quotaIndex) {
		this._hasQuota = true;
		this._quotaIndex = quotaIndex;
	}

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
