using Dummiesman;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

/// <summary>
/// Main class, load the terrain and the texture
/// </summary>
public class MainHandler : MonoBehaviour
{
    public List<Report> reports;

    private MemoryStream textStream;
    private GameObject mine;

    private Web web;
    private TerrainModelDTO terrainModelDTO;

    private void Awake()
    {
        web = FindObjectOfType<Web>();
    }

    void Start()
    {
        StartCoroutine(web.GetTerrainInfo((jsonString) => LoadTerrainInfoFromWeb(jsonString)));
    }

    /// <summary>
    /// Store the information of the model to download
    /// </summary>
    /// <param name="response">string response from server</param>
    private void LoadTerrainInfoFromWeb(string response)
    {
        terrainModelDTO = JsonUtility.FromJson<TerrainModelDTO>(response);

        StartCoroutine(web.GetTerrainObj(terrainModelDTO.ObjUrl, (jsonString) => LoadTerrain(jsonString)));
    }

    /// <summary>
    /// Load the terrain mesh, then load the texture 
    /// </summary>
    /// <param name="response">string model respornse from server</param>
    private void LoadTerrain(string response)
    {
        textStream = new MemoryStream(Encoding.UTF8.GetBytes(response));
        mine = new OBJLoader().Load(textStream);

        StartCoroutine(web.LoadTextureFromUrl(terrainModelDTO.TextureUrl, (texture) => SetTerrainTexture(texture)));
    }

    /// <summary>
    /// Set the texture response to the terrain game object
    /// </summary>
    /// <param name="response">texture2D response from server</param>
    private void SetTerrainTexture(Texture2D response)
    {
        mine.gameObject.transform.Find("default").GetComponent<Renderer>().material.mainTexture = response;
    }
}
