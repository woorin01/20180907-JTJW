using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

    // 사용자 변수
    [Range(1, 15)]
    public  float    fMaxCharrSpeed;
    private float    fNowCharSpeed = 0.0f;

    // 이 값으로 MaxCharacterSpeed를 나눠 캐릭터 스피드를 천천히 증가시킴)
    [Range(1, 20)]
    public  float    fCharSpeedDivide;
    // 이 값으로 PlayerAnimationSpeed를 나눠 캐릭터 애니메이션 스피드를 천천히 증가시킴)
    [Range(1, 20)]
    public float     fAniSpeedDivide;

    private Vector2 v2StartTouchPos;
    private bool    bTouchOn = false;

    // 컴포넌트 변수
    Animator PlayerAnimator;

    // Use this for initialization
	void Start () {
        PlayerAnimator = GetComponent<Animator>();
        PlayerAnimator.speed = 0.0f;

        StartCoroutine("StartAnimationSpeedUp");
        StartCoroutine("StartCharacterSpeedUp");
    }

    // Update is called once per frame
    void Update () {
        ForwardMovement();
        UserOperation();
	}

    // 사용자 함수 
    void ForwardMovement()
    {
        transform.Translate(new Vector3(0, 0, fNowCharSpeed * Time.deltaTime));
    }

    void UserOperation()
    {
        Vector2 v2NowTouchPos = new Vector2(0,0);

        if (Input.GetMouseButtonDown(0))
        {
            bTouchOn = true;
            v2StartTouchPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            if(bTouchOn)
                v2NowTouchPos   = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            bTouchOn        = false;
            v2StartTouchPos = new Vector2(0, 0);
        }

        Vector2 v2TouchLength;
        v2TouchLength.x = Mathf.Abs(v2NowTouchPos.x - v2StartTouchPos.x);
        v2TouchLength.y = Mathf.Abs(v2NowTouchPos.y - v2StartTouchPos.y);

        if(v2TouchLength.x > 10 || v2TouchLength.y > 10)
        {
            // 상하 조작
            if(v2TouchLength.y > v2TouchLength.x)
            {
                // 점프인지
                if(v2NowTouchPos.y > v2StartTouchPos.y)
                    Debug.Log("J");
                // 슬라이드인지                
                if (v2NowTouchPos.y < v2StartTouchPos.y)
                    Debug.Log("S");
            }
            // 좌우 조작
            else if(v2TouchLength.y < v2TouchLength.x)
            {
                // 오른쪽인지
                if(v2NowTouchPos.x > v2StartTouchPos.x)
                    Debug.Log("R");
                // 왼쪽인지
                if (v2NowTouchPos.x < v2StartTouchPos.x)
                    Debug.Log("L");
            }

            v2StartTouchPos = new Vector2(0,0);
            bTouchOn = false;
        }
    }


    // 코루틴 함수
    IEnumerator StartAnimationSpeedUp()
    {
        while(PlayerAnimator.speed < 1.0f)
        {
            PlayerAnimator.speed += 1.0f / fAniSpeedDivide;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator StartCharacterSpeedUp()
    {
        while (fNowCharSpeed < fMaxCharrSpeed)
        {
            fNowCharSpeed += fMaxCharrSpeed / fCharSpeedDivide;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
