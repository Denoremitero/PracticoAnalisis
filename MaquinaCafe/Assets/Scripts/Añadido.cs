using UnityEngine;

[System.Serializable]
public class Aniadido
{
    public TipoAniadidos tipo;
    public int cantidad;
}
public enum TipoAniadidos
{
    Leche,
    Chocolate,
    Caramelo,
    Canela,
    Espuma
}
