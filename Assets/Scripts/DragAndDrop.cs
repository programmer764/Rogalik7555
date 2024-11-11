using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;
    public RectTransform originalParent;
    public RectTransform draggingObject;   
    public Player _player;
    public GridLayoutManager glm;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    public GameObject _go;
    public GameObject _go2;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        glm = _player.GetComponent<GridLayoutManager>();
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();             
       
    }


   


    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 0.6f;
        _canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        glm.RemoveItem(item);
        Destroy(_go);
        Destroy(_go2);
        Destroy(gameObject);
        CreateItem(item);       
        
    }
    public void CreateItem(Item item)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 1; // Устанавливаем Z-координату для правильного преобразования
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);        
        Instantiate(item.itemPrefab, worldPosition, transform.rotation);
    }



    

}