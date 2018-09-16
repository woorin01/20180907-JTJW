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
        CharacterMove();
	}

    void CharacterMove()
    {
        transform.Translate(new Vector3(0, 0, fNowCharSpeed * Time.deltaTime));
    }

    // 사용자 함수 


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
