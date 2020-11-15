using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Units;

namespace Buildings
{
	public class SpamPointController : MonoBehaviour
	{
		public Barracks Barracks;
		public UnitController UnitController;

		public List<UnitController> UnitControllers = new List<UnitController>();
		
		void Update()
		{
			//code duplication here and in FountainController - solve in future
			if (Barracks != null)
			{
				if (Barracks.UnitsIsReadyCount >= 1)
				{
					Barracks.UnitsIsReadyCount -= 1;
					Vector3 position =
						new Vector3(transform.position.x, transform.position.y, transform.position.z + transform.localScale.z);
					UnitController unitController = (UnitController)Instantiate(UnitController, position, gameObject.transform.rotation);
					unitController.Unit = Barracks.Spam();
					unitController.gameObject.transform.SetParent(transform);
					//unitController.Target = WayPoint;//.transform;
					UnitControllers.Add(unitController);
				}
			}
		}
	}
}