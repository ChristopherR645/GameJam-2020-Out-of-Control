using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testingscript : MonoBehaviour
{
    private ArrayList leftArray = new ArrayList();
    private ArrayList rightArray = new ArrayList();
    private ArrayList jumpArray = new ArrayList();

    private int counter;


    // Start is called before the first frame update
    void Start() {
        counter++;

        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            Debug.Log("Added 1 to leftArrow");
            leftArray.Add(1);
        }
        else {
            Debug.Log("Added 0 to leftArrow");
            leftArray.Add(0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Debug.Log("Added 1 to rightArrow");
            rightArray.Add(1);
        }
        else {
            Debug.Log("Added 0 to rightArrow");
            rightArray.Add(0);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Added 1 to Space");
            jumpArray.Add(1);
        }
        else {
            Debug.Log("Added 0 to Space");
            jumpArray.Add(0);
        }

    }

    // Update is called once per frame 
    void Update()
    {
        
    }
}
