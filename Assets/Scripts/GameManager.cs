using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Buildings;
using Units;
using System.Timers;

/*
Обязательные условия:
	 Наличие нескольких волн разных противников (по показателям, не обязательно визуально);
	 Наличие нескольких типов строений, которые могут тренировать миньонов, а также улучшать их;

	 Наличие 3D-карты;
	
Все противники спаунятся в специальной зоне вверху карты и начинают двигаться в сторону базы игрока. 
Их основной целью является разрушение дивана разработчиков.
Одновременно со спауном противников начинают работать казармы и производить миньонов игрока. 
Все миньоны автоматически начинают атаковать ближайших противников.
При наличии миньонов или главного игрока вне фонтана противники должны атаковать либо миньонов, либо главного персонажа.
Если на карте нет врагов, то миньоны должны начать возвращение к фонтану.
Как только на карте появляется хотя бы один противник, все миньоны должны уйти из-под фонтана и начать атаку противников.
Игра заканчивается тогда, когда все волны противников уничтожены.
Если главный персонаж умирает, то он появляется на фонтане через некоторое время. 
При этом время, оставшееся до возрождения, должно быть показано в правом верхнем углу с соответствующим сообщением. 
Когда главный персонаж воскресает, камера должна автоматически центровать главного персонажа.
*/

public class GameManager : MonoBehaviour
{
	public SofaController Sofa;
	public FountainController Fountain;
	public SpamPointController BarracksOfWarriors;
	public SpamPointController BarracksOfArchers;

	public SpamPointController SpamPointOfEnemyBosses;
	public SpamPointController SpamPointOfEnemyWarriors;
	public SpamPointController SpamPointOfEnemyArchers;

	public Text GameOverText;
	
	void Start()
	{
		Fountain.Fountain = new Fountain(10, 1, 1);
		Fountain.Fountain.Start();
		BarracksOfWarriors.Barracks = new Barracks(SpamUnitType.MeleeFighter, Faction.Friend, 0.2f);
		BarracksOfArchers.Barracks = new Barracks(SpamUnitType.RangedFighter, Faction.Friend, 0.2f);
		SpamPointOfEnemyBosses.Barracks = new Barracks(SpamUnitType.Boss, Faction.Enemy, 0.2f);
		SpamPointOfEnemyWarriors.Barracks = new Barracks(SpamUnitType.MeleeFighter, Faction.Enemy, 0.2f);
		SpamPointOfEnemyArchers.Barracks = new Barracks(SpamUnitType.RangedFighter, Faction.Enemy, 0.2f);

		Timer timer = new Timer();
		timer.Interval = 30000;
		timer.Elapsed += (s, e) =>
		{
			BarracksOfWarriors.Barracks.Start();
			BarracksOfArchers.Barracks.Start();
			SpamPointOfEnemyBosses.Barracks.Start();
			SpamPointOfEnemyWarriors.Barracks.Start();
			SpamPointOfEnemyArchers.Barracks.Start();
			timer.Stop();
		};
		timer.Start();
	}

	public void GameOver()
	{
		Time.timeScale = 0;
		GameOverText.gameObject.SetActive(true);

		// reload the scene example
		//SceneManager.LoadScene(SceneManager.GetSceneAt(0).path);
	}

	public UnitController GetClosestEnemy(UnitController unitController)
	{
		List<UnitController> enemies = new List<UnitController>(SpamPointOfEnemyBosses.UnitControllers);
		enemies.AddRange(SpamPointOfEnemyWarriors.UnitControllers);
		enemies.AddRange(SpamPointOfEnemyArchers.UnitControllers);

		UnitController closestEnemy = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPosition = unitController.transform.position;
		foreach (UnitController enemy in enemies)
		{
			float distance = Vector3.Distance(enemy.transform.position, currentPosition);
			if (distance < minDist)
			{
				closestEnemy = enemy;
				minDist = distance;
			}
		}
		return closestEnemy;
	}

	//public void ApplyDamage(int damage)
	//{
	//	if (currentHealth > 0)
	//	{
	//		currentHealth -= damage;
	//		if (currentHealth <= 0)
	//		{
	//			Destroy(gameObject);
	//		}
	//	}
	//}
}