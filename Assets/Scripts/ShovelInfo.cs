using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays the information of the shovel, 
/// this class is attached to the UI report element
/// </summary>
public class ShovelInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text shovelNameText;
    [SerializeField] private TMP_Text comparisionText;
    [SerializeField] private TMP_Text performanceText;
    [SerializeField] private TMP_Text plannedPerformanceText;
    [SerializeField] private Transform statesContent;
    [SerializeField] private GameObject stateUIPrefab;
    [SerializeField] private Image performanceBarImage;

    private ReportsManager reportsManager;

    private void Awake()
    {
        reportsManager = FindObjectOfType<ReportsManager>();
    }

    /// <summary>
    /// Display the information of the selected shovel
    /// </summary>
    /// <param name="shovel">shovel info to display</param>
    public void Setup(Shovel shovel)
    {
        shovelNameText.text = shovel.Name;
        Report report = reportsManager.GetReportByID(shovel.ID);

        if (report != null)
        {
            comparisionText.text = $"{100 * report.Performance / report.PlannedPerformance} %";
            performanceBarImage.fillAmount = report.Performance / report.PlannedPerformance;
            performanceText.text = report.Performance.ToString();
            plannedPerformanceText.text = report.PlannedPerformance.ToString();

            foreach (Transform item in statesContent)
            {
                Destroy(item.gameObject);
            }

            foreach (var item in report.LastStates)
            {
                GameObject stateUI = Instantiate(stateUIPrefab, statesContent);
                stateUI.GetComponent<ShovelStateUI>().Setup(item);
            }
        }
    }


}
