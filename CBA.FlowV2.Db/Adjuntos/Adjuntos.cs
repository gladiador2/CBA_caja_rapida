using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace CBA.FlowV2.Db.Adjuntos
{
    public class Adjuntos
    {
        /// <summary>
        /// Gets the adjunto.
        /// </summary>
        /// <param name="tabla">The tabla.</param>
        /// <param name="columna">The columna.</param>
        /// <param name="registro">The registro.</param>
        /// <returns></returns>
        public Byte[] getAdjunto(string tabla, string columna, decimal registro)
        { 
            CBAV2 db = new CBAV2();
            DataTable datos = new DataTable();
            String sql = "select " + columna + " archivo from " + tabla + " where id = " + registro;

            datos = db.EjecutarQuery(sql);
            
            if (datos.Rows.Count > 0)
            {
                System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                return enc.GetBytes(datos.Rows[0]["archivo"].ToString());
            }
            else 
            { 
                return new byte[0];
            }
        }

        /// <summary>
        /// Sets the adjunto.
        /// </summary>
        /// <param name="tabla">The tabla.</param>
        /// <param name="columna_adjunto">The columna_adjunto.</param>
        /// <param name="adjunto">The adjunto.</param>
        /// <param name="columna_extension">The columna_extension.</param>
        /// <param name="extension">The extension.</param>
        /// <param name="registro">The registro.</param>
        public void setAdjunto(string tabla, string columna_adjunto, byte[] adjunto, string columna_extension, string extension, decimal registro)
        {
            CBAV2 db = new CBAV2();
            OracleDataAdapter adapter;
            DataSet ds;
            DataRow dr;

            // Instantiate an OracleDataAdapter object with the
            // appropriate query
            adapter = new OracleDataAdapter(
                        "SELECT id, " + columna_adjunto + ", " + columna_extension +
                        "  FROM " + tabla + " WHERE id = " + registro, db.Connection as OracleConnection);

            // Instantiate a DataSet object
            ds = new DataSet(tabla);

            // Create an UPDATE command as a template for the
            // OracleDataAdapter.
            adapter.UpdateCommand = new OracleCommand
                        ("UPDATE " + tabla + " SET " + columna_adjunto + " = :adjunto , " + columna_extension + " = :extension " + 
                         "where id = " + registro, 
                         db.Connection as OracleConnection);

            adapter.UpdateCommand.Parameters.Add(":adjunto",
                       OracleDbType.Blob, adjunto.Length, columna_adjunto);

            adapter.UpdateCommand.Parameters.Add(":extension",
                       OracleDbType.Varchar2, extension.Length, columna_extension);

            // Configure the schema to match with the Data Source.
            // AddWithKey sets the Primary Key information to complete the
            // schema information
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            // Configures the schema to match with Data Source
            adapter.FillSchema(ds, SchemaType.Source, tabla);

            // Fills the DataSet with table data
            adapter.Fill(ds, tabla);

            // Get the current ID row for updation
            DataTable dt = ds.Tables[tabla];
            dr = dt.Rows.Find(registro);

            // Start the edit operation on the current row in
            // the table within the dataset.
            dr.BeginEdit();

            // Assign the value of the Photo if not empty
            if (adjunto.Length != 0) dr[columna_adjunto] = adjunto;
            
            // Assign the value of the extension if not empty
            if (extension.Length != 0) dr[columna_extension] = extension;

            // End the editing current row operation
            dr.EndEdit();

            // Update the database table
            adapter.Update(ds, tabla);
        }
    }
}



