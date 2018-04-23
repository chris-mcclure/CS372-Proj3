using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
 {
	public static float playerStrafe()
	{
		float r = 0.0f;
		r += Input.GetAxis("keyboardStrafe");
		r += Input.GetAxis("controllerStrafe");
		return Mathf.Clamp(r,-1.0f,1.0f);
	}

	public static Vector3 MainJoystick()
	{
		return new Vector3(playerStrafe(),0,0);
	}
}
