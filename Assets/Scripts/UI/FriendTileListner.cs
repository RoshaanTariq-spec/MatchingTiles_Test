using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FriendTileListner : MonoBehaviour
{
    public Text nameTxt;
    public RawImage profileImage;

    public void SetData(string _name, string _profilePicUrl) {

        nameTxt.text = _name;

        StartCoroutine(Set_ProfileImg(_profilePicUrl));

    }

    IEnumerator Set_ProfileImg(string _url)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(_url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            profileImage.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }

}
