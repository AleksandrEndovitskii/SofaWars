using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Abilities;

/*
	при наведении курсора мыши и кликом левой кнопкой мыши на экране статуса выведены характеристики персонажа.
*/

namespace Units
{
	public class MainCharacter : Unit
	{
		private int xp;
		private int unspentPoints;

		public List<Ability> Abilities = new List<Ability>();
		public new int XP //текущий уровень опыта
		{
			get
			{
				return xp;
			}
			set
			{
				xp += value;
				int XPToLvlUp;
				LevelManager.LevelUpMap.TryGetValue(Level, out XPToLvlUp);
				if (XP>= XPToLvlUp)
				{
					PlayLvLUpAnimation();
					UnspentPoints += 1;
				}
			}
		}  
		public int Level;  //текущий уровень
		public new int Gold;
		public int UnspentPoints
		{
			get
			{
				return unspentPoints;
			}
			set
			{
				unspentPoints += value;
				if (unspentPoints > 0)
				{
					/*
					после чего появится возможность улучшить один из существующих скилов.
					*/
				}
			}
		}

		public MainCharacter(int hp, int armor, int attack, int attackSpeed, int speed, int attackRange)
			: base(hp, armor, attack, attackSpeed, speed, attackRange, 0, 0, Faction.Friend)
		{
			Abilities.Add(new MeteorShower());
			Abilities.Add(new IceBolt());
		}

		public void Atack(Unit unit) // where unit is Enemy
		{
			/*
			Главный персонаж получает за убийство противников определенное количество 
			очков опыта (задается индивидуально для каждого типа моба) и 
			золота (задается индивидуально для каждого типа моба).			
			*/

			//move
			//do damage
			if (unit.HP <= 0)
			{
				XP += unit.XP;
				Gold += unit.Gold;
			}
		}

		private void PlayLvLUpAnimation()
		{
			//например, падение луча света на персонажа
		}
	}
}