using UnityEngine;
using Units;

namespace Buildings
{
	[RequireComponent(typeof(TriggerController))]
	public class FountainController : MonoBehaviour
	{
		public Fountain Fountain;
		public TriggerController TriggerController;

		public UnitController MainCharacterController;
				
		void Start()
		{
			TriggerController.FountainController = this;			
		}
		void Update()
		{
			if (Fountain != null)
			{
				if (Fountain.UnitsIsReadyCount >= 1)
				{
					Fountain.UnitsIsReadyCount -= 1;
					Vector3 position =
						new Vector3(transform.position.x, transform.position.y, transform.position.z + transform.localScale.z);
					UnitController mainCharacterController = (UnitController)Instantiate(MainCharacterController, position, Quaternion.identity);
					mainCharacterController.Unit = Fountain.Spam();
					mainCharacterController.gameObject.transform.SetParent(transform);
					//unitController.Target = WayPoint;//.transform;
					MainCharacterController = mainCharacterController;
				}
			}
		}
	}
}