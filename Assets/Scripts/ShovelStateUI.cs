using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Report details class, attached to prefab
/// </summary>
public class ShovelStateUI : MonoBehaviour
{
    [SerializeField] private TMP_Text startText;
    [SerializeField] private TMP_Text endText;
    [SerializeField] private TMP_Text stateNameText;
    [SerializeField] private Image indicatorImage;

    /// <summary>
    /// Display the report information
    /// </summary>
    /// <param name="state">information to display</param>
    public void Setup(LastStatesClass state)
    {
        startText.text = state.Start;
        endText.text = state.End;
        stateNameText.text = state.Name;
        Color color;
        if (ColorUtility.TryParseHtmlString(state.Color, out color))
        {
            indicatorImage.color = color;
        }
    }
}
