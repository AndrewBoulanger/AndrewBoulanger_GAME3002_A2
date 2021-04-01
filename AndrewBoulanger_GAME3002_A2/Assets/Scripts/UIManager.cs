using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject instructionText = null;
    private bool InstructionTextActive = true;

    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private Text livesText = null;
    [SerializeField]
    private Text livesDisplay = null;

    private int score;


    // Start is called before the first frame update
    void Start()
    {
        BallBehaviour.OnRespawn = UpdateLives;
        Collidable.CollectPointsDelegate = UpdateScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (InstructionTextActive && Input.GetKeyUp(KeyCode.Space))
        {
            InstructionTextActive = false;
            instructionText.SetActive(false);
        }
    }

    void UpdateScore(int val)
    {
        score += val;
        scoreText.text = score.ToString();
    }

    void UpdateLives(int lives)
    {
        switch (lives)
        {
            case 1:
                livesText.color = Color.red;
                livesDisplay.color = Color.red;
                break;
            case 2:
                livesText.color = Color.yellow;
                livesDisplay.color = Color.yellow;
                break;
            case 3:
                livesText.color = Color.green;
                livesDisplay.color = Color.green;
                break;
            default:
                break;
        }

        string ballIcon = "";
        for (int i = 0; i < lives; i++)
        {
            ballIcon = ballIcon + "o ";
        }

        livesDisplay.text = ballIcon;
    }

    void ResetUI()
    {
       InstructionTextActive = true;
       instructionText.SetActive(true);

       score = 0;
       scoreText.text = score.ToString();

       UpdateLives(3);
    }
}
