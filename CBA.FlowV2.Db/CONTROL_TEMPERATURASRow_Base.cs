// <fileinfo name="CONTROL_TEMPERATURASRow_Base.cs">
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
	/// The base class for <see cref="CONTROL_TEMPERATURASRow"/> that 
	/// represents a record in the <c>CONTROL_TEMPERATURAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CONTROL_TEMPERATURASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTROL_TEMPERATURASRow_Base
	{
		private decimal _id;
		private decimal _funcionario_encargado_id;
		private bool _funcionario_encargado_idNull = true;
		private System.DateTime _fecha;
		private decimal _control_temp_anterior_id;
		private bool _control_temp_anterior_idNull = true;
		private string _observaciones;
		private string _nro_comprobante;
		private string _cargado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTROL_TEMPERATURASRow_Base"/> class.
		/// </summary>
		public CONTROL_TEMPERATURASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CONTROL_TEMPERATURASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsFUNCIONARIO_ENCARGADO_IDNull != original.IsFUNCIONARIO_ENCARGADO_IDNull) return true;
			if (!this.IsFUNCIONARIO_ENCARGADO_IDNull && !original.IsFUNCIONARIO_ENCARGADO_IDNull)
				if (this.FUNCIONARIO_ENCARGADO_ID != original.FUNCIONARIO_ENCARGADO_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.IsCONTROL_TEMP_ANTERIOR_IDNull != original.IsCONTROL_TEMP_ANTERIOR_IDNull) return true;
			if (!this.IsCONTROL_TEMP_ANTERIOR_IDNull && !original.IsCONTROL_TEMP_ANTERIOR_IDNull)
				if (this.CONTROL_TEMP_ANTERIOR_ID != original.CONTROL_TEMP_ANTERIOR_ID) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.CARGADO != original.CARGADO) return true;
			
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
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@FUNCIONARIO_ENCARGADO_ID=");
			dynStr.Append(IsFUNCIONARIO_ENCARGADO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ENCARGADO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@CONTROL_TEMP_ANTERIOR_ID=");
			dynStr.Append(IsCONTROL_TEMP_ANTERIOR_IDNull ? (object)"<NULL>" : CONTROL_TEMP_ANTERIOR_ID);
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@CARGADO=");
			dynStr.Append(CARGADO);
			return dynStr.ToString();
		}
	} // End of CONTROL_TEMPERATURASRow_Base class
} // End of namespace
