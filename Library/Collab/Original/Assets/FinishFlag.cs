using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFlag : MonoBehaviour
{

    public GameObject confetti;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnTriggerEnter2D(Collider2D collider) {

        if (collider.gameObject.tag == "Player") {
            Instantiate(confetti, transform.position, Quaternion.identity);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        

    }
}
