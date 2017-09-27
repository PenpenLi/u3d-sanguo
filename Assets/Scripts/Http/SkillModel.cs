using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillModel {
	public string skillId;
	public string skillName;
	public string desc;
	public int skillType;
	public int soldierType;
	public int atkDist;
	public string atkDest;
	public string cond;
	public string caution;
}


//"skillId": "1000",
//"skillName": "神兵天降",
//"desc": "战斗开始后前3回合，使敌军群体受到攻击和策略攻击时的伤害提高15%（受谋略属性影响）",
//"skillType": 1,
//"soldierType": 7,
//"atkDist": 4,
//"atkDest": "敌军群体(有效距离内2个目标)",
//"cond": "该技能可通过拆解武将【蜀·刘备·步】【蜀·黄月英·步】【吴·吕蒙·弓】获得 4星群武将可促使技能研究进度+5% 【蜀·刘备·步】【蜀·黄月英·步】【吴·吕蒙·弓】可促使技能研究进度+30",
//"caution": "技能研究成功后，可配置1个武将"