using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public GameManager _gameMgr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (_gameMgr._isIntro == true )
            return;

        /*
        if ( Input.GetKey( KeyCode.LeftArrow) )
        {
            Vector3 pos = transform.position;       //트랜스 폼의 위치값을 임시변수 pos에 담아둠

            pos.x = pos.x - 0.01f;
            transform.position = pos;
            // transform.position = new Vector3( pos.x - 0.1f, pos.y, pos.z );
        }

        if ( Input.GetKey(KeyCode.RightArrow) )
        {
            Vector3 pos = transform.position;

            pos.x = pos.x + 0.01f;
            transform.position = pos;
        }

        if ( Input.GetKey(KeyCode.UpArrow) )
        {
            Vector3 pos = transform.position;

            pos.y = pos.y + 0.01f;
            transform.position = pos;
        }

        if ( Input.GetKey(KeyCode.DownArrow) )
        {
            Vector3 pos = transform.position;

            pos.y = pos.y - 0.01f;
            transform.position = pos;
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D 이벤트 발생 " + collision.gameObject.name);

        // 게임 매니저에 게임오버 사실을 알림
        _gameMgr.OnGameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D 이벤트 발생 " + collision.gameObject.name);

        // 게임 매니저에 스코어 획득 사실을 알림
        // _gameMgr._score++;

        _gameMgr.OnGameScore();
    }
}
