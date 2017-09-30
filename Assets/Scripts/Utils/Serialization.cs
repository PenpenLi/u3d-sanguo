using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Serialization<T>
{
	[SerializeField]
	List<T> target;
	public List<T> ToList() { return target; }

	public Serialization(List<T> target)
	{
		this.target = target;
	}

	public static string ConvertToStr(Serialization<T> obj){
		string str = JsonUtility.ToJson (obj);
		string result = str.Substring ("{\"target\":".Length, str.Length-1-"{\"target\":".Length);
		return result;
	}
}
