﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorCol : MonoBehaviour
{
    [SerializeField] private AnchorSTM anchorstm;
    [SerializeField] private SwordAttack swordattack;
    public bool isOpen = false;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player" && swordattack.Attacking == true
            && isOpen == false) {
            anchorstm.states = AnchorSTM.States.fall;
            isOpen = true;
        }
        if (other.gameObject.tag == "Grenade" &&
           other.gameObject.GetComponent<Grenade>().doeskill == true) {
            anchorstm.states = AnchorSTM.States.fall;
            isOpen = true;
        }
    }
}
