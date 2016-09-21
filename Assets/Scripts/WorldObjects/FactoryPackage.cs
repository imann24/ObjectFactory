/*
 * Author(s): Isaiah Mann
 * Description: Stores FactoryObjects
 */

using UnityEngine;
using System.Collections;

public class FactoryPackage : FactoryObject {
	FactoryObject[] contents;
	public FactoryObject[] Contents {
		get {
			if (contents == null) {
				contents = new FactoryObject[0];
			}
			return contents;
		}
	}

	public void SetContents (FactoryObject[] contents) {
		this.contents = contents;
		foreach (FactoryObject factoryObject in this.contents) {
			captureSprite(factoryObject);
		}
	}
}
