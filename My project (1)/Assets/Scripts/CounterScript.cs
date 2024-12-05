using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour
{
    public int counterValue = 10;
    public Text counterText;

    void Start()
    {
        counterText.text = "Счетчик: " + counterValue;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("OtherObject")) // Проверка по тегу
        {
            counterValue--;
            counterText.text = "Счетчик: " + counterValue;
            Debug.Log("Объект столкнулся! Счетчик: " + counterValue);
        }
        else if (other.gameObject.name == "Sphere") // Проверка по имени
        {
            counterValue--;
            counterText.text = "Счетчик: " + counterValue;
            Debug.Log("Сфера столкнулась! Счетчик: " + counterValue);
        }
        else if (other.gameObject.GetComponent<Rigidbody>()) // Проверка по компоненту Rigidbody
        {
            counterValue--;
            counterText.text = "Счетчик: " + counterValue;
            Debug.Log("Объект с Rigidbody столкнулся! Счетчик: " + counterValue);
        }
    }
}