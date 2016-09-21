/*
 * Author(s): Isaiah Mann
 * Description: Describes a factory package
 */

using UnityEngine;
using System.Collections;

public class FactoryPackageDescriptorV1 : FactoryObjectDescriptor {
	public const string TYPE = "PackageV1";
	public FactoryObjectDescriptor[] Contents;

	public FactoryPackageDescriptorV1 (FactoryObjectDescriptor[] contents) : base (TYPE) {
		this.Contents = contents;
	}
}
