using UnityEngine;
using System.Collections;

using Buildings;

namespace Buildings
{
	public class SofaController : MonoBehaviour
	{
		public Sofa Sofa;

		private GameManager gameManager;

		void Start()
		{
			Sofa = new Sofa();
			gameManager = FindObjectOfType<GameManager>();
		}
		void Update()
		{
			if (Sofa.Destroyed)
			{
				gameManager.GameOver();

				Destroy(gameObject);
			}
		}
	}
}