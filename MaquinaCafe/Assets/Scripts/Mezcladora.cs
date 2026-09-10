using UnityEngine;

public class Mezcladora : MonoBehaviour
{
    [SerializeField] MaquinaDeCafe maquinaDeCafe;
    public Cafe Mezclar(Cafe cafe)
    {
        if (cafe.estado == Estados.Mezclado)
        {
            Debug.Log("El cafe ya ha sido mezclado");
            return cafe;
        }
        Cafe cafeMezclado = cafe;
        cafeMezclado = SizeAdapt(cafeMezclado);
        cafeMezclado.estado = Estados.Mezclado;
        Debug.Log("El cafe se está mezclando");
        maquinaDeCafe.SiguienteEtapa(cafeMezclado);
        return cafeMezclado;
    }
    private Cafe SizeAdapt(Cafe cafe)
    {
        if(cafe.tamanio == Tamanios.Mediano)
        {
            foreach(Aniadido aniadido in cafe.recetaCafe.aniadidos)
            {
                aniadido.cantidad *= 2;
            }
        }
        else if (cafe.tamanio == Tamanios.Grande)
        {
            foreach (Aniadido aniadido in cafe.recetaCafe.aniadidos)
            {
                aniadido.cantidad *= 4;
            }
        }

        return cafe;
    }
}
