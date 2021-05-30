using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class movement : MonoBehaviour
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
        "\nHelp: mở bảng lệnh." +
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
        str = "Thủy pháo";
        str2 = "Được gắn trên tàu chiến, bảo vệ vùng biển.";
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = one.transform.position;
    }

    private void Two()
    {
        str = "Pháo tầm xa";
        str2 = "Định vị chính xác, tầm bắn rất xa.";
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = two.transform.position;
    }

    private void Three()
    {
        str = "Đạn thủy pháo";
        str2 = "Được phóng từ tàu chiến, công phá lớn.";
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = three.transform.position;
    }

    private void Four()
    {
        str = "Mô hình xe tăng xích";
        str2 = "Phổ biến trong chiến tranh thế giới thứ 1.";
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = four.transform.position;
    }

    private void Five()
    {
        str = "Mô hình xe tăng Anh quốc";
        str2 = "Phổ biến trong chiến tranh thế giới thứ 1.";
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = five.transform.position;
    }

    private void Six()
    {
        str = "Súng bắn tank";
        str2 = "Được quân đội Việt Nam đưa vào sử dụng rất hiệu quả.";
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = six.transform.position;
    }

    private void Seven()
    {
        str = "Bazooka";
        str2 = "Được lính Mỹ sử dụng nhiều.";
        SoundManager.instance.Play("Walk");
        isMoving = true;
        target = seven.transform.position;
    }

    private void Eight()
    {
        str = "Đầu thủy pháo";
        str2 = "Được gắn trên tàu chiến, bảo vệ vùng biển.";
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
        "\nHelp: mở bảng lệnh." +
        "\nExit game: đóng game." +
        "\n\nNói infor close để đóng bảng thông tin này.";
    }

    private void Exit()
    {
        Application.Quit();
    }
}
