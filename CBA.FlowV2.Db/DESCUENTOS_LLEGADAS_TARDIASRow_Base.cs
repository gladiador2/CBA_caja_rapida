// <fileinfo name="DESCUENTOS_LLEGADAS_TARDIASRow_Base.cs">
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
	/// The base class for <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> that 
	/// represents a record in the <c>DESCUENTOS_LLEGADAS_TARDIAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESCUENTOS_LLEGADAS_TARDIASRow_Base
	{
		private decimal _id;
		private decimal _tipo_regla;
		private string _descripcion;
		private string _estado;
		private decimal _horario_id;
		private string _aplicar_tolerancia;
		private string _aplicar_desc_monto_fijo;
		private decimal _orden;
		private bool _ordenNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESCUENTOS_LLEGADAS_TARDIASRow_Base"/> class.
		/// </summary>
		public DESCUENTOS_LLEGADAS_TARDIASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DESCUENTOS_LLEGADAS_TARDIASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO_REGLA != original.TIPO_REGLA) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.HORARIO_ID != original.HORARIO_ID) return true;
			if (this.APLICAR_TOLERANCIA != original.APLICAR_TOLERANCIA) return true;
			if (this.APLICAR_DESC_MONTO_FIJO != original.APLICAR_DESC_MONTO_FIJO) return true;
			if (this.IsORDENNull != original.IsORDENNull) return true;
			if (!this.IsORDENNull && !original.IsORDENNull)
				if (this.ORDEN != original.ORDEN) return true;
			
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
		/// Gets or sets the <c>TIPO_REGLA</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_REGLA</c> column value.</value>
		public decimal TIPO_REGLA
		{
			get { return _tipo_regla; }
			set { _tipo_regla = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
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
		/// Gets or sets the <c>HORARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>HORARIO_ID</c> column value.</value>
		public decimal HORARIO_ID
		{
			get { return _horario_id; }
			set { _horario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICAR_TOLERANCIA</c> column value.
		/// </summary>
		/// <value>The <c>APLICAR_TOLERANCIA</c> column value.</value>
		public string APLICAR_TOLERANCIA
		{
			get { return _aplicar_tolerancia; }
			set { _aplicar_tolerancia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICAR_DESC_MONTO_FIJO</c> column value.
		/// </summary>
		/// <value>The <c>APLICAR_DESC_MONTO_FIJO</c> column value.</value>
		public string APLICAR_DESC_MONTO_FIJO
		{
			get { return _aplicar_desc_monto_fijo; }
			set { _aplicar_desc_monto_fijo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public decimal ORDEN
		{
			get
			{
				if(IsORDENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden;
			}
			set
			{
				_ordenNull = false;
				_orden = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDENNull
		{
			get { return _ordenNull; }
			set { _ordenNull = value; }
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
			dynStr.Append("@CBA@TIPO_REGLA=");
			dynStr.Append(TIPO_REGLA);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@HORARIO_ID=");
			dynStr.Append(HORARIO_ID);
			dynStr.Append("@CBA@APLICAR_TOLERANCIA=");
			dynStr.Append(APLICAR_TOLERANCIA);
			dynStr.Append("@CBA@APLICAR_DESC_MONTO_FIJO=");
			dynStr.Append(APLICAR_DESC_MONTO_FIJO);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(IsORDENNull ? (object)"<NULL>" : ORDEN);
			return dynStr.ToString();
		}
	} // End of DESCUENTOS_LLEGADAS_TARDIASRow_Base class
} // End of namespace
