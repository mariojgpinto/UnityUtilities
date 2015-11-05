using UnityEngine;
using System;
using System.IO;
using System.Collections;


public class Score{
	static int score = 0;
	static string fileName = "high.scores";

	public static void ResetScore(){
		score = 0;
	}

	public static void AddToScore(int val){
		score += val;
	}

	public static int GetScore(){
		return score;
	}

	public static int GetHighScore(){
		if(File.Exists(Application.persistentDataPath + "/" + fileName)){
			string text = File.ReadAllText(Application.persistentDataPath + "/" + fileName);

			if(text != null && text != ""){
				string[] lines = text.Split(new char[]{'\n'});
				if(lines.Length > 0){
					return Convert.ToInt32(lines[0]);
				}
		}
		}
		return 0;
	}

	public static int SaveScore(){
		int highScore = GetHighScore();

		if(score > 0){
			if(highScore < score){
				File.WriteAllText(Application.persistentDataPath + "/" + fileName, "" + score);
				return score;
			}
		}

		return highScore;
	}
}
