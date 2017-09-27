using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleItem : MonoBehaviour {

	public Button buttonComponent;
	public Text battleNumText;
	public Text battleTitleText;
	public Text statusText;

	private BattleModel model;
	private BattleScrollList scrollList;

	// Use this for initialization
	void Start () {
		buttonComponent.onClick.AddListener (HandleClick);
	}

	// Update is called once per frame
	void Update () {

	}

	public void Bind(BattleModel battleModel, BattleScrollList battleScrollList){
		model = battleModel;
		scrollList = battleScrollList;

		battleNumText.text = "第" + ConvertHelper.convertNumToStr (model.order) + "关";
		battleTitleText.text = model.battleTitle;
		statusText.text = PrefDefine.BATTLE_STATUS[model.status];
	}

	public void HandleClick(){
		scrollList.DetailBtnClick (model);
	}
}
