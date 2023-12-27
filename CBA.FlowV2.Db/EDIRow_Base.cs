// <fileinfo name="EDIRow_Base.cs">
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
	/// The base class for <see cref="EDIRow"/> that 
	/// represents a record in the <c>EDI</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="EDIRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EDIRow_Base
	{
		private decimal _id;
		private decimal _linea_id;
		private decimal _contenedor_id;
		private bool _contenedor_idNull = true;
		private System.DateTime _fecha_creacion;
		private System.DateTime _fecha_operacion;
		private bool _fecha_operacionNull = true;
		private string _campos;
		private string _estructura;
		private decimal _usuario_id;
		private string _estado;
		private string _resultado_exportacion;
		private string _path;
		private decimal _contenedor_movimiento_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="EDIRow_Base"/> class.
		/// </summary>
		public EDIRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(EDIRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.LINEA_ID != original.LINEA_ID) return true;
			if (this.IsCONTENEDOR_IDNull != original.IsCONTENEDOR_IDNull) return true;
			if (!this.IsCONTENEDOR_IDNull && !original.IsCONTENEDOR_IDNull)
				if (this.CONTENEDOR_ID != original.CONTENEDOR_ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsFECHA_OPERACIONNull != original.IsFECHA_OPERACIONNull) return true;
			if (!this.IsFECHA_OPERACIONNull && !original.IsFECHA_OPERACIONNull)
				if (this.FECHA_OPERACION != original.FECHA_OPERACION) return true;
			if (this.CAMPOS != original.CAMPOS) return true;
			if (this.ESTRUCTURA != original.ESTRUCTURA) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.RESULTADO_EXPORTACION != original.RESULTADO_EXPORTACION) return true;
			if (this.PATH != original.PATH) return true;
			if (this.CONTENEDOR_MOVIMIENTO_ID != original.CONTENEDOR_MOVIMIENTO_ID) return true;
			
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
		/// Gets or sets the <c>LINEA_ID</c> column value.
		/// </summary>
		/// <value>The <c>LINEA_ID</c> column value.</value>
		public decimal LINEA_ID
		{
			get { return _linea_id; }
			set { _linea_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENEDOR_ID</c> column value.</value>
		public decimal CONTENEDOR_ID
		{
			get
			{
				if(IsCONTENEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _contenedor_id;
			}
			set
			{
				_contenedor_idNull = false;
				_contenedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONTENEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONTENEDOR_IDNull
		{
			get { return _contenedor_idNull; }
			set { _contenedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_OPERACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_OPERACION</c> column value.</value>
		public System.DateTime FECHA_OPERACION
		{
			get
			{
				if(IsFECHA_OPERACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_operacion;
			}
			set
			{
				_fecha_operacionNull = false;
				_fecha_operacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_OPERACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_OPERACIONNull
		{
			get { return _fecha_operacionNull; }
			set { _fecha_operacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAMPOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAMPOS</c> column value.</value>
		public string CAMPOS
		{
			get { return _campos; }
			set { _campos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTRUCTURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTRUCTURA</c> column value.</value>
		public string ESTRUCTURA
		{
			get { return _estructura; }
			set { _estructura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
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
		/// Gets or sets the <c>RESULTADO_EXPORTACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RESULTADO_EXPORTACION</c> column value.</value>
		public string RESULTADO_EXPORTACION
		{
			get { return _resultado_exportacion; }
			set { _resultado_exportacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PATH</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PATH</c> column value.</value>
		public string PATH
		{
			get { return _path; }
			set { _path = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR_MOVIMIENTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CONTENEDOR_MOVIMIENTO_ID</c> column value.</value>
		public decimal CONTENEDOR_MOVIMIENTO_ID
		{
			get { return _contenedor_movimiento_id; }
			set { _contenedor_movimiento_id = value; }
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
			dynStr.Append("@CBA@LINEA_ID=");
			dynStr.Append(LINEA_ID);
			dynStr.Append("@CBA@CONTENEDOR_ID=");
			dynStr.Append(IsCONTENEDOR_IDNull ? (object)"<NULL>" : CONTENEDOR_ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@FECHA_OPERACION=");
			dynStr.Append(IsFECHA_OPERACIONNull ? (object)"<NULL>" : FECHA_OPERACION);
			dynStr.Append("@CBA@CAMPOS=");
			dynStr.Append(CAMPOS);
			dynStr.Append("@CBA@ESTRUCTURA=");
			dynStr.Append(ESTRUCTURA);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@RESULTADO_EXPORTACION=");
			dynStr.Append(RESULTADO_EXPORTACION);
			dynStr.Append("@CBA@PATH=");
			dynStr.Append(PATH);
			dynStr.Append("@CBA@CONTENEDOR_MOVIMIENTO_ID=");
			dynStr.Append(CONTENEDOR_MOVIMIENTO_ID);
			return dynStr.ToString();
		}
	} // End of EDIRow_Base class
} // End of namespace
