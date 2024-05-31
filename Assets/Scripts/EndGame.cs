using DG.Tweening;

using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private GameObject endPanel;
    [SerializeField]
    private TextMeshProUGUI winnerText;
    [SerializeField]
    private TextMeshProUGUI statsText;
    private int drawCount;
    private int crossCount;
    private int circleCount;

    // Start is called before the first frame update
    void Start()
    {
        drawCount = PlayerPrefs.GetInt("DRAW");
        crossCount = PlayerPrefs.GetInt("CROSS");
        circleCount = PlayerPrefs.GetInt("CIRCLE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Display(CellStatus winner)
    {
        if (endPanel.activeInHierarchy == true)
        {
            return;
        }

        endPanel.SetActive(true);
        endPanel.GetComponent<CanvasGroup>().DOFade(1,1);
        if (winner == CellStatus.None)
        {
            winnerText.text = "Draw";
        }
        if (winner == CellStatus.Cross)
        {
            winnerText.text = "Cross Win";
        }
        if(winner == CellStatus.Circle)
        {
            winnerText.text = "Circle Win";
        }
        AddPoint(winner);
        Save();
        statsText.text = "Stats: " + "\n" + "Draw: " + drawCount + "\n" + "Cross: " + crossCount + "\n" + "Circle: " + circleCount;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("DRAW", drawCount);
        PlayerPrefs.SetInt("CROSS", crossCount);
        PlayerPrefs.SetInt("CIRCLE", circleCount);
        PlayerPrefs.Save();
    }
    public void AddPoint(CellStatus winner)
    {
        Debug.Log("Add point to " + winner);
        if (winner == CellStatus.None)
        {
            drawCount++;
        }
        if (winner == CellStatus.Cross)
        {
            crossCount++;
        }
        if (winner == CellStatus.Circle)
        {
            circleCount++;
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
