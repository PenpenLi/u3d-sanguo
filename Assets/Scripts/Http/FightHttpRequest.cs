using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public interface IFightHttpRequestDelegate{
	void FightSuccess (List<FightItemModel> fightItems);
}

public class FightHttpRequest : MonoBehaviour {

	private IFightHttpRequestDelegate fightController;

	public void FightBattle(int battleId, IFightHttpRequestDelegate controller){
		fightController = controller;
		StartCoroutine (HttpFightBattle(battleId));
	}

	IEnumerator HttpFightBattle(int battleId){
		WWWForm paras = new WWWForm ();
		paras.AddField ("battleId", battleId);
		UnityWebRequest request = UnityWebRequest.Post ("http://127.0.0.1:8080/api/fight/pve/battle", paras);
		string token = PlayerPrefs.GetString (PrefDefine.PP_USER_SESSION_TOKEN);
		request.SetRequestHeader ("session_id", token);
		yield return request.Send ();

		if (request.isNetworkError) {

		} else {
			if(request.responseCode == 200){
				string text = request.downloadHandler.text;
				Debug.Log (text);

				ResponseModel<List<FightItemModel>> responseModel = JsonUtility.FromJson<ResponseModel<List<FightItemModel>>> (text);
				if (responseModel.code == 200) {
					fightController.FightSuccess (responseModel.data);
				} else {

				}
			}
		}
	}
}
