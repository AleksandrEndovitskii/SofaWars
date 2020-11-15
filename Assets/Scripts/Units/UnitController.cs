using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Units
{
	[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
	[RequireComponent(typeof(ThirdPersonCharacter))]
	public class UnitController : MonoBehaviour
	{
		private WayPointController target;
		private bool selected;
		private bool targeted;

		public Unit Unit;

		public UnityEngine.AI.NavMeshAgent Agent { get; private set; }             // the navmesh agent required for the path finding
		public ThirdPersonCharacter Character { get; private set; } // the character we are controlling

		public WayPointController Target
		{
			get
			{
				return target;
			}
			set
			{
				WayPointController newWayPointController = value;
				if (newWayPointController != null)
				{
					if (Target != null)
					{
						ClearCurrentTarget();
					}
					newWayPointController.TargetedUnits.Add(this);
				}
				target = value;
			}
		}
		public bool Selected
		{
			get
			{
				return selected;
			}
			set
			{
				selected = value;
				GetComponent<WayPointController>().SelectedImage.gameObject.SetActive(Selected);

				if (Target != null)//hide current target image
				{
					WayPointController wayPointController = Target;
					if (wayPointController != null)
					{
						wayPointController.TargetedImage.gameObject.SetActive(selected);
					}
				}
			}
		}
		public bool Targeted
		{
			get
			{
				return targeted;
			}
			set
			{
				targeted = value;
				GetComponent<WayPointController>().TargetedImage.gameObject.SetActive(targeted);
			}
		}

		private void ClearCurrentTarget()
		{
			WayPointController oldWayPointController = Target;
			if (oldWayPointController != null)
			{
				oldWayPointController.TargetedUnits.Remove(this);
				oldWayPointController.TargetedImage.gameObject.SetActive(false);
				if (oldWayPointController.TargetedUnits.Count == 0 &&
					oldWayPointController.GetComponent<UnitController>() == null)
				{
					Destroy(oldWayPointController.gameObject);
				}
			}
		}
		
		private void Start()
		{
			// get the components on the object we need ( should not be null due to require component so no need to check )
			Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
			Character = GetComponent<ThirdPersonCharacter>();

			//Target = WayPoint.gameObject.transform;//

			Agent.updateRotation = false;
			Agent.updatePosition = true;
		}
		private void Update()
		{
			//TODO: units constantly flow on target after end of moving with slow speed - fix in future
			if (Target != null)
			{
				Agent.SetDestination(Target.transform.position);
			}

			if (Agent.remainingDistance > Agent.stoppingDistance)
			{
				Character.Move(Agent.desiredVelocity, false, false);
			}
			else
			{
				Character.Move(Vector3.zero, false, false);
			}
		}
	}
}