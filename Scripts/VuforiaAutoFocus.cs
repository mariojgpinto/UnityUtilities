using UnityEngine;
using Vuforia;

public class VuforiaAutoFocus : MonoBehaviour {
	void Start () {
		bool focusModeSet = CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
	}
}