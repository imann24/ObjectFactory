/*
 * Author(s): Isaiah Mann
 * Description: Keeps objects from moving
 */

using UnityEngine;
using System.Collections;

public class PackageMovementLock : Module {
	public delegate bool CheckReadyToMove(int packageCount);
	public delegate int GetPackageCount();
	CheckReadyToMove isReadyToMove;
	GetPackageCount packageCount;

	public void SetIsReadyToMove (CheckReadyToMove isReadyToMove) {
		this.isReadyToMove = isReadyToMove;
	}

	public void SetPackageCount (GetPackageCount packageCount) {
		this.packageCount = packageCount;
	}

	public bool IsReadyToMove () {
		if (isReadyToMove != null && packageCount != null) {
			return isReadyToMove(packageCount());
		} else {
			return false;
		}
	}

	void Update () {
		IsReadyToMove();
	}

}
