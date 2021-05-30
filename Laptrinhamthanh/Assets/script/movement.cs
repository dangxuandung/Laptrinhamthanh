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
        keywords.Add("number one", One);
        keywords.Add("number two", Two);
        keywords.Add("number three", Three);
        keywords.Add("number four", Four);
        keywords.Add("number five", Five);
        keywords.Add("number six", Six);
        keywords.Add("number seven", Seven);
        keywords.Add("number eight", Eight);
        keywords.Add("go up", Up);
        keywords.Add("go down", Down);
        keywords.Add("music stop", MusicS);
        keywords.Add("music play", MusicP);

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

        SoundManager.instance.Play("Background");
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

        if (transform.position == target)
            SoundManager.instance.Pause("Walk");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Change")
        {
            Debug.Log("cleaded");
            keywords.Clear();
        }
    }

    private void One()
    {
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = one.transform.position;
    }

    private void Two()
    {
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = two.transform.position;
    }

    private void Three()
    {
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = three.transform.position;
    }

    private void Four()
    {
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = four.transform.position;
    }

    private void Five()
    {
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = five.transform.position;
    }

    private void Six()
    {
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = six.transform.position;
    }

    private void Seven()
    {
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = seven.transform.position;
    }

    private void Eight()
    {
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = eight.transform.position;
    }

    private void Up()
    {
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = up.transform.position;
    }

    private void Down()
    {
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = down.transform.position;
    }

    private void MusicS()
    {
        SoundManager.instance.Pause("Background");
    }

    private void MusicP()
    {
        SoundManager.instance.Play("Background");
    }
}
