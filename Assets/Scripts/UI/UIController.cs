using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text textCoint;
    [SerializeField] private Image powerWhile;

    [SerializeField] private Slider progressSlider;


    [SerializeField] GameObject UIFinalSlider;
    [SerializeField] GameObject UIimage;

    [SerializeField] GameObject buttonStart;

    private void OnEnable()
    {
        GameController.ScoreEventHandler += UIUpdateScore;
        GameController.PowerEventHandler += UIUpdatePower;
        GameController.DistanceEventHandler += UIUpdateProgress;
    }

    private void OnDisable()
    {
        GameController.ScoreEventHandler -= UIUpdateScore;
        GameController.PowerEventHandler -= UIUpdatePower;
        GameController.DistanceEventHandler -= UIUpdateProgress;
    }

    public void UIShowFinish()
    {
        UIFinalSlider.SetActive(true);
    }

    public void OffUI()
    {
        UIFinalSlider.SetActive(false);
        UIimage.SetActive(false);
    }
    public void OffButton()
    {
        buttonStart.SetActive(false);
    }

    //-------------------------------------------
    private void UIUpdateScore(int value)
    {
        textCoint.text = "---";
    }

    private void UIUpdateProgress(float value)
    {
        progressSlider.value = value;
    }

    private void UIUpdatePower(float value)
    {
        powerWhile.fillAmount = value / 3;
    }

}
