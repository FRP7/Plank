﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3 : MonoBehaviour
{
    [SerializeField] private PlayerController playerinstance;
    [SerializeField] private SkillsSTM stminstance;
    [SerializeField] private GameObject bomb;
    [SerializeField] private float skilltime;
    [SerializeField] private bool canThrow = true;
    [SerializeField] private Transform hand;

    private void Update() {
        playerinstance.GetComponent<PlayerController>();
        stminstance.GetComponent<SkillsSTM>();
    }

    public void Skill3method() {
        StartCoroutine(SkillTime());
        Debug.Log("skill3");
        Throw();
    }

    private void Throw() {
        if(canThrow == true) {
            Debug.Log("Throw");
            Instantiate(bomb, hand.transform.position, hand.transform.rotation);
            canThrow = false;
        }
    }

    IEnumerator SkillTime() {
            yield return new WaitForSeconds(skilltime);
            stminstance.skills = SkillsSTM.Skills.noskill;
            canThrow = true;
    }
 }
