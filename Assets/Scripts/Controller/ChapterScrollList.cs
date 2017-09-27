using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChapterScrollList : MonoBehaviour {
	public Button btn;

	private ChapterHttpRequest chapterRequest;
	private List<ChapterModel> chapters = new List<ChapterModel>();

	private float screenW;

	// Use this for initialization
	void Start () {

		RefreshDisplay ();

		GameObject canvasObj = GameObject.FindGameObjectWithTag ("ChapterCanvas");
		if(canvasObj != null){
			screenW = canvasObj.GetComponent<RectTransform> ().rect.width;
		}

		chapterRequest = Singleton<ChapterHttpRequest>.Instance;
		chapterRequest.getAllChapter (this);
	}

	// Update is called once per frame
	void Update () {

	}

	void RefreshDisplay(){
		AddButtons ();
	}

	void AddButtons(){
		for(int i=0; i<chapters.Count; i++){
			Button bt = Instantiate (btn);
			bt.transform.SetParent (transform, true);
			//bt.GetComponent<RectTransform> ().SetPositionAndRotation (new Vector3(0, -i*150, 0), Quaternion.identity);
			bt.GetComponent<RectTransform> ().localPosition= new Vector3(0, -i*150, 0);
			RectTransform rt = bt.GetComponent<RectTransform> ();
			//			rt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Left, 0, 750);
			rt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Top, i*150, 150);

			ChapterItem item = bt.GetComponent<ChapterItem> ();
			ChapterModel model = chapters[i];
			item.Bind (model, this);
		}

		RectTransform rootRt = GetComponent<RectTransform> ();
		rootRt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Left, 0, screenW);
		rootRt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Top, 0, chapters.Count * 150);
	}

	public void DetailBtnClick(ChapterModel chapterModel){
		BattleController.chapterModel = chapterModel;
		SceneManager.LoadScene ("Battle");
	}

	public void GetAllChapterSuccess(List<ChapterModel> newChapters){
		chapters.Clear ();
		chapters.AddRange (newChapters);
		RefreshDisplay ();
	}
}
