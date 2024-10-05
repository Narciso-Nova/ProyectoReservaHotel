using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class GestorReservas
    {
        private ReservaCRUD reservaCRUD = new ReservaCRUD();

        public DataTable ObtenerReservas()
        {
            return reservaCRUD.ListarReservas();
        }

        public void CrearReserva(string nombre, DateTime entrada, DateTime salida, int habitacion, string estado)
        {
            reservaCRUD.InsertarReserva(nombre, entrada, salida, habitacion, estado);
        }

        public void ActualizarReserva(int reservaId, string nombre, DateTime entrada, DateTime salida, int habitacion, string estado)
        {
            reservaCRUD.ActualizarReserva(reservaId, nombre, entrada, salida, habitacion, estado);
        }

        // Agregar el método EliminarReserva
        public void EliminarReserva(int reservaId)
        {
            reservaCRUD.EliminarReserva(reservaId);
        }
    }
}
