﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptedPirateAnim : MonoBehaviour
{
    [SerializeField] private Animator AnimController;

    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip walkclip;

    [SerializeField] private EnemyController enemycontroller;


    private void Awake() {
        audiosource = GetComponent<AudioSource>();
        AnimController = GetComponent<Animator>();
    }

    private void Start() {
        audiosource.clip = walkclip;
        audiosource.Play();
    }

    private void Update() {
        if(enemycontroller.GetComponent<EnemyController>().Health <= 0) {
            audiosource.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            audiosource.clip = null;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player") {
            AnimController.Play("shoot");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            audiosource.clip = null;
            audiosource.clip = walkclip;
            audiosource.Play();
            AnimController.Play("walk");
        }
    }
}
