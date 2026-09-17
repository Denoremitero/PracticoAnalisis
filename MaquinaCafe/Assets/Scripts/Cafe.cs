using System.Collections.Generic;
using UnityEngine;

public class Cafe : MonoBehaviour
{
    public RecetaCafe recetaCafe;
    public Tamanios tamanio;
    public Estados estado;
    public Endulzante endulzante;

    public Cafe(RecetaCafe tipoCafe, Tamanios tamanioCafe, Estados estadoCafe, Endulzante endulzanteCafe)
    {
        recetaCafe = new RecetaCafe(tipoCafe);
        tamanio = tamanioCafe;
        estado = estadoCafe;
        endulzante = endulzanteCafe;
    }
}
public enum Estados
{
    SinHacer,
    Filtrando,
    Mezclando,
    Dispensando,
    Listo
}
[System.Serializable]
public enum Tamanios
{
    Grande, 
    Mediano,
    Chico
}
