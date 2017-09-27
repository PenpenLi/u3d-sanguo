using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleScrollList : MonoBehaviour {
	public Button btn;

	private ChapterHttpRequest chapterRequest;
	private List<BattleModel> battles = new List<BattleModel>();

	private float screenW;

	// Use this for initialization
	void Start () {

		RefreshDisplay ();

		GameObject canvasObj = GameObject.FindGameObjectWithTag ("ChapterCanvas");
		if(canvasObj != null){
			screenW = canvasObj.GetComponent<RectTransform> ().rect.width;
		}

		chapterRequest = Singleton<ChapterHttpRequest>.Instance;
		chapterRequest.getAllBattleByChapterId (BattleController.chapterModel.chapterId, this);
	}

	// Update is called once per frame
	void Update () {

	}

	void RefreshDisplay(){
		AddButtons ();
	}

	void AddButtons(){
		for(int i=0; i<battles.Count; i++){
			Button bt = Instantiate (btn);
			bt.transform.SetParent (transform, true);
			//bt.GetComponent<RectTransform> ().SetPositionAndRotation (new Vector3(0, -i*150, 0), Quaternion.identity);
			bt.GetComponent<RectTransform> ().localPosition= new Vector3(0, -i*150, 0);
			RectTransform rt = bt.GetComponent<RectTransform> ();
			//			rt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Left, 0, 750);
			rt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Top, i*150, 150);

			BattleItem item = bt.GetComponent<BattleItem> ();
			BattleModel model = battles[i];
			model.order = i + 1;
			item.Bind (model, this);
		}

		RectTransform rootRt = GetComponent<RectTransform> ();
		rootRt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Left, 0, screenW);
		rootRt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Top, 0, battles.Count * 150);
	}

	public void DetailBtnClick(BattleModel battleModel){
		FightController.battleModel = battleModel;
		SceneManager.LoadScene ("Fight");
	}

	public void GetAllBattleByChapterIdSuccess(List<BattleModel> newBattles){
		battles.Clear ();
		battles.AddRange (newBattles);
		RefreshDisplay ();
	}
}
