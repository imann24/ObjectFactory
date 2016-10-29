/*
 * Author(s): Isaiah Mann
 * Description: Meta class that all controllers inherit from (all controllers are singletons)
 */

using UnityEngine;

public abstract class Controller : MannBehaviour {
	protected virtual void Init () {
		// NOTHING
	}
	protected override void SetReferences () {
		Init();
	}

	protected override void FetchReferences () {
		// Nothing
	}

	protected override void HandleNamedEvent (string eventName) {
		// Nothing
	}

	protected override void CleanupReferences () {
		// Nothing
	}
}
