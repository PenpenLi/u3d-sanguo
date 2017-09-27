using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public interface IBagHttpRequestDelegate{
 	void GetAllProductSuccess(List<ProductModel> products);
}

public class BagHttpRequest : MonoBehaviour
{	
	private IBagHttpRequestDelegate bagController;

	public void GetAllProduct(IBagHttpRequestDelegate controller){
		bagController = controller;
		StartCoroutine (HttpGetAllProduct());
	}
		
	IEnumerator HttpGetAllProduct(){
		UnityWebRequest request = UnityWebRequest.Get ("http://127.0.0.1:8080/api/bag/product/all");
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {
			
		} else {
			if(request.responseCode == 200){
				string text = request.downloadHandler.text;
				Debug.Log (text);

				ResponseModel<List<ProductModel>> responseModel = JsonUtility.FromJson<ResponseModel<List<ProductModel>>> (text);
				if (responseModel.code == 200) {
					bagController.GetAllProductSuccess (responseModel.data);
				} else {
					
				}
			}
		}
	}


}

