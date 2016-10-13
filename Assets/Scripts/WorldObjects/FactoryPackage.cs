/*
 * Author(s): Isaiah Mann
 * Description: Stores FactoryObjects
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	public FactoryObjectDescriptorV1[] GetReport () {
		FactoryObjectDescriptorV1[] descriptors = new FactoryObjectDescriptorV1[contents.Length];
		for (int i = 0; i < descriptors.Length; i++) {
			descriptors[i] = contents[i].GetV1Descriptor();
		}
		return descriptors;
	}

	public new FactoryPackageDescriptorV1 GetV1Descriptor () {
		FactoryObjectDescriptorV1[] contentDescriptors = new FactoryObjectDescriptorV1[contents.Length];
		for (int i = 0; i < contents.Length; i++) {
			contentDescriptors[i] = contents[i].GetV1Descriptor();
		}
		return new FactoryPackageDescriptorV1(contentDescriptors);
	}
}
