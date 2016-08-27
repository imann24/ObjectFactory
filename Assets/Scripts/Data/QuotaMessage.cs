/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public class QuotaMessage : Message {
	const string TITLE = "Factory Quota:";
	public QuotaMessage (Quota quota) : base (TITLE, processQuota(quota)){}

	static string[] processQuota (Quota quota) {
		return quota.ToStringArr();
	}
}
