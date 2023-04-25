using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primer_parcial_solid_transporte
{
    public class Avion : ITransporte
    {
        //public string _nombre;
        public int _velocidadActual;
        public int _velocidadMaxima;
        public int _alturaActual;
        public int _alturaMaxima;

        public Avion(int _velocidadActual,int velocidadMaxima, int alturaActual, int alturaMaxima, TransporteRepository bbdd )
        {
            this._velocidadActual = velocidadActual;
            this._velocidadMaxima = velocidadMaxima;
            this._alturaActual = alturaActual;
            this._alturaMaxima = alturaMaxima;
            this.BBDD = new TransporteRepository();;
        }
        public void Acelerar(int velocidad)
        {
            if ((this._velocidadActual + velocidad) <= this._velocidadMaxima)
            {
                this._velocidadActual += velocidad;
            }
        }

        public void Desacelerar(int velocidad)
        {
            if ((this._velocidadActual - velocidad) >= 0)
            {
                this._velocidadActual -= velocidad;
            }
            else
            {
                this._velocidadActual = 0;
            }
        }

        public void Volar(int altitud)
        {
            if ((this._alturaActual + altitud) < 0)
            {
                this._alturaActual = 0;
            }
            else if ((this._alturaActual + altitud) > this._alturaMaxima)
            {
                this._alturaActual = this._alturaMaxima;
            }
            else
            {
                this._alturaActual += altitud;
            }
        }

        public void guardarEnBD()
        {
            TransporteRepository repository = new TransporteRepository();
            repository.guardar(this);
            bbdd.guardar(this);
        }
    }
}
