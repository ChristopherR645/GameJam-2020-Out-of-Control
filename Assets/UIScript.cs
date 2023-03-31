using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public MainPlayerScript main;
    public TextMeshProUGUI numOfAttempts;
    public TextMeshProUGUI action;
    public TextMeshProUGUI level;
    // Start is called before the first frame update

    void Start()
    {
        numOfAttempts.text = "Num of Recordings: " + main.getMaxAttempts();
        action.text = "Waiting";
    }

    // Update is called once per frame
    void Update()
    {
        numOfAttempts.text = "Num of Recordings: " + (main.getMaxAttempts() - main.getCurrentAttempts());

        if (main.getRecord() == true) {
            action.text = "Recording";
        }

        if (main.getPlay() == true) {
            action.text = "Playing";
        }

        if (main.getPlay() == false && main.getRecord() == false) {
            action.text = "Waiting";
        }

        level.text = SceneManager.GetActiveScene().name;
    }
}
