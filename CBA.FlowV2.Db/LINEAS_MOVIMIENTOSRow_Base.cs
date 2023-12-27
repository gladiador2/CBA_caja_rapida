// <fileinfo name="LINEAS_MOVIMIENTOSRow_Base.cs">
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
	/// The base class for <see cref="LINEAS_MOVIMIENTOSRow"/> that 
	/// represents a record in the <c>LINEAS_MOVIMIENTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="LINEAS_MOVIMIENTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LINEAS_MOVIMIENTOSRow_Base
	{
		private decimal _id;
		private decimal _linea_id;
		private string _edi_path;
		private string _edi_estructura;
		private string _movimiento;
		private string _edi_nombre;
		private decimal _tipo_contenedor_id;
		private bool _tipo_contenedor_idNull = true;
		private decimal _linea_movimiento_siguiente_id;
		private bool _linea_movimiento_siguiente_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="LINEAS_MOVIMIENTOSRow_Base"/> class.
		/// </summary>
		public LINEAS_MOVIMIENTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(LINEAS_MOVIMIENTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.LINEA_ID != original.LINEA_ID) return true;
			if (this.EDI_PATH != original.EDI_PATH) return true;
			if (this.EDI_ESTRUCTURA != original.EDI_ESTRUCTURA) return true;
			if (this.MOVIMIENTO != original.MOVIMIENTO) return true;
			if (this.EDI_NOMBRE != original.EDI_NOMBRE) return true;
			if (this.IsTIPO_CONTENEDOR_IDNull != original.IsTIPO_CONTENEDOR_IDNull) return true;
			if (!this.IsTIPO_CONTENEDOR_IDNull && !original.IsTIPO_CONTENEDOR_IDNull)
				if (this.TIPO_CONTENEDOR_ID != original.TIPO_CONTENEDOR_ID) return true;
			if (this.IsLINEA_MOVIMIENTO_SIGUIENTE_IDNull != original.IsLINEA_MOVIMIENTO_SIGUIENTE_IDNull) return true;
			if (!this.IsLINEA_MOVIMIENTO_SIGUIENTE_IDNull && !original.IsLINEA_MOVIMIENTO_SIGUIENTE_IDNull)
				if (this.LINEA_MOVIMIENTO_SIGUIENTE_ID != original.LINEA_MOVIMIENTO_SIGUIENTE_ID) return true;
			
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
		/// Gets or sets the <c>EDI_PATH</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EDI_PATH</c> column value.</value>
		public string EDI_PATH
		{
			get { return _edi_path; }
			set { _edi_path = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EDI_ESTRUCTURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EDI_ESTRUCTURA</c> column value.</value>
		public string EDI_ESTRUCTURA
		{
			get { return _edi_estructura; }
			set { _edi_estructura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOVIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOVIMIENTO</c> column value.</value>
		public string MOVIMIENTO
		{
			get { return _movimiento; }
			set { _movimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EDI_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EDI_NOMBRE</c> column value.</value>
		public string EDI_NOMBRE
		{
			get { return _edi_nombre; }
			set { _edi_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_CONTENEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_CONTENEDOR_ID</c> column value.</value>
		public decimal TIPO_CONTENEDOR_ID
		{
			get
			{
				if(IsTIPO_CONTENEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_contenedor_id;
			}
			set
			{
				_tipo_contenedor_idNull = false;
				_tipo_contenedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_CONTENEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_CONTENEDOR_IDNull
		{
			get { return _tipo_contenedor_idNull; }
			set { _tipo_contenedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LINEA_MOVIMIENTO_SIGUIENTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LINEA_MOVIMIENTO_SIGUIENTE_ID</c> column value.</value>
		public decimal LINEA_MOVIMIENTO_SIGUIENTE_ID
		{
			get
			{
				if(IsLINEA_MOVIMIENTO_SIGUIENTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _linea_movimiento_siguiente_id;
			}
			set
			{
				_linea_movimiento_siguiente_idNull = false;
				_linea_movimiento_siguiente_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LINEA_MOVIMIENTO_SIGUIENTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLINEA_MOVIMIENTO_SIGUIENTE_IDNull
		{
			get { return _linea_movimiento_siguiente_idNull; }
			set { _linea_movimiento_siguiente_idNull = value; }
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
			dynStr.Append("@CBA@EDI_PATH=");
			dynStr.Append(EDI_PATH);
			dynStr.Append("@CBA@EDI_ESTRUCTURA=");
			dynStr.Append(EDI_ESTRUCTURA);
			dynStr.Append("@CBA@MOVIMIENTO=");
			dynStr.Append(MOVIMIENTO);
			dynStr.Append("@CBA@EDI_NOMBRE=");
			dynStr.Append(EDI_NOMBRE);
			dynStr.Append("@CBA@TIPO_CONTENEDOR_ID=");
			dynStr.Append(IsTIPO_CONTENEDOR_IDNull ? (object)"<NULL>" : TIPO_CONTENEDOR_ID);
			dynStr.Append("@CBA@LINEA_MOVIMIENTO_SIGUIENTE_ID=");
			dynStr.Append(IsLINEA_MOVIMIENTO_SIGUIENTE_IDNull ? (object)"<NULL>" : LINEA_MOVIMIENTO_SIGUIENTE_ID);
			return dynStr.ToString();
		}
	} // End of LINEAS_MOVIMIENTOSRow_Base class
} // End of namespace
