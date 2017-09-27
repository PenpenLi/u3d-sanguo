using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagScrollList : MonoBehaviour {

	private List<ProductModel> productList;

	public Image panel;

	// Use this for initialization
	void Start () {
		RefreshDisplay ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RefreshDisplay(){
		if(productList != null){
			foreach(ProductModel product in productList){
				Image pl = Instantiate (panel);
				pl.transform.SetParent (transform, true);

				ProductItem item = pl.GetComponent<ProductItem> ();
				item.Bind (product);
			}
			// 补全最后一行
			int offset = 4 - productList.Count % 4;
			for(int i=0; i<offset; i++){
				Image pl = Instantiate (panel);
				pl.transform.SetParent (transform, true);

				ProductItem item = pl.GetComponent<ProductItem> ();
				item.Bind (new ProductModel());
			}
		}
	}

	public void RefreshProduct(List<ProductModel> products){
		this.productList = products;
		RefreshDisplay ();
	}
}
