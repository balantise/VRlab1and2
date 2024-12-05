using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour
{
    public int counterValue = 10;
    public Text counterText;

    void Start()
    {
        counterText.text = "�������: " + counterValue;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("OtherObject")) // �������� �� ����
        {
            counterValue--;
            counterText.text = "�������: " + counterValue;
            Debug.Log("������ ����������! �������: " + counterValue);
        }
        else if (other.gameObject.name == "Sphere") // �������� �� �����
        {
            counterValue--;
            counterText.text = "�������: " + counterValue;
            Debug.Log("����� �����������! �������: " + counterValue);
        }
        else if (other.gameObject.GetComponent<Rigidbody>()) // �������� �� ���������� Rigidbody
        {
            counterValue--;
            counterText.text = "�������: " + counterValue;
            Debug.Log("������ � Rigidbody ����������! �������: " + counterValue);
        }
    }
}