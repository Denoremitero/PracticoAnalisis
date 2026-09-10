using UnityEngine;
using UnityEngine.UI;

public class Recibo : MonoBehaviour
{
    [SerializeField] Text contenidoRecibo;
    public void MostrarCafe(Cafe cafe)
    {
        string recibo = "";

        recibo += "===== CAFETERÍA =====\n";
        recibo += $"Café: {cafe.recetaCafe.nombre}\n";
        recibo += $"Tamaño: {cafe.tamanio}\n";
        recibo += "\n";
        recibo += "Ingredientes:\n";

        recibo += $"Agua: {cafe.recetaCafe.cantidadAgua} ml\n";
        recibo += $"Café: {cafe.recetaCafe.cantidadAgua} g\n";

        foreach (Aniadido aniadido in cafe.recetaCafe.aniadidos)
        {
            recibo += $"{aniadido.tipo}: {aniadido.cantidad}\n";
        }

        recibo += "\n";
        recibo += "=====================\n";
        recibo += "¡Gracias!";

        contenidoRecibo.text = recibo;
    }
}
