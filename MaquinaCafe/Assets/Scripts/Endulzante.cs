using UnityEngine;

[System.Serializable]
public class Endulzante
{
    private bool bEndulzante;
    private TipoEndulzantes tipoEndulzante;

    public Endulzante(bool tieneEndulzante, TipoEndulzantes tipoEndulzante) {

        bEndulzante = tieneEndulzante;
        this.tipoEndulzante = tipoEndulzante;
    
    }
}
public enum TipoEndulzantes
{
    Azucar,
    Edulcorante,
    Nada
}
