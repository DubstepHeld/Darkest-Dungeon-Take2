using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager {
    
	public static void SavePlayer(Character[] player, int saveslot) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.persistentDataPath + "/slot" + saveslot.ToString() + "Player.sav", FileMode.Create);

		PlayerData data = new PlayerData(player);

		bf.Serialize (stream, data);
		stream.Close ();
	}

	public static void SaveEnemy(EnemyCharacter[] enemy, int saveslot) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.persistentDataPath + "/slot" + saveslot.ToString() + "Enemy.sav", FileMode.Create);

		EnemyData data = new EnemyData (enemy);

		bf.Serialize (stream, data);
		stream.Close ();
	}

	public static void SaveGameData(FightManager fightManager, int saveslot) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.persistentDataPath + "/slot" + saveslot.ToString() + "GameData.sav", FileMode.Create);
		GameProgress data = new GameProgress (fightManager);
		bf.Serialize (stream, data);
		stream.Close();
		Debug.Log ("Data saved to slot " + saveslot);
	}

	public static float[] LoadPlayer(int position, int saveslot) {
		if (File.Exists (Application.persistentDataPath + "/slot" + saveslot.ToString() + "Player.sav")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/slot" + saveslot.ToString() + "Player.sav", FileMode.Open);

			PlayerData data = bf.Deserialize (stream) as PlayerData;

			stream.Close ();
            float[] stats = new float[10];
            for (int i = 0; i < stats.Length; i++) {
                if (position == 0)
                    stats[i] = data.stats[0, i];
                if (position == 1)
                    stats[i] = data.stats[1, i];
                if (position == 2)
                    stats[i] = data.stats[2, i];
                if (position == 3)
                    stats[i] = data.stats[3, i];
            }
            if (position < 4)
                return stats;
            else
                return new float[10];
			
		} else {
			Debug.LogError ("File not found");
			return new float[6]; 
		}
	}
	public static float[] LoadEnemy(int position, int saveslot) {
		if (File.Exists (Application.persistentDataPath + "/slot" + saveslot.ToString() + "Enemy.sav")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/slot" + saveslot.ToString() + "Enemy.sav", FileMode.Open);

			EnemyData data = bf.Deserialize (stream) as EnemyData;

			stream.Close ();
			if (position == 0)
				return data.stats0;
			else if (position == 1)
				return data.stats1;
			else if (position == 2)
				return data.stats2;
			else if (position == 3)
				return data.stats3;
			else {
				return new float[10];
			}

		} else {
			Debug.LogError ("File not found");
			return new float[6]; 
		}
	}

	public static float[] LoadGameData(int saveslot) {
		if (File.Exists (Application.persistentDataPath + "/slot" + saveslot.ToString() + "GameData.sav")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/slot" + saveslot.ToString() + "GameData.sav", FileMode.Open);
			GameProgress data = bf.Deserialize (stream) as GameProgress;
			stream.Close ();

			Debug.Log ("Data loaded from slot " + saveslot);
			return data.gameData;
		} else {
			return new float[6];
		}
	}
}

[Serializable]
public class GameProgress {
	public float[] gameData;

	public GameProgress(FightManager fightManager) {
		gameData = new float[10];
		gameData [0] = fightManager.wave;
		gameData [1] = fightManager.gold;
		gameData [2] = fightManager.volume;
	}
}

[Serializable]
public class PlayerData {
    public float[,] stats;
	public PlayerData(Character[] player) {
        stats = new float [4,10];
        for (int i = 0; i < 4; i++) {
            stats[i,0] = player[i].health;
            stats[i,1] = player[i].damage;
            stats[i,2] = player[i].dodge;
            stats[i,3] = player[i].initiative;
            stats[i,4] = player[i].playerIndex;
            stats[i,5] = player[i].position;
            stats[i,6] = player[i].hitChance;
            stats[i,7] = player[i].blightRes;
            stats[i,8] = player[i].stunRes;
            stats[i,9] = player[i].bleedRes;
        }
		
	}
}

[Serializable]
public class EnemyData {
	public float[] stats0;
	public float[] stats1;
	public float[] stats2;
	public float[] stats3;

	public EnemyData(EnemyCharacter[] enemy) {
		stats0 = new float[10];
		stats0 [0] = enemy [0].health;
		stats0 [1] = enemy [0].damage;
		stats0 [2] = enemy [0].dodge;
		stats0 [3] = enemy [0].initiative;
		stats0 [4] = enemy [0].enemyIndex;
		stats0 [5] = enemy [0].position;
		stats0 [6] = enemy [0].hitChance;
		stats0 [7] = enemy [0].blightRes;
		stats0 [8] = enemy [0].stunRes;
		stats0 [9] = enemy [0].bleedRes;

		stats1 = new float[10];
		stats1 [0] = enemy [1].health;
		stats1 [1] = enemy [1].damage;
		stats1 [2] = enemy [1].dodge;
		stats1 [3] = enemy [1].initiative;
		stats1 [4] = enemy [1].enemyIndex;
		stats1 [5] = enemy [1].position;
		stats1 [6] = enemy [1].hitChance;
		stats1 [7] = enemy [1].blightRes;
		stats1 [8] = enemy [1].stunRes;
		stats1 [9] = enemy [1].bleedRes;

		stats2 = new float[10];
		stats2 [0] = enemy [2].health;
		stats2 [1] = enemy [2].damage;
		stats2 [2] = enemy [2].dodge;
		stats2 [3] = enemy [2].initiative;
		stats2 [4] = enemy [2].enemyIndex;
		stats2 [5] = enemy [2].position;
		stats2 [6] = enemy [2].hitChance;
		stats2 [7] = enemy [2].blightRes;
		stats2 [8] = enemy [2].stunRes;
		stats2 [9] = enemy [2].bleedRes;

		stats3 = new float[10];
		stats3 [0] = enemy [3].health;
		stats3 [1] = enemy [3].damage;
		stats3 [2] = enemy [3].dodge;
		stats3 [3] = enemy [3].initiative;
		stats3 [4] = enemy [3].enemyIndex;
		stats3 [5] = enemy [3].position;
		stats3 [6] = enemy [3].hitChance;
		stats3 [7] = enemy [3].blightRes;
		stats3 [8] = enemy [3].stunRes;
		stats3 [9] = enemy [3].bleedRes;
	}
}
