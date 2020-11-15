using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildings
{
	public class Sofa : Building  //основная цель, которую должны разрушить противники. 
	{
		private int hp;
		private bool destroyed;

		public bool Destroyed
		{
			get
			{
				return destroyed;
			}
			set
			{
				destroyed = value;
			}
		}
		public int HP
		{
			get
			{
				return hp;
			}
			set
			{
				hp += value;
				if (hp <= 0)
				{
					Destroyed = true;
				}
			}
		}
	}
}