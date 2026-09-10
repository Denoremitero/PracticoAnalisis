using UnityEngine;

public class Filtradora : MonoBehaviour
{
    [SerializeField] MaquinaDeCafe maquinaDeCafe;
    public Cafe FiltrarCafe(Cafe cafe)
    {
        if (cafe.estado == Estados.Filtrado)
        {
            Debug.Log("El cafe ya ha sido filtrado");
            return cafe;
        }
        Cafe cafeFiltrado = cafe;
        cafeFiltrado = SizeAdapt(cafeFiltrado);
        cafeFiltrado.estado = Estados.Filtrado;
        Debug.Log("El cafe se está filtrando");
        maquinaDeCafe.SiguienteEtapa(cafeFiltrado);
        return cafeFiltrado;
    }
    private Cafe SizeAdapt(Cafe cafe)
    {
        if (cafe.tamanio == Tamanios.Mediano)
        {
            cafe.recetaCafe.cantidadAgua *= 2;
            cafe.recetaCafe.cantidadCafe *= 2;


        }
        else if (cafe.tamanio == Tamanios.Grande)
        {
            cafe.recetaCafe.cantidadCafe *= 4;
            cafe.recetaCafe.cantidadAgua *= 4;
        }
        return cafe;
    }
}
