using Dummiesman;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

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

    private void LoadTerrainInfoFromWeb(string response)
    {
        terrainModelDTO = JsonUtility.FromJson<TerrainModelDTO>(response);

        StartCoroutine(web.GetTerrainObj(terrainModelDTO.ObjUrl, (jsonString) => LoadTerrain(jsonString)));
    }

    private void LoadTerrain(string response)
    {
        textStream = new MemoryStream(Encoding.UTF8.GetBytes(response));
        mine = new OBJLoader().Load(textStream);

        StartCoroutine(web.LoadTextureFromUrl(terrainModelDTO.TextureUrl, (texture) => LoadTexture(texture)));
    }

    private void LoadTexture(Texture2D response)
    {
        mine.gameObject.transform.Find("default").GetComponent<Renderer>().material.mainTexture = response;
    }

}
