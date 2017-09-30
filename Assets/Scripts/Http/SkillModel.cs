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


	/**
     * 用户战法Id
     */
	public string userSkillId;
	/**
     * '等级'
     */
	public int level;
	/**
     * 合成进度
     */
	public int percent;

	/**
     * '装配英雄编号'
     */
	public string useHeroId;

	public InnerHeroModel useHeroModel;

	public int canUpExp; // 升级需要的经验
}

[System.Serializable]
public class InnerHeroModel {
	public string userHeroId;
	public string heroId;
	public string nickname;
	public string desc;
	public int star;
	public float cost;
	public int type;
	public int intelligence;
	public int atkDist;
	public int towerAtk;
	public int attack;
	public int defence;
	public int speed;
	public string skillId;
	public string exSkillId;
	public int status;
	public int position;

	public string exSkillId1;
	public string exSkillId2;
	public int exp;
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