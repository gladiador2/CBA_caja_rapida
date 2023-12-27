// <fileinfo name="TIPOS_NOTAS_CREDITORow_Base.cs">
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
	/// The base class for <see cref="TIPOS_NOTAS_CREDITORow"/> that 
	/// represents a record in the <c>TIPOS_NOTAS_CREDITO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TIPOS_NOTAS_CREDITORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TIPOS_NOTAS_CREDITORow_Base
	{
		private decimal _id;
		private string _descripcion;
		private string _prefijo;
		private decimal _rol_id;
		private decimal _dias_desde_factura;
		private bool _dias_desde_facturaNull = true;
		private string _comisiona;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_NOTAS_CREDITORow_Base"/> class.
		/// </summary>
		public TIPOS_NOTAS_CREDITORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TIPOS_NOTAS_CREDITORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.PREFIJO != original.PREFIJO) return true;
			if (this.ROL_ID != original.ROL_ID) return true;
			if (this.IsDIAS_DESDE_FACTURANull != original.IsDIAS_DESDE_FACTURANull) return true;
			if (!this.IsDIAS_DESDE_FACTURANull && !original.IsDIAS_DESDE_FACTURANull)
				if (this.DIAS_DESDE_FACTURA != original.DIAS_DESDE_FACTURA) return true;
			if (this.COMISIONA != original.COMISIONA) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PREFIJO</c> column value.
		/// </summary>
		/// <value>The <c>PREFIJO</c> column value.</value>
		public string PREFIJO
		{
			get { return _prefijo; }
			set { _prefijo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ROL_ID</c> column value.
		/// </summary>
		/// <value>The <c>ROL_ID</c> column value.</value>
		public decimal ROL_ID
		{
			get { return _rol_id; }
			set { _rol_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIAS_DESDE_FACTURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIAS_DESDE_FACTURA</c> column value.</value>
		public decimal DIAS_DESDE_FACTURA
		{
			get
			{
				if(IsDIAS_DESDE_FACTURANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _dias_desde_factura;
			}
			set
			{
				_dias_desde_facturaNull = false;
				_dias_desde_factura = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DIAS_DESDE_FACTURA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDIAS_DESDE_FACTURANull
		{
			get { return _dias_desde_facturaNull; }
			set { _dias_desde_facturaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISIONA</c> column value.
		/// </summary>
		/// <value>The <c>COMISIONA</c> column value.</value>
		public string COMISIONA
		{
			get { return _comisiona; }
			set { _comisiona = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@PREFIJO=");
			dynStr.Append(PREFIJO);
			dynStr.Append("@CBA@ROL_ID=");
			dynStr.Append(ROL_ID);
			dynStr.Append("@CBA@DIAS_DESDE_FACTURA=");
			dynStr.Append(IsDIAS_DESDE_FACTURANull ? (object)"<NULL>" : DIAS_DESDE_FACTURA);
			dynStr.Append("@CBA@COMISIONA=");
			dynStr.Append(COMISIONA);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of TIPOS_NOTAS_CREDITORow_Base class
} // End of namespace
