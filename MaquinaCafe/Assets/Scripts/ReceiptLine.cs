using TMPro;
using UnityEngine;

public class ReceiptLine : MonoBehaviour
{
    [SerializeField] private TMP_Text nombre;
    [SerializeField] private TMP_Text cantidad;

    public void Configurar(string nombre, string cantidad)
    {
        this.nombre.text = nombre;
        this.cantidad.text = cantidad;
    }
}
