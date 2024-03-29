﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーを押すと、アニメーションを切り換える
public class OnKeyPress_ChangeAnime : MonoBehaviour {

    public string nomalAnime = "";
	public string upAnime = "";		// 上向き：Inspectorで指定
	public string downAnime = "";	// 下向き：Inspectorで指定
	public string rightAnime = "";	// 右向き：Inspectorで指定
	public string leftAnime = "";	// 左向き：Inspectorで指定
    public string jumpAnime = "";
    bool groundFlag = false; // 足が何かに触れているかどうか


    string nowMode = "";
	string oldMode = "";

	void Start() { // 最初に行う
		nowMode = downAnime;
		oldMode = "";
	}

	void Update() { // ずっと行う
		if (Input.GetKey("up")) { // 上キーなら
			nowMode = upAnime;
		}if (Input.GetKey("down")) { // 下キーなら
			nowMode = downAnime;
		}
		if (Input.GetKey("right")) { // 右キーなら
			nowMode = rightAnime;
		}
		if (Input.GetKey("left")) { // 左キーなら
			nowMode = leftAnime;
		}
        if (Input.GetKey("space")) {
            nowMode = jumpAnime;
        }
        if (groundFlag == true && !(Input.GetKey("up")|| Input.GetKey("down")|| Input.GetKey("right") || Input.GetKey("left"))) {//十字キー入力がなく、かつ地面に足が触れていたら
            nowMode = nomalAnime;
        }
	}
	void FixedUpdate() { // ずっと行う（一定時間ごとに）
		// もし違うキーが押されたら
		if (nowMode != oldMode) {
			oldMode = nowMode;
			// アニメを切り換える
			Animator animator = this.GetComponent<Animator>();
			animator.Play(nowMode);
		}
	}
    void OnTriggerStay2D(Collider2D collision)
    { // 足が何かに触れたら
        groundFlag = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    { // 足に何も触れなかったら
        groundFlag = false;
    }

}
