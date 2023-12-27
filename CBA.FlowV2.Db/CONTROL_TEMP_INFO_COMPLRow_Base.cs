// <fileinfo name="CONTROL_TEMP_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="CONTROL_TEMP_INFO_COMPLRow"/> that 
	/// represents a record in the <c>CONTROL_TEMP_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CONTROL_TEMP_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTROL_TEMP_INFO_COMPLRow_Base
	{
		private decimal _id;
		private string _nro_comprobante;
		private decimal _funcionario_encargado_id;
		private bool _funcionario_encargado_idNull = true;
		private string _funcionario_codigo;
		private string _funcionario_nombre;
		private System.DateTime _fecha;
		private decimal _control_temp_anterior_id;
		private bool _control_temp_anterior_idNull = true;
		private string _control_anterior_numero;
		private string _cargado;
		private string _observaciones;
		private decimal _cantidad_lecturas;
		private bool _cantidad_lecturasNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTROL_TEMP_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public CONTROL_TEMP_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CONTROL_TEMP_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsFUNCIONARIO_ENCARGADO_IDNull != original.IsFUNCIONARIO_ENCARGADO_IDNull) return true;
			if (!this.IsFUNCIONARIO_ENCARGADO_IDNull && !original.IsFUNCIONARIO_ENCARGADO_IDNull)
				if (this.FUNCIONARIO_ENCARGADO_ID != original.FUNCIONARIO_ENCARGADO_ID) return true;
			if (this.FUNCIONARIO_CODIGO != original.FUNCIONARIO_CODIGO) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.IsCONTROL_TEMP_ANTERIOR_IDNull != original.IsCONTROL_TEMP_ANTERIOR_IDNull) return true;
			if (!this.IsCONTROL_TEMP_ANTERIOR_IDNull && !original.IsCONTROL_TEMP_ANTERIOR_IDNull)
				if (this.CONTROL_TEMP_ANTERIOR_ID != original.CONTROL_TEMP_ANTERIOR_ID) return true;
			if (this.CONTROL_ANTERIOR_NUMERO != original.CONTROL_ANTERIOR_NUMERO) return true;
			if (this.CARGADO != original.CARGADO) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
			if (this.IsCANTIDAD_LECTURASNull != original.IsCANTIDAD_LECTURASNull) return true;
			if (!this.IsCANTIDAD_LECTURASNull && !original.IsCANTIDAD_LECTURASNull)
				if (this.CANTIDAD_LECTURAS != original.CANTIDAD_LECTURAS) return true;
			
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
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ENCARGADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ENCARGADO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ENCARGADO_ID
		{
			get
			{
				if(IsFUNCIONARIO_ENCARGADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_encargado_id;
			}
			set
			{
				_funcionario_encargado_idNull = false;
				_funcionario_encargado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ENCARGADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_ENCARGADO_IDNull
		{
			get { return _funcionario_encargado_idNull; }
			set { _funcionario_encargado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_CODIGO</c> column value.</value>
		public string FUNCIONARIO_CODIGO
		{
			get { return _funcionario_codigo; }
			set { _funcionario_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_NOMBRE
		{
			get { return _funcionario_nombre; }
			set { _funcionario_nombre = value; }
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
		/// Gets or sets the <c>CONTROL_TEMP_ANTERIOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTROL_TEMP_ANTERIOR_ID</c> column value.</value>
		public decimal CONTROL_TEMP_ANTERIOR_ID
		{
			get
			{
				if(IsCONTROL_TEMP_ANTERIOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _control_temp_anterior_id;
			}
			set
			{
				_control_temp_anterior_idNull = false;
				_control_temp_anterior_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONTROL_TEMP_ANTERIOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONTROL_TEMP_ANTERIOR_IDNull
		{
			get { return _control_temp_anterior_idNull; }
			set { _control_temp_anterior_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTROL_ANTERIOR_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTROL_ANTERIOR_NUMERO</c> column value.</value>
		public string CONTROL_ANTERIOR_NUMERO
		{
			get { return _control_anterior_numero; }
			set { _control_anterior_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CARGADO</c> column value.
		/// </summary>
		/// <value>The <c>CARGADO</c> column value.</value>
		public string CARGADO
		{
			get { return _cargado; }
			set { _cargado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACIONES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACIONES</c> column value.</value>
		public string OBSERVACIONES
		{
			get { return _observaciones; }
			set { _observaciones = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_LECTURAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_LECTURAS</c> column value.</value>
		public decimal CANTIDAD_LECTURAS
		{
			get
			{
				if(IsCANTIDAD_LECTURASNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_lecturas;
			}
			set
			{
				_cantidad_lecturasNull = false;
				_cantidad_lecturas = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_LECTURAS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_LECTURASNull
		{
			get { return _cantidad_lecturasNull; }
			set { _cantidad_lecturasNull = value; }
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
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FUNCIONARIO_ENCARGADO_ID=");
			dynStr.Append(IsFUNCIONARIO_ENCARGADO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ENCARGADO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_CODIGO=");
			dynStr.Append(FUNCIONARIO_CODIGO);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@CONTROL_TEMP_ANTERIOR_ID=");
			dynStr.Append(IsCONTROL_TEMP_ANTERIOR_IDNull ? (object)"<NULL>" : CONTROL_TEMP_ANTERIOR_ID);
			dynStr.Append("@CBA@CONTROL_ANTERIOR_NUMERO=");
			dynStr.Append(CONTROL_ANTERIOR_NUMERO);
			dynStr.Append("@CBA@CARGADO=");
			dynStr.Append(CARGADO);
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			dynStr.Append("@CBA@CANTIDAD_LECTURAS=");
			dynStr.Append(IsCANTIDAD_LECTURASNull ? (object)"<NULL>" : CANTIDAD_LECTURAS);
			return dynStr.ToString();
		}
	} // End of CONTROL_TEMP_INFO_COMPLRow_Base class
} // End of namespace
