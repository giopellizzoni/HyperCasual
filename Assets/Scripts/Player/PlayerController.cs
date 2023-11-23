using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using System;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Power Ups Text")]
    public TextMeshPro uiTextPowerUp;

    [Header("Tags")]
    public string tagToCheckEnemy = "Enemy";
    public string tagToEndLine = "EndLine";

    [Header("Game Control")]
    public GameObject endScreen;

    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;
    public float speed = 1f;
    public bool invincible = false;

    #region Private Region
    private Vector3 _pos;
    private bool _canRun;
    private float _currentSpeed;
    private Vector3 _startPosition;
    #endregion

    public void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
    }


    // Update is called once per frame
    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            if(!invincible) EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToEndLine) 
        { 
            if(!invincible) EndGame(); 
        }
    }

    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun()
    {
        _canRun = true;
    }

    #region PowerUps
    public void SetPowerUpText(string s)
    { 
        uiTextPowerUp.text = s;
    }

    public void PowerUpSpeeUp(float f) 
    {
        _currentSpeed = f;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;    
    }

    #endregion

    #region Power Up Invencible

    public void SetInvincible(bool isInvincible = true)
    {
        invincible = isInvincible;
    }

    #endregion


    public void ChangeHeight(float amountHeight, float duration, float animationDuration, Ease ease)
    {
        transform.DOMoveY(_startPosition.y + amountHeight, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.y, .1f);
    }
}
