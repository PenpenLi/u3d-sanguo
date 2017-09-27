using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightScrollList : MonoBehaviour {

	public Text txt;
	public Scrollbar scrollBar;

	private List<FightItemModel> fightItems = new List<FightItemModel>();

	private float screenW;

	// Use this for initialization
	void Start () {
		GameObject canvasObj = GameObject.FindGameObjectWithTag ("FightCanvas");
		if(canvasObj != null){
			screenW = canvasObj.GetComponent<RectTransform> ().rect.width;
		}
	}

	// Update is called once per frame
	void Update () {

	}

	void RefreshDisplay(){
		AddItems ();
	}

	void AddItems(){
		for(int i=0; i<fightItems.Count; i++){
			Text itemText = Instantiate (txt);
			itemText.transform.SetParent (transform, false);
			RectTransform rt = itemText.GetComponent<RectTransform> ();
			rt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Top, i*150, 150);

			FightItem item = itemText.GetComponent<FightItem> ();
			FightItemModel model = fightItems[i];
			item.Bind (model, this);
		}

		RectTransform rootRt = GetComponent<RectTransform> ();
		rootRt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Top, 0, fightItems.Count * 150);

		scrollBar.value = 0.001f;
	}

	void AddLastItem(FightItemModel model){
		int i = fightItems.Count;

		Text itemText = Instantiate (txt);
		itemText.transform.SetParent (transform, false);
		RectTransform rt = itemText.GetComponent<RectTransform> ();
		rt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Top, i*150, 150);

		FightItem item = itemText.GetComponent<FightItem> ();
		item.Bind (model, this);

		RectTransform rootRt = GetComponent<RectTransform> ();
		rootRt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Top, 0, fightItems.Count * 150);

		scrollBar.value = 0.001f;
	}

	public void RefreshFightItems(List<FightItemModel> items){
		fightItems = items;
		RefreshDisplay ();
	}

	public void AddFightItem(FightItemModel item){
		fightItems.Add (item);
		AddLastItem (item);
	}
		
}
