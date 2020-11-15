using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Units
{
	public class Boss : Unit
	{
		public Boss(int hp, int armor, int attack, int attackSpeed, int speed, int attackRange, int gold, int xp) 
			:base(hp, armor, attack, attackSpeed, speed, attackRange, gold, xp, Faction.Enemy)
		{

		}
	}
}