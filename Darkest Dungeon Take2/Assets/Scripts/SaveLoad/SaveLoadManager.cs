using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager {
    
	public static void SavePlayer(Character[] player, int saveslot) {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream;
		stream = new FileStream(Application.persistentDataPath + "/slot" + saveslot.ToString() + "Player.sav", FileMode.Create);		//ein datenstream (Player.sav) wird erstellt
        PlayerData data = new PlayerData(player);
        bf.Serialize(stream, data);		//der Stream wird mit den zu speichernden Daten verknüpft und dadurch verschlüsselt.
        stream.Close();		//muss geschlossen werden, sonst regnet es beim nächsten Speicherversuch Errors
	}

	public static void SaveEnemy(EnemyCharacter[] enemy, int saveslot) {
		BinaryFormatter bf = new BinaryFormatter ();
        FileStream stream;
        stream = new FileStream(Application.persistentDataPath + "/slot" + saveslot.ToString() + "Enemy.sav", FileMode.Create);
		EnemyData data = new EnemyData (enemy);
		bf.Serialize (stream, data);
		stream.Close ();
	}

	public static void SaveGameData(FightManager fightManager, int saveslot) {
		BinaryFormatter bf = new BinaryFormatter ();
        FileStream stream;
        stream = new FileStream(Application.persistentDataPath + "/slot" + saveslot.ToString() + "GameData.sav", FileMode.Create);
		GameProgress data = new GameProgress (fightManager);
		bf.Serialize (stream, data);
		stream.Close();
		Debug.Log ("Data saved to slot " + saveslot);
	}

	public static float[] LoadPlayer(int position, int saveslot) {
		if (File.Exists (Application.persistentDataPath + "/slot" + saveslot.ToString() + "Player.sav")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/slot" + saveslot.ToString() + "Player.sav", FileMode.Open);		//Öffnen der verschlüsselten Speicherdatei
			PlayerData data = bf.Deserialize (stream) as PlayerData;		//entschlüsseln der Datei
			stream.Close ();

			//Ausgabe der Daten
			//ausgabe nach Position des Characters
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
			return new float[10]; 
		}
	}
	public static float[] LoadEnemy(int position, int saveslot) {
		if (File.Exists (Application.persistentDataPath + "/slot" + saveslot.ToString() + "Enemy.sav")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/slot" + saveslot.ToString() + "Enemy.sav", FileMode.Open);
			EnemyData data = bf.Deserialize (stream) as EnemyData;
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
			return new float[10]; 
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
			return new float[10];
		}
	}
}

[Serializable]
public class GameProgress {
	//Spieldateien
	public float[] gameData;

	public GameProgress(FightManager fightManager) {
        DungeonManager dungeonManager;
        dungeonManager = fightManager.dungeonManager;

		gameData = new float[10];
		gameData [0] = fightManager.wave;
		gameData [1] = fightManager.gold;
		gameData [2] = fightManager.volume;
        gameData [3] = dungeonManager.expLevel;
        gameData [4] = dungeonManager.exp;
        gameData [5] = dungeonManager.dungeonLevel;
	}
}

[Serializable]
public class PlayerData {
	//Characterdaten[position des Characters, zu speichernde variable]
    public float[,] stats;
	public PlayerData(Character[] player) {
        stats = new float[4, 10];
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
	//Enemydaten
    public float[,] stats;
    public EnemyData(EnemyCharacter[] enemy) {
        stats = new float[4, 10];
        for (int i = 0; i < 4; i++) {
            stats[i, 0] = enemy[i].health;
            stats[i, 1] = enemy[i].damage;
            stats[i, 2] = enemy[i].dodge;
            stats[i, 3] = enemy[i].initiative;
            stats[i, 4] = enemy[i].enemyIndex;
            stats[i, 5] = enemy[i].position;
            stats[i, 6] = enemy[i].hitChance;
            stats[i, 7] = enemy[i].blightRes;
            stats[i, 8] = enemy[i].stunRes;
            stats[i, 9] = enemy[i].bleedRes;
        }

    }
}
