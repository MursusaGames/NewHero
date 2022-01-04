using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, 
	IDragHandler, IEndDragHandler, IPointerDownHandler {	

	public RectTransform thumb;
	//public RectTransform pad;
	[SerializeField] private GameObject pad;
	private Vector3 padPos;
	
	private Vector2 originalPosition;
	private Vector2 originalThumbPosition;	
	public Vector2 delta;
	public bool isTouch;

	void Start () {
		originalPosition = this.GetComponent<RectTransform>().localPosition;
		originalThumbPosition = thumb.localPosition;		
		thumb.gameObject.SetActive(false);		
		delta = Vector2.zero;
		padPos = pad.gameObject.transform.position;
	}

	public void OnBeginDrag (PointerEventData eventData) {
		isTouch = true;
		thumb.gameObject.SetActive(true);		
		Vector3 worldPoint = new Vector3();
		RectTransformUtility.ScreenPointToWorldPointInRectangle(
			this.transform as RectTransform, 
            eventData.position, 
            eventData.enterEventCamera, 
            out worldPoint);		
		//this.GetComponent<RectTransform>().position = worldPoint;		
		thumb.localPosition = originalThumbPosition;
	}

	public void OnDrag (PointerEventData eventData) {

		Vector3 worldPoint = new Vector3();
		RectTransformUtility.ScreenPointToWorldPointInRectangle(
			this.transform as RectTransform, 
            eventData.position, 
            eventData.enterEventCamera, 
            out worldPoint);		
		thumb.position = worldPoint;		
		var size = GetComponent<RectTransform>().rect.size;
		delta = thumb.localPosition;

		delta.x /= size.x / 2.0f;
		delta.y /= size.y / 2.0f;

		delta.x = Mathf.Clamp(delta.x, -1000.0f, 1000.0f);
		delta.y = Mathf.Clamp(delta.y, -1000.0f, 1000.0f);


	}

	public void OnEndDrag (PointerEventData eventData) {
		isTouch = false;
		this.GetComponent<RectTransform>().localPosition = originalPosition;		
		delta = Vector2.zero;		
		thumb.gameObject.SetActive(false);
		pad.gameObject.transform.position = padPos;
	}

    
    public void OnPointerDown(PointerEventData eventData)
    {
       pad.gameObject.transform.position = eventData.position;
    }

    
}
