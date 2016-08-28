/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class MessageBehaviour : UIBehaviour {
	const float MESSAGE_HEIGHT = 50;
	const float SCROLL_TO_TOP = 1;

	public UnityEngine.UI.Text Title;
	public Transform ScrollViewContent;
	public GameObject ScrollViewRowPrefab;

	public void InitWithMessage (Message message) {
		Title.text = message.Title;
		foreach (string line in message.Contents) {
			AddScrollViewRow(line);
		}
		GetComponentInChildren<UnityEngine.UI.Scrollbar>().value = SCROLL_TO_TOP;
	}
		
	public void Close () {
		Destroy(gameObject);
	}

	void AddScrollViewRow (string text) {
		GameObject row = Instantiate(ScrollViewRowPrefab);
		Transform rowTransform = row.transform;
		ExpandScrollViewSize(MESSAGE_HEIGHT);
		rowTransform.SetParent(ScrollViewContent);
		rowTransform.localScale = Vector3.one;
		ScrollViewRowBehaviour rowBehaviour = row.GetComponent<ScrollViewRowBehaviour>();
		rowBehaviour.SetText(text);
	}

	void ExpandScrollViewSize(float deltaHeight) {
		RectTransform scrolLViewContentTransform = ScrollViewContent.GetComponent<RectTransform>();
		Vector2 scrollViewSize = scrolLViewContentTransform.sizeDelta;
		scrollViewSize.y += deltaHeight;
		scrolLViewContentTransform.sizeDelta = scrollViewSize;
	}
}
