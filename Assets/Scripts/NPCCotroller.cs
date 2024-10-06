using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class NPCCotroller : MonoBehaviour
{
    private bool isInteraction;
    private bool interaction;
    private bool confirms=true;
    [SerializeField] private GameObject objetivo;
    [SerializeField] private float speed;
    [SerializeField] private GameObject Canvas;
    private void Update()
    {
        if (confirms&&!interaction)
        {
            Move();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteraction = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteraction = false;
            interaction = false;
            Canvas.SetActive(false);
        }
    }
    public void Interactue(InputAction.CallbackContext context)
    {
        if (context.performed && isInteraction && !interaction)
        {
            Canvas.SetActive(true);
            interaction = true;
        }
        else if (context.performed && isInteraction&&interaction) 
        {
            Canvas.SetActive(false);
            interaction=false;
        }
    }
    public void SetObjetive(GameObject NewObjetivo)
    {
        objetivo = NewObjetivo;
        confirms = false;
        StartCoroutine(Confirms());
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, objetivo.transform.position, speed * Time.deltaTime);
    }
    private IEnumerator Confirms()
    {
        yield return new WaitForSeconds(1);
        confirms = true;
    } 

}
