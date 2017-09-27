using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterItem : MonoBehaviour {

	public Button buttonComponent;
	public Text chapterNumText;
	public Text descOneText;
	public Text descTwoText;
	public Text statusText;

	private ChapterModel model;
	private ChapterScrollList scrollList;

	// Use this for initialization
	void Start () {
		buttonComponent.onClick.AddListener (HandleClick);
	}

	// Update is called once per frame
	void Update () {

	}

	public void Bind(ChapterModel chapterModel, ChapterScrollList heroScrollList){
		model = chapterModel;
		scrollList = heroScrollList;

		chapterNumText.text = "第" + ConvertHelper.convertNumToStr(model.chapterId) + "章";

		char[] delimiterChars = {' '};
		string[] words = model.chapterTitle.Split (delimiterChars);
		descOneText.text = words[0];
		descTwoText.text = words[1];
		statusText.text = PrefDefine.CHAPTER_STATUS[model.status];
	}

	public void HandleClick(){
		scrollList.DetailBtnClick (model);
	}
}
