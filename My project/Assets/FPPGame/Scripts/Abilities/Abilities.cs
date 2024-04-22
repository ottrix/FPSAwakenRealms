using System;
using System.Collections;
using System.Collections.Generic;
using FPPGame;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public GameObject _prefabSpell1;
    public Camera _camera;
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && GameManager.MainCharacter.Power >= 10)
        {
            CastSpell1();
            GameManager.MainCharacter.Power -= 10;
            EventsManager.PowerChanged?.Invoke();
        }
    }
    
    private void CastSpell1()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 objectPos = _camera.ScreenToWorldPoint(mousePos);
        objectPos.y = 0;
        Vector3 moveDirection = (objectPos - transform.position).normalized;
        Vector3 spawnPosition = transform.position + moveDirection * 1.5f; 
        Instantiate(_prefabSpell1, spawnPosition, Quaternion.LookRotation(moveDirection));
    }
}
