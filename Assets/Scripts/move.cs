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
            Vector3 pos = transform.position;       //Ʈ���� ���� ��ġ���� �ӽú��� pos�� ��Ƶ�

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
        Debug.Log("OnCollisionEnter2D �̺�Ʈ �߻� " + collision.gameObject.name);

        // ���� �Ŵ����� ���ӿ��� ����� �˸�
        _gameMgr.OnGameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D �̺�Ʈ �߻� " + collision.gameObject.name);

        // ���� �Ŵ����� ���ھ� ȹ�� ����� �˸�
        // _gameMgr._score++;

        _gameMgr.OnGameScore();
    }
}
