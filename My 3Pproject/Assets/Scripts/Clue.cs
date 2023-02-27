using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour
{
    [SerializeField] public GameObject clue;
    private void OnTriggerEnter(Collider other)
    {
        clue.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        clue.SetActive(false);
    }
}
