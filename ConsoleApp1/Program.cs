



//sing Oracle.ManagedDataAccess.Client;


using Oracle.ManagedDataAccess.Client;
using System.Data;

string ConectionString()
{
    string conectionString = "USER ID = sa; PASSWORD=password1;PERSIST SECURITY INFO=True;DATA SOURCE =orcl;CONNECTION TIMEOUT = 250";
    return conectionString;
}

using (OracleConnection connection = new OracleConnection("USER ID=sa;PASSWORD=password1;PERSIST SECURITY INFO=True;DATA SOURCE=192.168.0.185:1521/orcl;CONNECTION TIMEOUT=250"))
{
    connection.Open();



    using (OracleCommand cmd = new OracleCommand("GetAllalumno", connection))
    {
        //cmd.Parameters.Add("idalumno", OracleDbType.Int64, ParameterDirection.Output);
        //cmd.Parameters.Add("nombre", OracleDbType.Varchar2, ParameterDirection.Output);
        //cmd.Parameters.Add("apellidopaterno", OracleDbType.Varchar2, ParameterDirection.Output);
        //cmd.Parameters.Add("apellidomaterno", OracleDbType.Varchar2, ParameterDirection.Output);
        //cmd.Parameters.Add("fechanacimiento", OracleDbType.Date, ParameterDirection.Output);
        cmd.CommandType = CommandType.StoredProcedure;

        //OracleDataAdapter da = new OracleDataAdapter(cmd);
        //DataTable dataAlumno = new DataTable(); 
        //da.Fill(dataAlumno);

        cmd.Parameters.Add("result_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

        using (OracleDataReader reader 
            = cmd.ExecuteReader())
        {
            while (reader.Read())
            {

                int idalumno = int.Parse(reader["idalumno"].ToString());
                string nombre = reader["nombre"].ToString();
                string apellidoPaterno = reader["apellidopaterno"].ToString();
                string apellidoMaterno = reader["apellidomaterno"].ToString();
                DateTime edad = Convert.ToDateTime(reader["fechanacimiento"]);

                Console.WriteLine(idalumno);
                Console.WriteLine(nombre);
                Console.WriteLine(apellidoPaterno);
                Console.WriteLine(apellidoMaterno);
                Console.WriteLine(edad);


            }
        }
    }
}