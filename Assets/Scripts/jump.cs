using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{

    public float _jumpForce = 5.0f;
    public float _jumpLimit = 3.0f;

    public Rigidbody2D _rigid;      // 클래스 멤버변수 선언시 '_'로 시작
    public AudioSource _fxBird;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // f(힘) = ma(질량 * 가속도)

        if ( Input.GetKey(KeyCode.Space) )
        {
            // _rigid.AddForce( new Vector2( 0.0f, _jumpForce ) );
            Vector2 force = new Vector2( 0.0f, _jumpForce);
            _rigid.AddForce(force);     // 힘

            _fxBird.Play();             // 효과음 재생
        }

        Vector3 vel = _rigid.velocity;

        // 점프 속도 제한값 limit : 5를 넘어가지 않는 값
        float limit = Mathf.Min(_jumpLimit, vel.y);
        // _rigid.velocity = new Vector2(vel.x, limit);
        _rigid.velocity = new Vector3(vel.x, limit, 0.0f);
    }
}
