using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ReservaCRUD
    {
        private Conexion conexion = new Conexion();

        // Método para listar todas las reservas
        public DataTable ListarReservas()
        {
            using (SqlConnection conn = conexion.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("ConsultarReservas", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Método para insertar una nueva reserva
        public void InsertarReserva(string nombre, DateTime fechaEntrada, DateTime fechaSalida, int habitacion, string estado)
        {
            using (SqlConnection conn = conexion.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("InsertarReserva", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreCliente", nombre);
                    cmd.Parameters.AddWithValue("@FechaEntrada", fechaEntrada);
                    cmd.Parameters.AddWithValue("@FechaSalida", fechaSalida);
                    cmd.Parameters.AddWithValue("@NumeroHabitacion", habitacion);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para actualizar una reserva existente
        public void ActualizarReserva(int reservaId, string nombre, DateTime fechaEntrada, DateTime fechaSalida, int habitacion, string estado)
        {
            using (SqlConnection conn = conexion.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("ActualizarReserva", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReservaId", reservaId);
                    cmd.Parameters.AddWithValue("@NombreCliente", nombre);
                    cmd.Parameters.AddWithValue("@FechaEntrada", fechaEntrada);
                    cmd.Parameters.AddWithValue("@FechaSalida", fechaSalida);
                    cmd.Parameters.AddWithValue("@NumeroHabitacion", habitacion);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para eliminar una reserva
        public void EliminarReserva(int reservaId)
        {
            using (SqlConnection conn = conexion.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("EliminarReserva", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReservaId", reservaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
