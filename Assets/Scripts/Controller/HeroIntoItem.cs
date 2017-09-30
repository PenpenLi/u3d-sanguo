using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HeroIntoItem : MonoBehaviour {

	public Button intoBtn;
	public Text nameText;
	public Text percentText;

	private ProductModel model;

	public static Action<ProductModel> HeroIntoClick;

	// Use this for initialization
	void Start () {
		intoBtn.onClick.AddListener (IntoBtnClick);
	}

	// Update is called once per frame
	void Update () {

	}

	public void Bind(ProductModel productModel){
		model = productModel;

		nameText.text = model.describ;
		percentText.text = model.num + "/" + model.intoNum;

		if(model.num < model.intoNum){
			intoBtn.enabled = false;
		}
	}

	public void IntoBtnClick(){
		if(HeroIntoClick != null){
			HeroIntoClick (model);
		}
	}
}
