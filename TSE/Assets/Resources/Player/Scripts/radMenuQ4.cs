using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class radMenuQ4 : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    GameObject Player;
    playerController PC;
    // Start is called before the first frame update
    void Start()
    {
        PC = Player.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        PC.dropLegs();
        Debug.Log("Q4 Clicked");
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {

    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {

    }
}
