/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public class QuotaMessage : Message {
	const string TITLE = "Factory Quota";
	const char COLON = ':';

	public QuotaMessage (Quota quota) : base (TITLE + COLON, processQuota(quota)){}

	public QuotaMessage (Quota quota, int quotaIndex) : base (getIndexedTitle(quotaIndex), processQuota(quota)){}

	static string getIndexedTitle (int index) {
		return string.Format("{0} {1}{2}", TITLE, index, COLON);
	}

	static string[] processQuota (Quota quota) {
		return quota.ToStringArr();
	}
}
