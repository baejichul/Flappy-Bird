using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{

    public float _jumpForce = 5.0f;
    public float _jumpLimit = 3.0f;

    public Rigidbody2D _rigid;      // Ŭ���� ������� ����� '_'�� ����
    public AudioSource _fxBird;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // f(��) = ma(���� * ���ӵ�)

        if ( Input.GetKey(KeyCode.Space) )
        {
            // _rigid.AddForce( new Vector2( 0.0f, _jumpForce ) );
            Vector2 force = new Vector2( 0.0f, _jumpForce);
            _rigid.AddForce(force);     // ��

            _fxBird.Play();             // ȿ���� ���
        }

        Vector3 vel = _rigid.velocity;

        // ���� �ӵ� ���Ѱ� limit : 5�� �Ѿ�� �ʴ� ��
        float limit = Mathf.Min(_jumpLimit, vel.y);
        // _rigid.velocity = new Vector2(vel.x, limit);
        _rigid.velocity = new Vector3(vel.x, limit, 0.0f);
    }
}
