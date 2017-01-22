using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WilsonCharacter : Character, BagelReceiver, LabWorker {

    Animator anim;
    Rigidbody2D rgbd;
    int direction = 0;
    Vector3 lastLocation;

    public GameObject wilfredStateIcon;

    // Use this for initialization
    void Start () {
        base.Start();
        timeline.SetUpTimeline(this);
        anim = GetComponent<Animator>();
        rgbd = GetComponent<Rigidbody2D>();
        lastLocation = this.transform.position;
        anim.SetBool("Dead", false);
    }

    void FixedUpdate()
    {
        Vector2 velocity = this.transform.position - lastLocation;
        float speed = velocity.sqrMagnitude;
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        if (speed > 0)
        {
            // Forward
            if (angle >= 215f && angle <= 325f)
            {
                direction = 0;
            }
            // Left
            else if (angle > 135f && angle < 215f)
            {
                direction = 1;
            }
            // Down
            else if (angle >= 45f && angle <= 135f)
            {
                direction = 2;
            }
            // Right
            else if (angle < 45f || angle > 325f)
            {
                direction = 3;
            }
        }
        anim.SetFloat("Speed", speed);
        anim.SetInteger("Direction", direction);
        lastLocation = this.transform.position;
    }

    public override void OnTriggerEnter2D(Collider2D coll)
    {
        base.OnTriggerEnter2D(coll);
        if (coll.gameObject.GetComponent<KillerCarCharacter>())
        {
            killWilfred("BLRGRGgggg....", 40);
        } else if (coll.gameObject.GetComponent<Manhole>())
        {
            killWilfred("AAAAaaaaaaa.......      Sploosh", 20);
            //wilfred dissapears, so remove his sprite
            Destroy(this.GetComponent<SpriteRenderer>());
        }
    }

    private void killWilfred(string text, int textSize)
    {
        anim.SetBool("Dead", true);
        Kill(Instantiate(textActionPrefab).SetUp(this, new Vector3(0, 1, 0), text, TextObject.typeSpeed.INSTANT, textSize, 3));
        wilfredStateIcon.GetComponent<WilfredIcon>().killWilfredIcon();
    }

    public void receiveBagel(bool bagelReceived)
    {
        if(bagelReceived)
        {
            killWilfred("*Cough*... *Cough*... I'm choking.... *Cough*", 20);
        } else
        {
            Instantiate(textActionPrefab).SetUp(this, new Vector3(0, 1, 0), "Aww... No more bagels.", TextObject.typeSpeed.INSTANT, 20, 3).DoAction();
        }
    }

    public void enterLab()
    {
        Destroy(this.GetComponent<SpriteRenderer>());
        TimeManager.getInstance().setSuccess(true);

    }
}
