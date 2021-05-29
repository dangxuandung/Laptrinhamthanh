using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;

public class movement : MonoBehaviour
{
    [SerializeField]
    private GameObject one, two, three, four, five, six, seven, eight, up, down;

    private float speed = 60;
    private Vector3 target;
    private bool isMoving = false;

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    private void Start()
    {
        keywords.Add("one", One);
        keywords.Add("two", Two);
        keywords.Add("three", Three);
        keywords.Add("four", Four);
        keywords.Add("five", Five);
        keywords.Add("six", Six);
        keywords.Add("seven", Seven);
        keywords.Add("eight", Eight);
        keywords.Add("up", Up);
        keywords.Add("down", Down);

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void Update()
    {
        if (isMoving)
        {
            Move();
        }
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        keywords[speech.text].Invoke();
    }

    private void Move()
    {
        if(target == transform.position)
        {
            isMoving = false;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.gameObject.tag == "Change")
            {
                Debug.Log("cleaded");
                keywords.Clear();
            }
        }

    }

    private void One()
    {
        isMoving = true;
        target = one.transform.position;
    }

    private void Two()
    {
        isMoving = true;
        target = two.transform.position;
    }

    private void Three()
    {
        isMoving = true;
        target = three.transform.position;
    }

    private void Four()
    {
        isMoving = true;
        target = four.transform.position;
    }

    private void Five()
    {
        isMoving = true;
        target = five.transform.position;
    }

    private void Six()
    {
        isMoving = true;
        target = six.transform.position;
    }

    private void Seven()
    {
        isMoving = true;
        target = seven.transform.position;
    }

    private void Eight()
    {
        isMoving = true;
        target = eight.transform.position;
    }

    private void Up()
    {
        isMoving = true;
        target = up.transform.position;
    }

    private void Down()
    {
        isMoving = true;
        target = down.transform.position;
    }
}
