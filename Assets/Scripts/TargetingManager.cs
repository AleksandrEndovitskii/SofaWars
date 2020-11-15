using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Units;

public class TargetingManager : MonoBehaviour
{
	private List<UnitController> selectedUnits = new List<UnitController>();

	public CameraController CameraController;
	public WayPointController WayPointController;
	
	void Update ()
	{
		if (EventSystem.current.IsPointerOverGameObject())//click on UI
		{
			return;
		}

		if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) &&
		(Input.GetKeyUp(KeyCode.Mouse0)))   //multiselect
		{
			UnitController unit = GetMouseClickedUnit();
			AddUnitToSelected(unit);
		}
		if (!(Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) &&
			(Input.GetKeyUp(KeyCode.Mouse0)))   //select		
		{
			DeSelectUnits(selectedUnits);

			UnitController unit = GetMouseClickedUnit();
			AddUnitToSelected(unit);

			CameraController.TargetToFollow = unit;//add target fixation in multiselect?
		}
		if ((Input.GetKeyUp(KeyCode.Mouse1)))
		{
			AssignTarget();
		}
	}

	private void AssignTarget()
	{
		if (selectedUnits.Count > 0)//exist units for tageting
		{
			RaycastHit hit = GetMouseClickPosition();
			if (hit.collider != null)//hit something
			{
				WayPointController wayPoint;

				UnitController unit = hit.collider.gameObject.GetComponent<UnitController>();
				if (unit != null)//targeted on unit
				{
					unit.Targeted = true;
					wayPoint = unit.GetComponent<WayPointController>();
				}
				else//targeted on point
				{
					wayPoint = Instantiate(WayPointController);
					wayPoint.transform.position = new Vector3(hit.point.x, wayPoint.transform.position.z, hit.point.z);
				}

				foreach (UnitController selectedUnit in selectedUnits)
				{
					selectedUnit.gameObject.GetComponent<UnitController>().Target = wayPoint;
				}
			}
		}
	}

	private void DeSelectUnits(List<UnitController> selectedUnits)
	{
		foreach (UnitController selectedUnit in selectedUnits)//clear targets on selected units
		{
			selectedUnit.gameObject.GetComponent<UnitController>().Selected = false;
		}
		selectedUnits.Clear();
	}
	private void AddUnitToSelected(UnitController unit)
	{
		if (unit != null)
		{
			unit.Selected = true;
			selectedUnits.Add(unit);
		}
	}

	private UnitController GetMouseClickedUnit()
	{
		UnitController clickedUnit = null;
		RaycastHit hit = GetMouseClickPosition();
		if (hit.collider != null)
		{
			clickedUnit = hit.collider.gameObject.GetComponent<UnitController>();
		}
		return clickedUnit;
	}
	private RaycastHit GetMouseClickPosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray, out hit);
		return hit;
	}
}