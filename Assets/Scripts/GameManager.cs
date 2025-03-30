using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    endScene endScene;

    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        endScene = FindObjectOfType<endScene>();
    }

    void Start()
    {
        quiz.gameObject.SetActive(true);
        endScene.gameObject.SetActive(false);
    }

    void Update()
    {
        if(quiz.isCompleted) {
            quiz.gameObject.SetActive(false);
            endScene.gameObject.SetActive(true);
            endScene.setTextScore();
        }
    }

    public void OnReplayLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
