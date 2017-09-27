using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IHeroItemDelegate
{
	void DetailBtnClick (HeroModel model);
}

public class HeroItem : MonoBehaviour {

	public Button buttonComponent;
	public Text nameText;
	public Text starText;
	public Text costText;
	public Text statusText;

	private HeroModel model;
	private IHeroItemDelegate scrollList;

	// Use this for initialization
	void Start () {
		buttonComponent.onClick.AddListener (HandleClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Bind(HeroModel heroModel, IHeroItemDelegate heroScrollList){
		model = heroModel;
		scrollList = heroScrollList;

		nameText.text = model.nickname;
		starText.text = "星级:" + model.star;
		costText.text = "Cost:" + model.cost;
		statusText.text = PrefDefine.USER_HERO_STATUS[model.status];
	}

	public void HandleClick(){
		scrollList.DetailBtnClick (model);
	}
}
