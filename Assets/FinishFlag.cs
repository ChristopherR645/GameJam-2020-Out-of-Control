using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFlag : MonoBehaviour
{

    public GameObject finish;
    public GameObject confettiParticles;
    public int numOfKeysRequired;
    public Sprite markerLit;
    private Sprite starting;
    private bool notLit = true;

    // Start is called before the first frame update
    void Start()
    {
        starting = this.gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (notLit)
        {
            CompareKeys();
        }

    }

    void CompareKeys()
    {
        int playerKeys = FindObjectOfType<MainPlayerScript>().numOfKeys;
        if(playerKeys == numOfKeysRequired)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = markerLit;
            notLit = false;
        }
        
    }

    public void ResetColor()
    {
        if(this.gameObject.GetComponent<SpriteRenderer>().sprite = markerLit)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = starting;
        }
    }


    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player" && numOfKeysRequired == FindObjectOfType<MainPlayerScript>().numOfKeys) {
            Debug.Log("hit marker with key");
            FindObjectOfType<AudioManager>().Play("Win");
            Instantiate(confettiParticles, transform.position, Quaternion.identity);
            finish.SetActive(true);
        }

    }
}
