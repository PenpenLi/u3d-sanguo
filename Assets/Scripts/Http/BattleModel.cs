using System;

[System.Serializable]
public class BattleModel
{
	public int battleId;
	public int chapterId;
	public string battleTitle;
	public string battleDesc;
	public int score;
	public int status;

	public int order;
}

//"battleId": 101,
//"chapterId": 1,
//"battleTitle": "十常侍乱政",
//"battleDesc": "汉末十常侍为奸，朝政日非，人心思乱",
//"score": 0,
//"status": 1