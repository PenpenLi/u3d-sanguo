using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelectScrollList : MonoBehaviour, IHeroItemDelegate {

	public Button btn;

	private List<HeroModel> heros = new List<HeroModel>();
	private List<Button> btns = new List<Button>();

	private float screenW;

	public HeroSelectController heroSelectController;

	// Use this for initialization
	void Start () {
		GameObject canvasObj = GameObject.FindGameObjectWithTag ("HeroSelectCanvas");
		if(canvasObj != null){
			screenW = canvasObj.GetComponent<RectTransform> ().rect.width;
		}
	}

	// Update is called once per frame
	void Update () {

	}

	void RefreshDisplay(){
		AddButtons ();
	}

	void AddButtons(){
		foreach(Button bt in btns){
			Destroy (bt.gameObject);
		}
		btns.Clear ();

		for(int i=0; i<heros.Count; i++){
			Button bt = Instantiate (btn);
			btns.Add (bt);
			bt.transform.SetParent (transform, false);
			//bt.GetComponent<RectTransform> ().SetPositionAndRotation (new Vector3(0, -i*150, 0), Quaternion.identity);
//			bt.GetComponent<RectTransform> ().localPosition= new Vector3(0, -i*150, 0);
			RectTransform rt = bt.GetComponent<RectTransform> ();
			//			rt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Left, 0, 750);
			rt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Top, i*150, 150);

			HeroItem item = bt.GetComponent<HeroItem> ();
			HeroModel model = heros[i];
			item.Bind (model, this);
		}

		RectTransform rootRt = GetComponent<RectTransform> ();
		rootRt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Top, 0, heros.Count * 150);
	}

	public void DetailBtnClick(HeroModel heroModel){
		heroSelectController.SelectHero (heroModel);
	}
		
	public void RefreshHeros(List<HeroModel> newHeros){
		heros.Clear ();
		heros.AddRange (newHeros);
		RefreshDisplay ();
	}
}
