using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class movementFl1 : MonoBehaviour
{
    [SerializeField]
    private GameObject one, two, three, four, five, six, seven, eight, up, down;
    [SerializeField]
    private Text text, text2;

    private string str = "Hướng dẫn";
    private string str2 = "Các lệnh:" +
        "\nNumber One đến Eight: di chuyển đền vị trí tương ứng." +
        "\nGo up: lên tầng." +
        "\nGo down: xuống tầng." +
        "\nMusic play: chơi nhạc." +
        "\nMusic stop: tắt nhạc." +
        "\nInfor open: mở bảng thông tin." +
        "\nInfor close: đóng bảng thông tin." +
        "\nExit game: đóng game." +
        "\n\nNói infor close để đóng bảng thông tin này.";
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
        keywords.Add("infor open", InforO);
        keywords.Add("infor close", InforC);
        keywords.Add("help", Help);
        keywords.Add("exit game", Exit);

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

        SoundManager.instance.Play("Background");

        text.text = str;
        text2.text = str2;
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
        str = "AK-47";
        str2 = "Khẩu súng huyền thoại, thân thuộc với người lính Việt Nam.";
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = one.transform.position;
    }

    private void Two()
    {
        str = "Bazooka, Lục côn bỏ túi";
        str2 = "Súng bắn tank, bắn máy bay địch. " +
            "\nVũ khí cá nhân, dùng để tự vệ.";
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = two.transform.position;
    }

    private void Three()
    {
        str = "Súng Kíp của dân tộc Dao, Đạn pháo, Lục mạ vàng của tướng địch";
        str2 = "Người Dao rất giỏi làm, sử dụng súng kíp." +
            "\nĐạn pháo bắn phương tiện của kẻ địch." +
            "\nHiện vật của cuộc đột kích và bắt giữ. ";
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = three.transform.position;
    }

    private void Four()
    {
        str = "Súng bắn tỉa";
        str2 = "Được dùng để bảo vệ, tấn công mục tiêu ở xa.";
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = four.transform.position;
    }

    private void Five()
    {
        str = "RPK";
        str2 = "Súng trung liên, dùng để phòng thủ căn cứ.";
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = five.transform.position;
    }

    private void Six()
    {
        str = "Tâm ngắm, Dao , Súng Lục";
        str2 = "Tâm ngắm được gắn vào súng, tăng độ chính xác.";
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = six.transform.position;
    }

    private void Seven()
    {
        str = "Tâm ngắm, Dao găm, súng tiểu liên mp-40";
        str2 = "Được sản xuất ở Đức, mp-40 nổi tiếng với sự ổn định đáng tin cậy.";
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = seven.transform.position;
    }

    private void Eight()
    {
        str = "Súng trường M4";
        str2 = "Vũ khí phổ thông của lính Mỹ tại Việt Nam.";
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

    private void InforO()
    {
        text.text = str;
        text2.text = str2;
    }

    private void InforC()
    {
        text.text = "";
        text2.text = "";
    }

    private void Help()
    {
        text.text = "Hướng dẫn";
        text2.text = "Các lệnh:" +
        "\nNumber One đến Eight: di chuyển đền vị trí tương ứng." +
        "\nGo up: lên tầng." +
        "\nGo down: xuống tầng." +
        "\nMusic play: chơi nhạc." +
        "\nMusic stop: tắt nhạc." +
        "\nInfor open: mở bảng thông tin." +
        "\nInfor close: đóng bảng thông tin." +
        "\nExit game: đóng game." +
        "\n\nNói infor close để đóng bảng thông tin này.";
    }

    private void Exit()
    {
        Application.Quit();
    }
}
