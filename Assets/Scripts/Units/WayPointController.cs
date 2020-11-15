using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Units;

public class WayPointController : MonoBehaviour//rename to TargetController?
{
	public Image SelectedImage;
	public Image TargetedImage;

	public List<UnitController> TargetedUnits = new List<UnitController>();
}