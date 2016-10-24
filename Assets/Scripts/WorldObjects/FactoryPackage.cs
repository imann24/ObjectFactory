/*
 * Author(s): Isaiah Mann
 * Description: Stores FactoryObjects
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FactoryPackage : FactoryObject {
	PackageMovementLock movementLock;
	List<FactoryObject> contents;

	public FactoryObject[] Contents {
		get {
			if (contents == null) {
				contents = new List<FactoryObject>();
			}
			return contents.ToArray();
		}
	
	}
	protected override void setReferences () {
		base.setReferences ();
		movementLock = GetComponent<PackageMovementLock>();
		if (movementLock) {
			movementLock.SetPackageCount(delegate {
				return Contents.Length;
			});
				
		}
	}

	public void AddObject (FactoryObject factoryObject) {
		contents.Add(factoryObject);
		captureSprite(factoryObject);
	}
		
	public bool IsReadyToMove () {
		if (movementLock) {
			return movementLock.IsReadyToMove();
		} else {
			return true;
		}
	}
		

	public void SetContents (FactoryObject[] contents) {
		this.contents = new List<FactoryObject>(contents);
		foreach (FactoryObject factoryObject in this.contents) {
			captureSprite(factoryObject);
		}
	}

	public FactoryObjectDescriptorV1[] GetReport () {
		FactoryObjectDescriptorV1[] descriptors = new FactoryObjectDescriptorV1[contents.Count];
		for (int i = 0; i < descriptors.Length; i++) {
			descriptors[i] = contents[i].GetV1Descriptor();
		}
		return descriptors;
	}

	public new FactoryPackageDescriptorV1 GetV1Descriptor () {
		FactoryObjectDescriptorV1[] contentDescriptors = new FactoryObjectDescriptorV1[contents.Count];
		for (int i = 0; i < contents.Count; i++) {
			contentDescriptors[i] = contents[i].GetV1Descriptor();
		}
		return new FactoryPackageDescriptorV1(contentDescriptors);
	}
}
