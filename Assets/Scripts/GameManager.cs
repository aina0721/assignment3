using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject GameClearImage;
    public GameObject CorrectText;

    public float TimeCounter;

    public float Count = 0;

    public List<GameObject> gameObjectList = new List<GameObject>();

    public enum Quiz
    {
        one,
        two, 
        three,
        four, 
        five
    }
    public Quiz Number = Quiz.one;

    // ユーザーが文字を入力するための入力欄（InputField）を指定するための変数
    public InputField inputField;

    // 画面に文字を表示するためのTextを指定するための変数
    public Text displayText;

    // 入力された文字を表示する動きを作る関数
    public void DisplayInputText()
    {
        // 入力欄に入力された文字（inputField.text）を表示用のText（displayText.text）にコピー
        displayText.text = inputField.text;

        // ここで入力内容が表示される！
    }

    void Update()
    {
        switch (Number)
        {
            case Quiz.one:
                inputField.ActivateInputField(); // 入力フィールドを有効化し、選択状態にする
                if (inputField.text == ("アーモンド") || inputField.text == ("あーもんど"))
                {
                    Debug.Log("ok");
                    CorrectText.SetActive(true);
                    TimeCounter += Time.deltaTime;
                    if (TimeCounter >= 2.0f)
                    {
                        Number = Quiz.two;
                        TimeCounter = 0;
                    }
                }
                Debug.Log("一問目");
                break;
            case Quiz.two:
                gameObjectList[0].SetActive(false);
                gameObjectList[1].SetActive(true);
                gameObjectList[5].SetActive(false);
                gameObjectList[6].SetActive(true);
                CorrectText.SetActive(false);
                if (Count == 0)
                {
                    //InputField コンポーネントを取得
                    InputField form = GameObject.Find("InputField").GetComponent<InputField>();
                    form.text = "";
                    Count = 1;
                }
                if (inputField.text == ("トナカイ") || inputField.text == ("となかい"))
                {
                    CorrectText.SetActive(true);
                    TimeCounter += Time.deltaTime;
                    if (TimeCounter >= 2.0f)
                    {
                        Number = Quiz.three;
                        TimeCounter = 0;
                        Count = 0;
                    }
                }
                Debug.Log("二問目");
                break;
            case Quiz.three:
                gameObjectList[1].SetActive(false);
                gameObjectList[2].SetActive(true);
                gameObjectList[6].SetActive(false);
                gameObjectList[7].SetActive(true);
                CorrectText.SetActive(false);
                if (Count == 0)
                {
                    //InputField コンポーネントを取得
                    InputField form = GameObject.Find("InputField").GetComponent<InputField>();
                    form.text = "";
                    Count = 1;
                }
                if (inputField.text == ("ウツボ") || inputField.text == ("うつぼ"))
                {
                    Debug.Log("ok");
                    CorrectText.SetActive(true);
                    TimeCounter += Time.deltaTime;
                    if (TimeCounter >= 2.0f)
                    {
                        Number = Quiz.four;
                        TimeCounter = 0;
                        Count = 0;
                    }
                }
                Debug.Log("三問目");
                break;
            case Quiz.four:
                gameObjectList[2].SetActive(false);
                gameObjectList[3].SetActive(true);
                gameObjectList[7].SetActive(false);
                gameObjectList[8].SetActive(true);
                CorrectText.SetActive(false);
                if (Count == 0)
                {
                    //InputField コンポーネントを取得
                    InputField form = GameObject.Find("InputField").GetComponent<InputField>();
                    form.text = "";
                    Count = 1;
                }
                if (inputField.text == ("ツツジ") || inputField.text == ("つつじ"))
                {
                    Debug.Log("ok");
                    CorrectText.SetActive(true);
                    TimeCounter += Time.deltaTime;
                    if (TimeCounter >= 2.0f)
                    {
                        Number = Quiz.five;
                        TimeCounter = 0;
                        Count = 0;
                    }
                }
                Debug.Log("四問目");
                break;
            case Quiz.five:
                gameObjectList[3].SetActive(false);
                gameObjectList[4].SetActive(true);
                gameObjectList[8].SetActive(false);
                gameObjectList[9].SetActive(true);
                CorrectText.SetActive(false);
                if (Count == 0)
                {
                    //InputField コンポーネントを取得
                    InputField form = GameObject.Find("InputField").GetComponent<InputField>();
                    form.text = "";
                    Count = 1;
                }
                if (inputField.text == ("アボカド") || inputField.text == ("あぼかど"))
                {
                    Debug.Log("ok");
                    CorrectText.SetActive(true);
                    TimeCounter += Time.deltaTime;
                    if (TimeCounter >= 1.5f)
                    {
                        GameClearImage.SetActive(true);
                        TimeCounter = 0;
                    }
                }
                Debug.Log("五問目");
                break;
        }
    }
}
