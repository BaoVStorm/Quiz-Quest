using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class endScene : MonoBehaviour
{
    Score score;
    [SerializeField] TextMeshProUGUI textEnd;

    void Awake()
    {
        score = FindObjectOfType<Score>();

        // setTextScore();
    }


    public void setTextScore() {
        textEnd.text = "Congratulations!\nYour score " + score.GetFinalScore() + "%";
    }
}
