using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Dispensadora : MonoBehaviour
{
    private int cantidadParaDispensar = 1;

    public Cafe FiltrarCafe(Cafe cafe)
    {
        if (cafe.estado == Estados.Filtrado)
        {
            Debug.Log("El cafe ya ha sido filtrado");
            return cafe;
        }
        Cafe cafeFiltrado = cafe;
        cafeFiltrado.estado = Estados.Filtrado;
        Debug.Log("El cafe se está filtrando");
        Mezclar(cafeFiltrado);
        return cafeFiltrado;
    }
    public Cafe Mezclar(Cafe cafe)
    {
        if (cafe.estado == Estados.Mezclado)
        {
            Debug.Log("El cafe ya ha sido mezclado");
            return cafe;
        }
        Cafe cafeMezclado = cafe;
        cafeMezclado.estado = Estados.Mezclado;
        Debug.Log("El cafe se está mezclando");
        Dispensar(cafeMezclado);
        return cafeMezclado;
    }
    public Cafe Dispensar(Cafe cafe) { 
        
        if(cafe.estado == Estados.Servido)
        {
            Debug.Log("El cafe ya ha sido servido");
            return cafe;
        }
        Cafe cafeServido = cafe;
        Debug.Log("El cafe se está dispensando");
        MostrarCafe(cafeServido);
        cafeServido.estado = Estados.Servido;
        return cafeServido;
    }
    public void MostrarCafe(Cafe cafe)
    {
        Debug.Log($"===== PEDIDO =====");
        Debug.Log($"Café: {cafe.recetaCafe.name}");
        Debug.Log($"Tamaño: {cafe.tamanio}");
        Debug.Log($"Agua: {cafe.recetaCafe.cantidadAgua}");
        Debug.Log($"Café: {cafe.recetaCafe.cantidadCafe}");

        foreach (Aniadido aniadido in cafe.recetaCafe.aniadidos)
        {
            Debug.Log($"Añadido: {aniadido.tipo} x{aniadido.cantidad}");
        }

        Debug.Log($"==================");
        Debug.Log($"DISPENSADO CON EXITO");
    }
}
