using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Units;

/*
Казармы
Казармы могут
	производить юнитов заданного типа
Казармы должны иметь 5 уровней, каждый из которых
	увеличивает скорость тренировки юнитов выбранного типа и
	добавляет заданные характеристики к миньонам,
при этом миньоны, находящиеся на карте, не остаются с теми же характеристиками, которые у них были до этого (слабее новых).

Для каждого инстанса казармы на сцене должна быть возможность настройки каждого уровня:
	 Стоимость улучшения;
	 Список характеристик, которые добавятся к характеристикам предыдущего уровня
		(список характеристик можно посмотреть в разделе “Юниты”);
	 Новая скорость тренировки юнитов.
*/

namespace Buildings
{
	public class Barracks : SpamPoint, Building 
	{
		public int Level;//Уровень здания

		public Barracks(SpamUnitType spamUnitType, Faction faction, float treningSpeed):
			base(spamUnitType,faction,treningSpeed)
		{
			Level = 1;
		}
	}
}