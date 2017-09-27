using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductItem : MonoBehaviour {

	public Text itemText;
	public Text numText;

	private ProductModel productModel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Bind(ProductModel model){
		this.productModel = model;

		itemText.text = productModel.describ;
		numText.text = productModel.num == 0 ? "" : (productModel.num + "");
	}
}
