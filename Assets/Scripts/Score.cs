using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int totalAnswer = 1;
    public int numberCorrectAnswer = 0;
    int finalScore = 0;

    public TextMeshProUGUI textScores;

    void Awake()
    {
        textScores = this.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        UpdateScore();
    }

    public void setTotalAnswer(int totalAnswer) {
        this.totalAnswer = totalAnswer;
    }

    public void IncreaseCorrectAnswer() {
        numberCorrectAnswer++;
        UpdateScore();
    }

    void UpdateScore() {
        float score = 100 * ((float) numberCorrectAnswer / totalAnswer);
        finalScore = (int) score;
        textScores.text = "Score: " + (int)score + "%";
    }

    public int GetFinalScore() {
        return finalScore;
    } 
}
