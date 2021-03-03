using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Get reports from server and delivers
/// </summary>
public class ReportsManager : MonoBehaviour
{
    private List<Report> reports;

    private Web web;

    private void Awake()
    {
        web = FindObjectOfType<Web>();
    }

    private void Start()
    {
        StartCoroutine(web.GetReports((jsonString) => GetReportsFromServer(jsonString)));
    }

    /// <summary>
    /// Populate the reports from server
    /// </summary>
    /// <param name="jsonString">json string response from server</param>
    private void GetReportsFromServer(string jsonString)
    {
        ReportsDTO ReportList = JsonUtility.FromJson<ReportsDTO>(jsonString);

        reports = ReportList.Reports;
    }

    /// <summary>
    /// Get the report with the given id
    /// </summary>
    /// <param name="shovelID">shovel id</param>
    /// <returns></returns>
    public Report GetReportByID(int shovelID)
    {
        return reports.Find((x) => x.ShovelID == shovelID);
    }
}
