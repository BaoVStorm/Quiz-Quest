using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
// using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 15f;
    [SerializeField] float timeToShowCorrectAnswer = 5f;
    public bool isAnsweringQuestion;
    public bool loadNextQuestion;
    Image timerImage;
    public float timerValue;
    public float fillFraction = 0f;

    void Awake()
    {
        timerImage = this.transform.Find("timerCount").GetComponentInChildren<Image>();
    }

    void Start()
    {
        timerValue = timeToCompleteQuestion;
        isAnsweringQuestion = true;
        loadNextQuestion = true;
    }

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer() {
        timerValue = -1f;
    }

    void UpdateTimer() {
        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion) {
            if(timerValue > 0) {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else {
                timerValue = timeToShowCorrectAnswer;
                isAnsweringQuestion = false;
            }
        }
        else {
            if(timerValue <= 0f) {
                loadNextQuestion = true;
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
            }
            else {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
        }

        timerImage.fillAmount = fillFraction;
    }
}
