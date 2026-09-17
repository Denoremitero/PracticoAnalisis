using UnityEngine;
using UnityEngine.UI;

public class Recibo : MonoBehaviour
{
    [SerializeField] Text contenidoRecibo;
    [SerializeField] private Transform contenido;
    [SerializeField] private ReceiptLine prefabLinea;
    public void MostrarCafe(Cafe cafe)
    {
        AgregarIngrediente(
            "Tipo de cafe:",
            "--------"
            );
        AgregarIngrediente(
            cafe.recetaCafe.nombre,
            "--------"
            );
        AgregarIngrediente(
            "Tamaño de cafe:",
            "-----"
            );
        AgregarIngrediente(
            cafe.tamanio.ToString(),
            "--------"
            );
        AgregarIngrediente(
            "--------",
            "--------");
        AgregarIngrediente(
            "Ingredientes:",
            "--------");
        AgregarIngrediente(
        "Agua",
        cafe.recetaCafe.cantidadAgua + " ml"
        );

        AgregarIngrediente(
            "Café",
            cafe.recetaCafe.cantidadCafe + " g"
        );

        foreach (Aniadido aniadido in cafe.recetaCafe.aniadidos)
        {
            AgregarIngrediente(
                aniadido.tipo.ToString(),
                aniadido.cantidad.ToString()
            );
        }
    }
    private void AgregarIngrediente(string nombre, string cantidad)
    {
        ReceiptLine linea = Instantiate(prefabLinea, contenido);

        linea.Configurar(nombre, cantidad);
    }
}
