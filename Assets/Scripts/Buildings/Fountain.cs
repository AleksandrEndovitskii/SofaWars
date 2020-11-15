using System.Collections.Generic;
using System.Timers;
using UnityEngine;

using Units;

namespace Buildings
{
	public class Fountain : SpamPoint, Building
	{
		public int MainCharacterHoT;    //Скорость восстановления здоровья героя (жизней в секунду)
		public int MinionHoT;   //Скорость восстановления здоровья миньонов (жизней в секунду)

		private List<Unit> unitsInRange = new List<Unit>();
		public MainCharacter mainCharacter = null;//private

		public Fountain(float deathDelayPerLvL, int mainCharacterHoT, int minionHoT):
			base(SpamUnitType.MainCharacter, Faction.Friend, 1/ deathDelayPerLvL)
		{
			MainCharacterHoT = mainCharacterHoT;
			MinionHoT = minionHoT;
		}

		private void Heal(MainCharacter mainCharacter)
		{
			mainCharacter.HP += MainCharacterHoT;
		}
		private void Heal(Unit minion)
		{
			minion.HP += MinionHoT;
		}

		public override void PassedOneSecond(object source, ElapsedEventArgs e)
		{
			if (mainCharacter == null)//1st insta spam
			{
				UnitsIsReadyCount = 1;
			}
			else
			{
				if (mainCharacter.HP<=0)
				{
					if(UnitsIsReadyCount + TrainingSpeed>=1)//prepare for resurrection
					{
						mainCharacter.HP = mainCharacter.MaxHP;
					}
					UnitsIsReadyCount += TrainingSpeed;
				}
			}

			foreach (Unit unit in unitsInRange)
			{
				Heal(unit);
			}
		}

		public override Unit Spam()
		{
			if (mainCharacter == null)
			{
				mainCharacter = (MainCharacter)base.Spam();
			}

			return mainCharacter;
		}

		public void UnitEnterRange(Unit unit)
		{
			unitsInRange.Add(unit);
		}
		public void UnitExitRange(Unit unit)
		{
			unitsInRange.Remove(unit);
		}
	}
}