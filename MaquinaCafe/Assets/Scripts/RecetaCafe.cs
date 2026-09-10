using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cafe/Tipo de Cafe")]
public class RecetaCafe : ScriptableObject
{
    public int cantidadAgua;
    public int cantidadCafe;
    public List<Aniadido> aniadidos;
    public string nombre;

    public RecetaCafe(RecetaCafe recetaCafe)
    {
        this.cantidadCafe = recetaCafe.cantidadCafe;
        this.cantidadAgua = recetaCafe.cantidadAgua;
        this.nombre = recetaCafe.name;
        aniadidos = new List<Aniadido>();

        foreach (Aniadido original in recetaCafe.aniadidos)
        {
            aniadidos.Add(new Aniadido
            {
                tipo = original.tipo,
                cantidad = original.cantidad
            });
        }
    }
}
