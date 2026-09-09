using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cafe/Tipo de Cafe")]
public class RecetaCafe : ScriptableObject
{
    public int cantidadAgua;
    public int cantidadCafe;
    public List<Aniadido> aniadidos;
}
