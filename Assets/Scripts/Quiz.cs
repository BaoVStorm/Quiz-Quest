using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] 
    List<QuestionSO> questions;
    QuestionSO quesSO;

    TextMeshProUGUI question;

    Button[] answerButton;

    [Header("Button Colors")]
    [SerializeField] Sprite wrongAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite defaultAnswerSprite;

    [Header("Timer")]
    public Timer timer;

    bool HasEarlyAnswer = false;

    Score score;
    Slider slider;

    public bool isCompleted = false;

    void Awake()
    {
        timer = GetComponentInChildren<Timer>();
        
        score = GetComponentInChildren<Score>();
        score.setTotalAnswer(questions.Count);

        slider = GetComponentInChildren<Slider>();
    }

    void Start()
    {        
        slider.maxValue = questions.Count;
        slider.value = 0;
    }

    void Update()
    {
        if(timer.loadNextQuestion) {
            timer.loadNextQuestion = false;
            HasEarlyAnswer = false;
            goToNextQuestion();
        }
        else 
        if(!HasEarlyAnswer && !timer.isAnsweringQuestion) {
            displayButton(-1);
            setButtonState(false);
        }
    }

    public void clickButton(int index) {
        displayButton(index);

        HasEarlyAnswer = true;

        timer.CancelTimer();

        setButtonState(false);
    }

    void displayButton(int index) {
        int correctAnsIndex = quesSO.GetCorrectAnswerIndex();

        answerButton[correctAnsIndex].GetComponent<Image>().sprite = correctAnswerSprite;

        if(index == -1) {
            question.text = "Time UP! Correct Answer is: " + quesSO.GetAnswer(correctAnsIndex);
        }
        else
        if(index == correctAnsIndex) {
            question.text = "Correct Answer!!";

            score.IncreaseCorrectAnswer();
        }
        else {
            answerButton[index].GetComponent<Image>().sprite = wrongAnswerSprite;

            question.text = "Wrong answer!! Correct Answer is: " + quesSO.GetAnswer(correctAnsIndex);
        }

        // if(slider.value == slider.maxValue) {
        //     isCompleted = true;
        // }
    }


    void getRandomQuestion() {
        int index = Random.Range(0, questions.Count);

        quesSO = questions[index];

        if(questions.Contains(quesSO)) {
            questions.Remove(quesSO);
        }
    }

    void goToNextQuestion() {
        if(questions.Count > 0) {

            getRandomQuestion();    
            displayQuestion();
            setDefaultSprite();
            setButtonState(true);

            slider.value++;
        }
        else {
            isCompleted = true;
        }
    }

    void displayQuestion() {

        question = this.transform.Find("Question").GetComponent<TextMeshProUGUI>();

        question.text = quesSO.getQuestion();

        // answer button
        answerButton = this.transform.Find("AnswerButtonGroup").GetComponentsInChildren<Button>();

        for(int i = 0; i < answerButton.Length; i++) {

            TextMeshProUGUI answerText;
            answerText = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            answerText.text = quesSO.GetAnswer(i);
        }
    }

    void setButtonState(bool state) {
        for(int i = 0; i < answerButton.Length; i++) {
            Button button = answerButton[i].GetComponentInChildren<Button>();
            button.interactable = state;
        }
    }

    void setDefaultSprite() {
        for(int i = 0; i < answerButton.Length; i++) {
            answerButton[i].GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }
}
