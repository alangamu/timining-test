using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Handles the interaction with the server
/// </summary>
public class Web : MonoBehaviour
{
    [SerializeField] private string mineModelURL = "https://unity-exercise.dt.timlabtesting.com/data/mesh-obj";
    [SerializeField] private string shovelsURL = "https://unity-exercise.dt.timlabtesting.com/data/shovels";
    [SerializeField] private string reportsURL = "https://unity-exercise.dt.timlabtesting.com/data/report";

    /// <summary>
    /// Get the texture from the server
    /// </summary>
    /// <param name="url">texture url</param>
    /// <param name="action">callback with the response</param>
    /// <returns>Coroutine</returns>
    public IEnumerator LoadTextureFromUrl(string url, Action<Texture2D> action = null)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
            Debug.Log(www.error);
        else
        {
            action?.Invoke(((DownloadHandlerTexture)www.downloadHandler).texture);
        }
    }

    /// <summary>
    /// Get the terrain mesh from server
    /// </summary>
    /// <param name="url">terrain mesh url</param>
    /// <param name="action">callback with the response</param>
    /// <returns>Coroutine</returns>
    public IEnumerator GetTerrainObj(string url, Action<string> action = null)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            action?.Invoke(www.downloadHandler.text);
        }
    }

    /// <summary>
    /// Get the terrain info from server
    /// </summary>
    /// <param name="action">callback with the response</param>
    /// <returns>Coroutine</returns>
    public IEnumerator GetTerrainInfo(Action<string> action = null)
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post(mineModelURL, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                action?.Invoke(www.downloadHandler.text);
            }
        }
    }

    /// <summary>
    /// Get the shovels from server
    /// </summary>
    /// <param name="action">callback with the response</param>
    /// <returns>Coroutine</returns>
    public IEnumerator GetShovels(Action<string> action = null)
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post(shovelsURL, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                action?.Invoke(www.downloadHandler.text);
            }
        }
    }

    /// <summary>
    /// Get reports from server
    /// </summary>
    /// <param name="action">callback with the response</param>
    /// <returns>Coroutine</returns>
    public IEnumerator GetReports(Action<string> action = null)
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post(reportsURL, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                action?.Invoke(www.downloadHandler.text);
            }
        }
    }

}
