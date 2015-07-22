using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class MouseLook : MonoBehaviour {

	private const string UP_DOWN_ROTATION = "Mouse Y";
	private const string LEFT_RIGHT_ROTATION = "Mouse X";

	[SerializeField] private Camera mainCamera;
	[SerializeField] private Transform headTransform;
	[SerializeField] private Transform charTransform;
	[SerializeField] private Transform neckTransform;

	public enum RotationAxes 
	{ 
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	[SerializeField] private RotationAxes axes = RotationAxes.MouseXAndY;

	[SerializeField] private float sensitivityX = 15F;
	[SerializeField] private float sensitivityY = 15F;
	
	[SerializeField] private float minimumX = -360F;
	[SerializeField] private float maximumX = 360F;
	
	[SerializeField] private float minimumY = -60F;
	[SerializeField] private float maximumY = 60F;
	
	float rotationY = 0F;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void LateUpdate()
	{
		if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = charTransform.localEulerAngles.y + (Input.GetAxis(LEFT_RIGHT_ROTATION) * sensitivityX);

			rotationY += Input.GetAxis(UP_DOWN_ROTATION) * sensitivityY;
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

			headTransform.localEulerAngles = new Vector3(-rotationY, 0, 0);
			charTransform.localEulerAngles = new Vector3(0, rotationX, 0);

			//neckTransform.localEulerAngles = Vector3.zero;
			mainCamera.transform.localEulerAngles = new Vector3(0,0, neckTransform.localEulerAngles.z*(-1));
		}

		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis(LEFT_RIGHT_ROTATION) * sensitivityX, 0);
		}

		else
		{
			rotationY += Input.GetAxis(UP_DOWN_ROTATION) * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			headTransform.localEulerAngles = new Vector3(-rotationY, headTransform.localEulerAngles.y, 0);
		}
	}
}
