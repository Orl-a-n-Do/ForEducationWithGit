using UnityEngine;

public class HeroItemHandler : MonoBehaviour
{
    private Items _currentItem; 

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Было соприкосновение c предметом");
        Items item = other.GetComponent<Items>();

        if (item != null && _currentItem == null) 
        {
            PickUpItem(item);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _currentItem != null)
        {
            UseItem();
        }
    }

    private void PickUpItem(Items item)
    {
        _currentItem = item; 
        item.transform.SetParent(transform); 
 
        item.transform.localPosition = new Vector3(1, 0, 0); 
        item.transform.localRotation = Quaternion.identity; 

        Debug.Log($"Поднят предмет: {item.name}");
    }

    private void UseItem()
    {
        if(_currentItem != null)
        {
            _currentItem.Use(); 
             _currentItem.PlayParticleEffect();
            Destroy(_currentItem.gameObject); 
            _currentItem = null; 
            Debug.Log("Предмет использован и уничтожен");
        }
    }
}