using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
При активации метеоритного дождя 
	под курсором должен появиться круг, равный радиусу поражения способности, и 
	двигаться повсюду за курсором мыши. 
После того как игрок нажмет на левую кнопку мыши при активной способности, в зоне, выбранной игроком, 
	должен начаться метеоритный дождь, который наносит одноразовый урон всем врагам в зоне поражения.
*/

namespace Assets.Abilities
{
	public class MeteorShower : Ability, AOE
	{
		//Radius — радиус, в котором наносится урон
		//Damage — урон, наносимый всем врагам в радиусе Radius

		public override void Activate()
		{

		}
		public override void Deactivate()
		{

		}
	}
}