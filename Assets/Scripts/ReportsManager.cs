using System.Collections.Generic;
using UnityEngine;

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

    private void GetReportsFromServer(string jsonString)
    {
        ReportsDTO ReportList = JsonUtility.FromJson<ReportsDTO>(jsonString);

        reports = ReportList.Reports;
    }

    public Report GetReportByID(int shovelID)
    {
        return reports.Find((x) => x.ShovelID == shovelID);
    }

}
