using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PipeManager _pipeMgr;

    public GameObject _introUI;         // ��Ʈ�� UI
    public GameObject _playUI;          // �÷��� UI
    public GameObject _gameOverUI;      // ���ӿ��� UI
    public Rigidbody2D _birdRigid;

    public bool _isIntro = true;        // ��Ʈ�� ����
    public bool _isGameOver = false;    // ���ӿ��� ����

    public Text _scoreNumberText;       // Score Text
    public int _score = 0;              // Score �ʱⰪ
    const int _scoreMax = 2147483647;   // Score �ִ밪


    // Start is called before the first frame update
    void Start()
    {
        // Txt_Score_Number ������Ʈ
        Transform score_Number = _playUI.transform.Find("Txt_Score_Number");
        _scoreNumberText = score_Number.gameObject.GetComponent<Text>();

        // ��Ʈ�� ����
        // 1. UIó��
        _introUI.SetActive(true);
        _playUI.SetActive(false);
        _gameOverUI.SetActive(false);

        // 2. �߷�(����) ��Ȱ��ȭ
        _birdRigid.simulated = false;

        // 3. ���� �Է� ��Ȱ��ȭ
        _isIntro = true;
    }

    // Update is called once per frame
    void Update()
    {
        _scoreNumberText.text = _score.ToString("D10");  // �տ� 0�� �ٿ��� 10�ڸ����� �����
    }

    // ��ư �̺�Ʈ : ���ӽ���
    public void OnClick_GameStart()
    {
        Debug.Log("���� ���� ��ư ����!!!");

        // 1. ��Ʈ�� UI�� ���ְ�, �÷��� UI�� ����
        // _introUI = GameObject.Find("UI_Intro");
        _introUI.SetActive(false);
        _playUI.SetActive(true);

        // 2. �߷�(����) Ȱ��ȭ
        _birdRigid.simulated = true;

        // 3. ���� �Է� Ȱ��ȭ
        _isIntro = false;

        // ������ ��������
        _pipeMgr.Start_MakePipeSet();
    }

    // ��ư �̺�Ʈ : ���� �����
    public void OnClick_Retry()
    {
        SceneManager.LoadScene("MyFirstGame");
    }


    // ���ӿ��� �̺�Ʈ �Լ�
    public void OnGameOver()
    {
        // �÷��� UI ���ְ�
        _playUI.SetActive(false);

        // ���ӿ��� UI ���ֱ�
        _gameOverUI.SetActive(true);

        // �ٽ�, �߷� ��Ȱ��
        _birdRigid.simulated = false;

        _isGameOver = true;
    }

    // ���ӽ��ھ� ȹ�� �̺�Ʈ �Լ�
    public void OnGameScore()
    {
        // Debug.Log(_score + " | " + _scoreMax);
        if ( _score < _scoreMax )
            _score ++;
    }
}
