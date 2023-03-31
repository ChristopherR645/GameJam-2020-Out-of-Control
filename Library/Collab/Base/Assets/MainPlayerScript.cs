using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPlayerScript : MonoBehaviour
{
    private ArrayList leftArray = new ArrayList();
    private ArrayList rightArray = new ArrayList();
    private ArrayList jumpArray = new ArrayList();

    public GameObject deathParticles;
    public int numOfKeys = 0;

    private int counter;
    private int counter2;

    private bool reset;
    public GameObject startingPoint;

    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int maxAttempts;
    public int currentAttempts;
    private bool record = false;
    private bool play = false;
    private bool finish = false;

    public Image leftArrow;
    public Image upArrow;
    public Image rightArrow;



    // Start is called before the first frame update
    void Start()
    {
        finish = false;
        reset = false;
        rb = GetComponent<Rigidbody2D>();
        counter = 0;
        counter2 = 0;

        leftArrow.GetComponent<Image>();
        upArrow.GetComponent<Image>();
        rightArrow.GetComponent<Image>();
    }

    // Update is called once per frame 
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.O))//Record
        {
            if (record == false && play == false)
            {
                Debug.Log("Recording");
                currentAttempts++;
                Debug.Log(currentAttempts);
                record = true;
                if (currentAttempts> maxAttempts)
                {
                    ResetGame();
                }
                
            }
        }
        if (Input.GetKeyDown(KeyCode.R))//Rest
        {
            reset = true;
            ResetGame();
        }
        if (Input.GetKeyDown(KeyCode.P))//Play
        {
            Debug.Log("Playing");
            record = false;
            play = true;
        }

        if (record)//Code for Getting the inputs from the use and Storing it
        {
            counter++;

            if (Input.GetKey(KeyCode.LeftArrow)) {
                leftArray.Add("1");
                leftArrow.color = new Color(leftArrow.color.r, leftArrow.color.g, leftArrow.color.b, 0.8f);
            }
            else {
                leftArray.Add("0");
                Debug.Log("changing color for left");
                leftArrow.color = new Color(leftArrow.color.r, leftArrow.color.g, leftArrow.color.b, 0.1f);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                rightArray.Add("1");
                rightArrow.color = new Color(rightArrow.color.r, rightArrow.color.g, rightArrow.color.b, 0.8f);
            }
            else
            {
                rightArray.Add("0");
                rightArrow.color = new Color(rightArrow.color.r, rightArrow.color.g, rightArrow.color.b, 0.1f);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                jumpArray.Add("1");
                upArrow.color = new Color(upArrow.color.r, upArrow.color.g, upArrow.color.b, 0.8f);
            }
            else
            {
                jumpArray.Add("0");
                upArrow.color = new Color(upArrow.color.r, upArrow.color.g, upArrow.color.b, 0.1f);
            }
        }

        if (play)//Code for Replaying inputs and Moving
        {
            counter2++;
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

            if (counter2 > counter && Input.GetKeyDown(KeyCode.R))
            {
                reset = false;
                ResetGame();
            }

            if (counter2 < counter)
            {
                if (rightArray[counter2].Equals("1"))
                {
                    MoveRight();
                }
                if (leftArray[counter2].Equals("1"))
                {
                    MoveLeft();
                }
                if (jumpArray[counter2].Equals("1") && isGrounded == true)
                {
                    FindObjectOfType<AudioManager>().Play("Jump");
                    rb.velocity = Vector2.up * jumpForce;
                }
            }
            else
            {
                play = false;
                record = false;
            }
        }

    }

    public void MoveRight()
    {
        Debug.Log("in MoveRight ");
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    public void StopMove()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Marker")
        {
            FindObjectOfType<AudioManager>().Play("Win");
            finish = true;
        }
        if (collider.gameObject.tag == "Spikes")
        {
            FindObjectOfType<AudioManager>().Play("Death");
            Instantiate(deathParticles, this.transform.position, Quaternion.identity);
            ResetGame();
        }
        if (collider.gameObject.tag == "Key")
        {
            numOfKeys = numOfKeys + 1;
            Destroy(collider.gameObject);
            /*Debug.Log("keyGet");
            collider.gameObject.SetActive(false);
            collider.GetComponent<CapsuleCollider2D>().enabled = false;
            numOfKeys++;*/
        }
    }


    public void ResetGame()
    {
        counter = 0;
        counter2 = 0;

        play = false;
        record = false;
        reset = false;
        currentAttempts = 0;

        leftArray = new ArrayList();
        rightArray = new ArrayList();
        jumpArray = new ArrayList();
        rb.transform.position = new Vector2(startingPoint.transform.position.x, startingPoint.transform.position.y);
        StopMove();
    }


    public int getMaxAttempts() {
        return maxAttempts;
    }

    public int getCurrentAttempts() {
        return currentAttempts;
    }

    public bool getPlay() {
        return play;
    }

    public bool getRecord() {
        return record;
    }

    public bool getFinish() {
        return finish;
    }
}
