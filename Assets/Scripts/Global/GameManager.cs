using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	[HideInInspector] public AsyncOperation async = null;


	void LateUpdate(){

		if (async != null) {

			if (async.progress == 1) {

				async = null;
			}
		}
	}

	public void Load_MenuScene(){

        StartCoroutine(CR_LoadScene(Constants.menuSceneIndex));
	}

	public void Load_GameScene(){

		StartCoroutine(CR_LoadScene(Constants.gameSceneIndex));
	}

	private IEnumerator CR_LoadScene(int _sceneindex) {

		InstantiateUI_Loading();

		async = SceneManager.LoadSceneAsync(_sceneindex);
		yield return async;
	}

    public bool IsNetworkAvailable()
	{
		if (Application.internetReachability == NetworkReachability.NotReachable)		
			return false;		
		else		
			return true;
	}

	#region UI_Instantiation

	public void InstantiateUI_MainMenu()
	{
		Instantiate(Resources.Load(Constants.uiFolderPath + Constants.uiName_MainMenu), Vector3.zero, Quaternion.identity);
	}

	public void InstantiateUI_HUD()
	{
		Instantiate(Resources.Load(Constants.uiFolderPath + Constants.uiName_HUD), Vector3.zero, Quaternion.identity);
	}

	public void InstantiateUI_Loading()
	{
		Instantiate(Resources.Load(Constants.uiFolderPath + Constants.uiName_Loading), Vector3.zero, Quaternion.identity);
	}

	#endregion




	void OnApplicationFocus(bool focus){
	
		if (!focus) {

            Debug.Log("Out of fucus");
		}
	}

	void OnApplicationQuit(){
    }
}
