using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class ConvertHelper
{
	public static Dictionary<int, string> numDic = new Dictionary<int, string>{
		{0,"零"},
		{1,"一"},
		{2,"二"},
		{3,"三"},
		{4,"四"},
		{5,"五"},
		{6,"六"},
		{7,"七"},
		{8,"八"},
		{9,"九"},
	};

	public static string convertNumToStr(int num){
		char[] charArr = num.ToString ().ToCharArray ();
		StringBuilder builder = new StringBuilder ();
		foreach(char c in charArr){
			int i = int.Parse (c.ToString ());
			if(i>=0 && i<10){
				builder.Append (numDic[i]);
			}
		}
		return builder.ToString ();
	}

	public static float Round(float f, int acc)
	{
		float temp = f * Mathf.Pow(10, acc);
		return  Mathf.Round(temp) / Mathf.Pow(10, acc);
	}

	public static string RoundToStr(float f, int acc)
	{
		string[] nums = f.ToString ().Split ('.');
		if(nums.Length > 1){
			nums[1] = nums[1].Substring (0, acc);
		}
		return string.Join (".", nums);
	}
}

