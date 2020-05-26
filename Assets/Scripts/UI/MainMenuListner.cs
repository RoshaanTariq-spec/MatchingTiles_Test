using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuListner : MonoBehaviour
{
    public Transform scrollView_Content;

    public data friendsData;

    private void Start()
    {
        Toolbox.Soundmanager.PlayMusic_Menu();

        StartCoroutine(CR_GetFriends());
    }
    public void OnPress_Play() {

        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        Toolbox.GameManager.Load_GameScene();
    }

    [System.Obsolete]
    IEnumerator CR_GetFriends()
    {
        Dictionary<string, string> headers = new Dictionary<string, string>();

        headers.Add("x-rapidapi-host", "instagram-data1.p.rapidapi.com");
        headers.Add("x-rapidapi-key", "87f3b1724amsh9dc151f7f9e9ba4p12c3c3jsnfd32fb3a399b");
        headers.Add("useQueryString", "true");

        string url = "https://instagram-data1.p.rapidapi.com/likers?post=https%3A%2F%2Fwww.instagram.com%2Fp%2FCAVeEm1gDh2%2F?";

        WWW www = new WWW(url, null, headers);

        yield return www;

        //Debug.Log("Res = " + www.text);
        friendsData =  JsonUtility.FromJson<data>(www.text);

        Set_FriendsDataInView();
    }

    /// <summary>
    /// Instantiate the friends tile and set the required data in them
    /// </summary>
    private void Set_FriendsDataInView() {

        //If data is less than expectations.
        if (friendsData.collector.Length < Constants.maxFriendsDataToShow)
        {
            Debug.Log("Data is less than expectations.");

            for (int i = 0; i < friendsData.collector.Length; i++)
            {
                GameObject obj = (GameObject)Instantiate(Resources.Load(Constants.uiFolderPath + Constants.uiName_FriendsTile), Vector3.zero, Quaternion.identity, scrollView_Content);

                obj.GetComponent<FriendTileListner>().SetData(friendsData.collector[i].username, friendsData.collector[i].profile_pic_url);
            }

        }
        else {

            for (int i = 0; i < Constants.maxFriendsDataToShow; i++)
            {
                GameObject obj = (GameObject)Instantiate(Resources.Load(Constants.uiFolderPath + Constants.uiName_FriendsTile), Vector3.zero, Quaternion.identity, scrollView_Content);

                obj.GetComponent<FriendTileListner>().SetData(friendsData.collector[i].username, friendsData.collector[i].profile_pic_url);
            }
        }
    }
}
