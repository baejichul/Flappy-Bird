using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{

    public GameObject _pipeSetTemplate;

    public float _delay   = 2.0f;
    public float _destory = 4.0f;

    public float _yPosRndMin = -2.0f;
    public float _yPosRndMax = 2.0f;

    /*
    public float _yPosPillDownRndMin = -5.0f;
    public float _yPosPillDownRndMax = -2.0f;

    public float _yPosPillUpRndMin = 4.0f;
    public float _yPosPillUpRndMax = 6.0f;
    */

    public int _yPosPillDownRndMin = -5;
    public int _yPosPillDownRndMax = -1;

    public int _yPosPillUpRndMin = 4;
    public int _yPosPillUpRndMax = 7;

    GameManager _gameMgr;


    private void Start()
    {
        _pipeSetTemplate.SetActive(false);

        _gameMgr = FindObjectOfType<GameManager>();
    }

    public void Start_MakePipeSet()
    {
        // _delay 후, MakePipeSet 함수 호출
        Invoke("MakePipeSet", _delay);
    }

    void MakePipeSet()
    {
        // 파이프셋 복제
        GameObject cloneObj = Instantiate(_pipeSetTemplate);
        cloneObj.SetActive(true);

        // 파이프셋 yPos 설정
        // float yPos = Random.Range(_yPosRndMin, _yPosRndMax);
        // cloneObj.transform.position = new Vector3(0, yPos, 0);

        // 파이프별 yPos 설정
        float yPillDownPos = Random.Range(_yPosPillDownRndMin, _yPosPillDownRndMax);
        Transform bgPillarDownTransFrm = cloneObj.transform.Find("bg_pillarDown");
        bgPillarDownTransFrm.position = new Vector3( bgPillarDownTransFrm.position.x, yPillDownPos, bgPillarDownTransFrm.position.z );

        float yPillUpPos = Random.Range(_yPosPillUpRndMin, _yPosPillUpRndMax);
        Transform bgPillarUpTransFrm = cloneObj.transform.Find("bg_pillarUp");
        bgPillarUpTransFrm.position = new Vector3( bgPillarUpTransFrm.position.x, yPillUpPos, bgPillarUpTransFrm.position.z );

        Debug.Log("down : up = " + yPillDownPos + " : " + yPillUpPos);



        if ( _gameMgr._isGameOver == false )
        {
            Invoke("MakePipeSet", _delay);
        }

        Destroy(cloneObj, _destory);    // 복제된 파이프셋 Destroy
    }
}
