using System;

[Serializable]
public class FightItemModel
{
	// '战报编号'
	public string reportId;
	// '回合数'
	public int round;
	// '编号'
	public int orderNum;
	// '触发武将'
	public string fromHero;
	// '战法'
	public string skill;
	// '影响武将'
	public string toHero;
	// '影响属性'
	public string prop;
	// '影响数值'
	public int val;
	// '描述'
	public string describ;
}

