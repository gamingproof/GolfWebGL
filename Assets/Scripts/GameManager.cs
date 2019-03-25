using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int StepKick = 0;
    public Text StepKickText;
    public float Power;
    public Image PowerImage;
    public float MaxPower = 100;
    public bool PowerInc;
    public KickBall ball;
    public Camera cam;

    void Start()
    {
        cam = Camera.main;
    }


    void Update()
    {
        if (ball.IsStopped)
        {
            PowerChange();
            CheckKick();
        }
    }

    private void CheckKick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var direction = ball.transform.position - cam.transform.position;
            direction.y = ball.transform.position.y;
            ball.Kick(Power*0.1f, direction.normalized);
            StepKickAdd();
        }
    }

    private void StepKickAdd()
    {
        StepKick++;
        StepKickText.text = "Удар: " + StepKick.ToString();
    }

    private void PowerChange()
    {
        if (Power >= 100)
        {
            PowerInc = false;
        }
        else if (Power <= 10)
        {
            PowerInc = true;
        }
        Power += (PowerInc ? Time.deltaTime : -Time.deltaTime)*50;
        PowerImage.fillAmount = Power/100f;
    }
}
