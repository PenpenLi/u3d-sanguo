using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroIntoScrollList : MonoBehaviour {

	private List<ProductModel> productList;
	private List<Image> items;

	public Image pref;

	// Use this for initialization
	void Start () {
		items = new List<Image> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void RefreshDisplay(){
		foreach(Image bt in items){
			Destroy (bt.gameObject);
		}
		items.Clear ();
		if(productList != null){
			foreach(ProductModel product in productList){
				Image bt = Instantiate (pref);
				items.Add (bt);
				bt.transform.SetParent (transform, true);

				HeroIntoItem item = bt.GetComponent<HeroIntoItem> ();
				item.Bind (product);
			}
		}
	}

	public void RefreshProducts(List<ProductModel> products){
		this.productList = products;
		RefreshDisplay ();
	}
}
