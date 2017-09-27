using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BagController : MonoBehaviour, IBagHttpRequestDelegate {

	public Button backBtn;
	public ScrollRect content;

	private BagHttpRequest bagRequest;

	private BagScrollList bagScrollList;

	// Use this for initialization
	void Start () {

		backBtn.onClick.AddListener (BackClick);

		bagRequest = Singleton<BagHttpRequest>.Instance;
		bagRequest.GetAllProduct (this);

		bagScrollList = content.viewport.GetComponentInChildren<BagScrollList> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void BackClick(){
		SceneManager.LoadScene ("Main");
	}

	//
	public void GetAllProductSuccess(List<ProductModel> products){
		bagScrollList.RefreshProduct (products);
	}
}
