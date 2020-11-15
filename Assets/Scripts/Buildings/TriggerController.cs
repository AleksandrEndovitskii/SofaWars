using UnityEngine;
using System.Collections;
using Units;

namespace Buildings
{
	public class TriggerController : MonoBehaviour
	{
		public FountainController FountainController;

		void OnTriggerEnter(Collider other)
		{
			FountainController.Fountain.UnitEnterRange(other.GetComponent<UnitController>().Unit);
			//Debug.Log("OnTriggerEnter");
		}
		void OnTriggerStay(Collider other)
		{
			//Debug.Log("OnTriggerStay");
		}
		void OnTriggerExit(Collider other)
		{
			FountainController.Fountain.UnitExitRange(other.GetComponent<UnitController>().Unit);
			//Debug.Log("OnTriggerExit");
		}
	}
}