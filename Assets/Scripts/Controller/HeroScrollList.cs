using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroScrollList : MonoBehaviour, IHeroHttpRequestDelegate, IHeroItemDelegate {

	public Button btn;

	private HeroHttpRequest heroRequest;
	private List<HeroModel> heros = new List<HeroModel>();

	private float screenW;

	void Awake(){
		GameObject httpRequestObject = GameObject.FindGameObjectWithTag ("HeroHttpRequest");
		if (httpRequestObject != null) {
			heroRequest = httpRequestObject.GetComponent<HeroHttpRequest> ();
			heroRequest.GetAllHeroSuccess += GetAllHeroSuccess;
		} else {
			Debug.Log ("httpRequestObject is null");
		}
	}

	void OnDestroy(){
		heroRequest.GetAllHeroSuccess -= GetAllHeroSuccess;
	}

	// Use this for initialization
	void Start () {
		RefreshDisplay ();

		heroRequest.getAllHero ();

		GameObject canvasObj = GameObject.FindGameObjectWithTag ("HeroCanvas");
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
		for(int i=0; i<heros.Count; i++){
			Button bt = Instantiate (btn);
			bt.transform.SetParent (transform, true);
			//bt.GetComponent<RectTransform> ().SetPositionAndRotation (new Vector3(0, -i*150, 0), Quaternion.identity);
			bt.GetComponent<RectTransform> ().localPosition= new Vector3(0, -i*150, 0);
			RectTransform rt = bt.GetComponent<RectTransform> ();
//			rt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Left, 0, 750);
			rt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Top, i*150, 150);

			HeroItem item = bt.GetComponent<HeroItem> ();
			HeroModel model = heros[i];
			item.Bind (model, this);
		}
			
		RectTransform rootRt = GetComponent<RectTransform> ();
		rootRt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Left, 0, screenW);
		rootRt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Top, 0, heros.Count * 150);

	}

	public void DetailBtnClick(HeroModel heroModel){
		HeroDetailController.heroModel = heroModel;
		SceneManager.LoadScene ("HeroDetail");
	}

	public void GetAllHeroSuccess(List<HeroModel> newHeros){
		heros.Clear ();
		heros.AddRange (newHeros);
		RefreshDisplay ();
	}
}
