using System.Collections;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CommonMethods : MonoBehaviour
{
    [Header("Values")]
    public float runAfterTime = 0;

    [Header("Events")]
    public UnityEvent OnStart;

    private void Start()
    {
        if (OnStart == null)
            OnStart = new UnityEvent();

        StartCoroutine(FireEvent());
    }

    IEnumerator FireEvent() {

        yield return new WaitForSeconds(runAfterTime);

        OnStart.Invoke();
    }

    public void LoadLevel(string _sceneName) {

        SceneManager.LoadScene(_sceneName);    
    }

    public void LoadLevel(int _sceneIndex)
    {
        SceneManager.LoadScene(_sceneIndex);
    }

    public void InstantiateFromResources(string _path)
    {
        Instantiate(Resources.Load(_path), Vector3.zero, Quaternion.identity);
    }

    public void InstantiateUI_MainMenu()
    {
        Toolbox.GameManager.InstantiateUI_MainMenu();
    }

    public void InstantiateUI_HUD()
    {
        Toolbox.GameManager.InstantiateUI_HUD();
    }
    public void InstantiateUI_Loading()
    {
        Toolbox.GameManager.InstantiateUI_Loading();
    }
}
