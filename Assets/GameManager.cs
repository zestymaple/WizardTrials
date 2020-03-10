using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject scoreTextObject;
    int score;
    Text scoreText;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        scoreText = scoreTextObject.GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    public void Collect(int passedValue, GameObject passedObject)
    {
        passedObject.GetComponent<Renderer>().enabled = false;
        //passedObject.GetComponent<Collider>().enabled = false;
        //Destroy(passedObject, 1.0f);
        score = score + passedValue;
        scoreText.text = "Score: " + score.ToString();
    }
}
