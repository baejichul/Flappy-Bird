using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PipeManager _pipeMgr;

    public GameObject _introUI;         // 인트로 UI
    public GameObject _playUI;          // 플레이 UI
    public GameObject _gameOverUI;      // 게임오버 UI
    public Rigidbody2D _birdRigid;

    public bool _isIntro = true;        // 인트로 여부
    public bool _isGameOver = false;    // 게임오버 여부

    public Text _scoreNumberText;       // Score Text
    public int _score = 0;              // Score 초기값
    const int _scoreMax = 2147483647;   // Score 최대값


    // Start is called before the first frame update
    void Start()
    {
        // Txt_Score_Number 컴포넌트
        Transform score_Number = _playUI.transform.Find("Txt_Score_Number");
        _scoreNumberText = score_Number.gameObject.GetComponent<Text>();

        // 인트로 시점
        // 1. UI처리
        _introUI.SetActive(true);
        _playUI.SetActive(false);
        _gameOverUI.SetActive(false);

        // 2. 중력(물리) 비활성화
        _birdRigid.simulated = false;

        // 3. 유저 입력 비활성화
        _isIntro = true;
    }

    // Update is called once per frame
    void Update()
    {
        _scoreNumberText.text = _score.ToString("D10");  // 앞에 0을 붙여서 10자리수로 맞춘다
    }

    // 버튼 이벤트 : 게임시작
    public void OnClick_GameStart()
    {
        Debug.Log("게임 시작 버튼 눌림!!!");

        // 1. 인트로 UI를 꺼주고, 플레이 UI를 켜줌
        // _introUI = GameObject.Find("UI_Intro");
        _introUI.SetActive(false);
        _playUI.SetActive(true);

        // 2. 중력(물리) 활성화
        _birdRigid.simulated = true;

        // 3. 유저 입력 활성화
        _isIntro = false;

        // 파이프 생성시작
        _pipeMgr.Start_MakePipeSet();
    }

    // 버튼 이벤트 : 게임 재시작
    public void OnClick_Retry()
    {
        SceneManager.LoadScene("MyFirstGame");
    }


    // 게임오버 이벤트 함수
    public void OnGameOver()
    {
        // 플레이 UI 꺼주고
        _playUI.SetActive(false);

        // 게임오버 UI 켜주기
        _gameOverUI.SetActive(true);

        // 다시, 중력 비활성
        _birdRigid.simulated = false;

        _isGameOver = true;
    }

    // 게임스코어 획득 이벤트 함수
    public void OnGameScore()
    {
        // Debug.Log(_score + " | " + _scoreMax);
        if ( _score < _scoreMax )
            _score ++;
    }
}
