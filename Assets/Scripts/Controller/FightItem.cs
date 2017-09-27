using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightItem : MonoBehaviour {

	public Text txt;

	public void Bind(FightItemModel model, FightScrollList scrollList){
		string result = "";
//		result += "<color=navy>【" + PrefDefine.SOLDIER_TYPE[model.fromHero.type] + "·" + model.fromHero.nickname + "】</color>";

		result = model.describ;

		txt.text = result;
	}
}
