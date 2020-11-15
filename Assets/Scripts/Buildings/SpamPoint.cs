using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Units;
using System.Timers;

namespace Buildings
{
	public class SpamPoint
	{
		public SpamUnitType SpamUnitType;//Тип производимого юнита
		public Faction Faction;
		public float TrainingSpeed;//Скорость тренировки (юнитов в секунду)

		private Timer myTimer = new Timer();

		public float UnitsIsReadyCount;

		public SpamPoint(SpamUnitType spamUnitType, Faction faction, float trainingSpeed)
		{
			SpamUnitType = spamUnitType;
			Faction = faction;
			TrainingSpeed = trainingSpeed;
		}
		public void Start()
		{
			myTimer.Elapsed += (sender, e) => PassedOneSecond(sender, e);
			myTimer.Interval = 1000; // one second
			myTimer.Start();
		}

		public virtual void PassedOneSecond(object source, ElapsedEventArgs e)
		{
			UnitsIsReadyCount += TrainingSpeed;
		}

		public virtual Unit Spam()
		{
			switch (SpamUnitType)
			{
				case SpamUnitType.MeleeFighter:
					return new Unit(10, 10, 10, 5, 5, 1, 10, 10, Faction);
				case SpamUnitType.RangedFighter:
					return new Unit(5, 0, 5, 10, 5, 10, 20, 20, Faction);
				case SpamUnitType.MainCharacter:
					return new MainCharacter(100, 10, 10, 5, 5, 1);
				case SpamUnitType.Boss:
					return new Boss(100, 100, 100, 1, 2, 1, 100, 100);//огромный персонаж
				default:
					return null;
			}
		}
	}
}