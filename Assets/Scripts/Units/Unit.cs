using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
Миньоны в начале игры должны быть немного слабее противников, но игрок имеет возможность управлять ими.
При появлении все миньоны автоматически отправляются на перехват противников на карте, 
	если противников на данный момент нет, миньоны отправляются к фонтану.
*/

namespace Units
{
	public class Unit
	{
		private int hp;
		public int HP
		{
			get
			{
				return hp;
			}
			set
			{
				if (value < 0)
				{
					value = 0;
				}
				if (value > MaxHP)
				{
					value = MaxHP;
				}
				hp = value;
			}
		}//количество жизней
		public float Armor; //сколько урона в процентном соотношении может быть поглощено, дробное число [0..1]
		public int Attack;  //сколько урона наносится за один удар
		public float AttackSpeed;   //ударов в секунду. Число может быть дробным, например, 1.5 удара в секунду
		public int Speed;   //метров в секунду
		public int AttackRange; //расстояние, на которое необходимо подойти, чтобы нанести урон
		public int Gold;    //количество золота, которое получает игрок за убийство юнита
		public int XP;  //количество опыта, которое получает главный персонаж игрока за убийство юнита		
		public Faction Faction;

		public readonly int MaxHP;
		
		public Unit(int hp, int armor, int attack, int attackSpeed, int speed, int attackRange, int gold, int xp, Faction faction)
		{
			MaxHP = HP = hp;
			Armor = armor;
			Attack = attack;
			AttackSpeed = attackSpeed;
			Speed = speed;
			AttackRange = attackRange;
			Gold = gold;
			XP = xp;
			Faction = faction;
		}
		public void SelectTarget()
		{
			//Все мобы должны уметь автоматически выбирать для атаки ближайшую цель, если у них не задано другое поведение.
		}
	}
}