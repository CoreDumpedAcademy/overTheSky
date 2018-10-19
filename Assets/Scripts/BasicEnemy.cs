using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {

  public static bool killActive;
  public float killActiveTime = 3f;

  private float timer;

  private SpriteRenderer spriteRend;

	// Use this for initialization
	void Start () {
	  spriteRend = GetComponent<SpriteRenderer>();	

    timer = killActiveTime;
    if (Random.Range(0f, 10f) >= 5) {
      killActive = true;
      spriteRend.color = Color.red;
    }
    else {
      killActive = false;
      spriteRend.color = Color.white;
    }

	}
	
	// Update is called once per frame
	void Update () {
    Timer();
	}

  void Timer () {
    timer -= Time.deltaTime;
    if (timer <= 0){
      killActive = !killActive;
      if (killActive){
        spriteRend.color = Color.red;
      }
      else {
        spriteRend.color = Color.white;
      }
      timer = killActiveTime;
    }
  }
}
