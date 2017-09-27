using System;
using System.Collections.Generic;

public class PrefDefine
{
	public const string PP_USER_SESSION_TOKEN = "PP_USER_SESSION_TOKEN";

	public static Dictionary<int, string> USER_HERO_STATUS = new Dictionary<int, string>{
		{0, ""},
		{1, "已获取"},
		{2, "未获取"},
		{3, "未激活"},
		{5, "已上阵"}
	};

	public static Dictionary<int, string> SKILL_TYPE = new Dictionary<int, string> {
		{0, ""},
		{1, "指挥"},
		{2, "主动"},
		{3, "被动"}
	};

	public static Dictionary<int, string> SOLDIER_TYPE = new Dictionary<int, string> {
		{0, ""},
		{1, "弓"},
		{2, "步"},
		{3, "骑"},
		{4, "弓，步"},
		{5, "弓，骑"},
		{6, "步，骑"},
		{7, "弓，步，骑"}
	};

	public static Dictionary<int, string> CHAPTER_STATUS = new Dictionary<int, string> {
		{0, ""},
		{1, "未通关"},
		{2, "未激活"},
	};

	public static Dictionary<int, string> BATTLE_STATUS = new Dictionary<int, string> {
		{0, ""},
		{1, "未通关"},
		{2, "未激活"},
		{3, "已通关"}
	};

	public static Dictionary<int, string> SKILL_EFFECT_TYPE = new Dictionary<int, string> {
		{ 0, "" },
		{ 1, "损失了" },
		{ 2, "回复了" },
	};
}

