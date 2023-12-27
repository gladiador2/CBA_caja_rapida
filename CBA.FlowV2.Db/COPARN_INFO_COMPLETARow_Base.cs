// <fileinfo name="COPARN_INFO_COMPLETARow_Base.cs">
//		<copyright>
//			All rights reserved.
//		</copyright>
//		<remarks>
//			Do not change this source code manually. Changes to this file may 
//			cause incorrect behavior and will be lost if the code is regenerated.
//		</remarks>
//		<generator rewritefile="True" infourl="http://www.SharpPower.com">RapTier</generator>
// </fileinfo>

using System;

namespace CBA.FlowV2.Db
{
	/// <summary>
	/// The base class for <see cref="COPARN_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>COPARN_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="COPARN_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class COPARN_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private System.DateTime _fecha;
		private decimal _linea_id;
		private string _linea_nombre;
		private string _tipo_coparn;
		private string _booking;
		private string _cliente;
		private decimal _cantidad_contenedores;
		private string _buque;
		private string _nombre_archivo_coparn;
		private decimal _adjunto_id;
		private bool _adjunto_idNull = true;
		private string _estado;
		private string _procesado;
		private decimal _nomina_contenedores_id;
		private bool _nomina_contenedores_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="COPARN_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public COPARN_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(COPARN_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.LINEA_ID != original.LINEA_ID) return true;
			if (this.LINEA_NOMBRE != original.LINEA_NOMBRE) return true;
			if (this.TIPO_COPARN != original.TIPO_COPARN) return true;
			if (this.BOOKING != original.BOOKING) return true;
			if (this.CLIENTE != original.CLIENTE) return true;
			if (this.CANTIDAD_CONTENEDORES != original.CANTIDAD_CONTENEDORES) return true;
			if (this.BUQUE != original.BUQUE) return true;
			if (this.NOMBRE_ARCHIVO_COPARN != original.NOMBRE_ARCHIVO_COPARN) return true;
			if (this.IsADJUNTO_IDNull != original.IsADJUNTO_IDNull) return true;
			if (!this.IsADJUNTO_IDNull && !original.IsADJUNTO_IDNull)
				if (this.ADJUNTO_ID != original.ADJUNTO_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.PROCESADO != original.PROCESADO) return true;
			if (this.IsNOMINA_CONTENEDORES_IDNull != original.IsNOMINA_CONTENEDORES_IDNull) return true;
			if (!this.IsNOMINA_CONTENEDORES_IDNull && !original.IsNOMINA_CONTENEDORES_IDNull)
				if (this.NOMINA_CONTENEDORES_ID != original.NOMINA_CONTENEDORES_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get { return _id; }
			set { _id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LINEA_ID</c> column value.
		/// </summary>
		/// <value>The <c>LINEA_ID</c> column value.</value>
		public decimal LINEA_ID
		{
			get { return _linea_id; }
			set { _linea_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LINEA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LINEA_NOMBRE</c> column value.</value>
		public string LINEA_NOMBRE
		{
			get { return _linea_nombre; }
			set { _linea_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_COPARN</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_COPARN</c> column value.</value>
		public string TIPO_COPARN
		{
			get { return _tipo_coparn; }
			set { _tipo_coparn = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BOOKING</c> column value.
		/// </summary>
		/// <value>The <c>BOOKING</c> column value.</value>
		public string BOOKING
		{
			get { return _booking; }
			set { _booking = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CLIENTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CLIENTE</c> column value.</value>
		public string CLIENTE
		{
			get { return _cliente; }
			set { _cliente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_CONTENEDORES</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_CONTENEDORES</c> column value.</value>
		public decimal CANTIDAD_CONTENEDORES
		{
			get { return _cantidad_contenedores; }
			set { _cantidad_contenedores = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BUQUE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BUQUE</c> column value.</value>
		public string BUQUE
		{
			get { return _buque; }
			set { _buque = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_ARCHIVO_COPARN</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE_ARCHIVO_COPARN</c> column value.</value>
		public string NOMBRE_ARCHIVO_COPARN
		{
			get { return _nombre_archivo_coparn; }
			set { _nombre_archivo_coparn = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ADJUNTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ADJUNTO_ID</c> column value.</value>
		public decimal ADJUNTO_ID
		{
			get
			{
				if(IsADJUNTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _adjunto_id;
			}
			set
			{
				_adjunto_idNull = false;
				_adjunto_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ADJUNTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsADJUNTO_IDNull
		{
			get { return _adjunto_idNull; }
			set { _adjunto_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROCESADO</c> column value.
		/// </summary>
		/// <value>The <c>PROCESADO</c> column value.</value>
		public string PROCESADO
		{
			get { return _procesado; }
			set { _procesado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMINA_CONTENEDORES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMINA_CONTENEDORES_ID</c> column value.</value>
		public decimal NOMINA_CONTENEDORES_ID
		{
			get
			{
				if(IsNOMINA_CONTENEDORES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nomina_contenedores_id;
			}
			set
			{
				_nomina_contenedores_idNull = false;
				_nomina_contenedores_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NOMINA_CONTENEDORES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNOMINA_CONTENEDORES_IDNull
		{
			get { return _nomina_contenedores_idNull; }
			set { _nomina_contenedores_idNull = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@LINEA_ID=");
			dynStr.Append(LINEA_ID);
			dynStr.Append("@CBA@LINEA_NOMBRE=");
			dynStr.Append(LINEA_NOMBRE);
			dynStr.Append("@CBA@TIPO_COPARN=");
			dynStr.Append(TIPO_COPARN);
			dynStr.Append("@CBA@BOOKING=");
			dynStr.Append(BOOKING);
			dynStr.Append("@CBA@CLIENTE=");
			dynStr.Append(CLIENTE);
			dynStr.Append("@CBA@CANTIDAD_CONTENEDORES=");
			dynStr.Append(CANTIDAD_CONTENEDORES);
			dynStr.Append("@CBA@BUQUE=");
			dynStr.Append(BUQUE);
			dynStr.Append("@CBA@NOMBRE_ARCHIVO_COPARN=");
			dynStr.Append(NOMBRE_ARCHIVO_COPARN);
			dynStr.Append("@CBA@ADJUNTO_ID=");
			dynStr.Append(IsADJUNTO_IDNull ? (object)"<NULL>" : ADJUNTO_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@PROCESADO=");
			dynStr.Append(PROCESADO);
			dynStr.Append("@CBA@NOMINA_CONTENEDORES_ID=");
			dynStr.Append(IsNOMINA_CONTENEDORES_IDNull ? (object)"<NULL>" : NOMINA_CONTENEDORES_ID);
			return dynStr.ToString();
		}
	} // End of COPARN_INFO_COMPLETARow_Base class
} // End of namespace
