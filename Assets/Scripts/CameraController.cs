using UnityEngine;
using System.Collections;

using Units;

public class CameraController : MonoBehaviour
{
	private Vector3 offset = new Vector3(0,5,-4);//magic number for acceptable view

	public UnitController TargetToFollow;

	private float borderWidth = 20; // Pixels. The width border at the edge in which the movement work
	public float MovementSpeed = 10; // Scale. Speed of the movement

	void Update()
	{
		if (TargetToFollow != null)
		{
			transform.position = TargetToFollow.transform.position + offset;
		}
		else
		{
			if ((Input.mousePosition.x >= Screen.width - borderWidth && Input.mousePosition.x < Screen.width) ||
				(Input.GetKey(KeyCode.D)))
			{
				transform.position += Vector3.right * Time.deltaTime * MovementSpeed;
			}
			if ((Input.mousePosition.x <= 0 + borderWidth && Input.mousePosition.x > 0) ||
				(Input.GetKey(KeyCode.A)))
			{
				transform.position += Vector3.left * Time.deltaTime * MovementSpeed;
			}
			if ((Input.mousePosition.y >= Screen.height - borderWidth && Input.mousePosition.y < Screen.height) ||
				(Input.GetKey(KeyCode.W)))
			{
				transform.position += Vector3.forward * Time.deltaTime * MovementSpeed;
			}
			if ((Input.mousePosition.y <= 0 + borderWidth && Input.mousePosition.y > 0) ||
				(Input.GetKey(KeyCode.S)))
			{
				transform.position += Vector3.back * Time.deltaTime * MovementSpeed;
			}
		}
	}
}