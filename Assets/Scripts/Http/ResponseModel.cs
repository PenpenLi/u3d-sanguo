using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResponseModel<T> {
	public int code;
	public string msg;
	public T data;
}
