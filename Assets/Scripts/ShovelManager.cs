using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Get shovels from server
/// </summary>
public class ShovelManager : MonoBehaviour
{
    public event Action<List<ShovelGO>> OnShovelsReady;

    [SerializeField] private GameObject shovelPrefab;

    private List<ShovelGO> shovels;

    private Web web;

    private void Awake()
    {
        web = FindObjectOfType<Web>();
        shovels = new List<ShovelGO>();
    }

    private void Start()
    {
        StartCoroutine(web.GetShovels((jsonString) => GetShovelsFromServer(jsonString)));
    }

    /// <summary>
    /// Populates the list of shovels from parsing the response from the server
    /// </summary>
    /// <param name="jsonString">json string response from server</param>
    private void GetShovelsFromServer(string jsonString)
    {
        ShovelsDTO shovelList = JsonUtility.FromJson<ShovelsDTO>(jsonString);
        foreach (var item in shovelList.Shovels)
        {
            GameObject shovel = Instantiate(shovelPrefab, item.Position, Quaternion.identity);
            ShovelGO shovelGO  = shovel.GetComponent<ShovelGO>();
            shovelGO.Setup(item);
            shovels.Add(shovelGO);
        }

        OnShovelsReady?.Invoke(shovels);
    }
}
