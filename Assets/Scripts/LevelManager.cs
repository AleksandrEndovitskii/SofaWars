using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Units.Stats;

public class LevelManager : MonoBehaviour
{
	//возможность задавать параметры для каждого уровня главного персонажа из редактора уровней
	//Параметры для каждого уровня:
	public int XP;  //Количество опыта, необходимое для достижения уровня
	public List<Stat> Stats;  //Перечень статов, которые прибавляются к текущему состоянию, такие как Armor, Attack, Attack Speed;
	public readonly int Level;  //уровень по порядку, начиная с первого 
								//(readonly поле, задается автоматически редактором главного персонажа).
	public static Dictionary<int, int> LevelUpMap = new Dictionary<int, int>();

	void Start()
	{
		LevelUpMap.Add(1, 100);
		LevelUpMap.Add(2, 200);
		LevelUpMap.Add(3, 300);
		LevelUpMap.Add(4, 400);
		LevelUpMap.Add(5, 500);
	}
	void Update()
	{

	}
}