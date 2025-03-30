using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter new question text here!";

    [SerializeField] string[] answer = new string[4]; 

    [Range(0, 3)]
    [SerializeField] int correctIndex = 1;

    // [Header("xe cộ")]	

    // [Range(0, 100)]
    // [Tooltip("tốc độ của xe")]
    // [SerializeField] float speed;

    public string getQuestion() {
        return question;
    }

    public int GetCorrectAnswerIndex() {
        return correctIndex;
    }

    public string GetAnswer(int index) {
        return answer[index];
    }


}
