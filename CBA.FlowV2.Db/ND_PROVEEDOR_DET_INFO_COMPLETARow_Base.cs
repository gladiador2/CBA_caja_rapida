// <fileinfo name="ND_PROVEEDOR_DET_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="ND_PROVEEDOR_DET_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>ND_PROVEEDOR_DET_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ND_PROVEEDOR_DET_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ND_PROVEEDOR_DET_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _nota_debito_proveedor_id;
		private decimal _factura_relacionada_id;
		private bool _factura_relacionada_idNull = true;
		private string _factura_nrocomprobante;
		private decimal _monto;
		private decimal _porcentaje_impuesto;
		private decimal _monto_impuesto;
		private string _descripcion;
		private string _activo_codigo;

		/// <summary>
		/// Initializes a new instance of the <see cref="ND_PROVEEDOR_DET_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public ND_PROVEEDOR_DET_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ND_PROVEEDOR_DET_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOTA_DEBITO_PROVEEDOR_ID != original.NOTA_DEBITO_PROVEEDOR_ID) return true;
			if (this.IsFACTURA_RELACIONADA_IDNull != original.IsFACTURA_RELACIONADA_IDNull) return true;
			if (!this.IsFACTURA_RELACIONADA_IDNull && !original.IsFACTURA_RELACIONADA_IDNull)
				if (this.FACTURA_RELACIONADA_ID != original.FACTURA_RELACIONADA_ID) return true;
			if (this.FACTURA_NROCOMPROBANTE != original.FACTURA_NROCOMPROBANTE) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.PORCENTAJE_IMPUESTO != original.PORCENTAJE_IMPUESTO) return true;
			if (this.MONTO_IMPUESTO != original.MONTO_IMPUESTO) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.ACTIVO_CODIGO != original.ACTIVO_CODIGO) return true;
			
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
		/// Gets or sets the <c>NOTA_DEBITO_PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>NOTA_DEBITO_PROVEEDOR_ID</c> column value.</value>
		public decimal NOTA_DEBITO_PROVEEDOR_ID
		{
			get { return _nota_debito_proveedor_id; }
			set { _nota_debito_proveedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_RELACIONADA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_RELACIONADA_ID</c> column value.</value>
		public decimal FACTURA_RELACIONADA_ID
		{
			get
			{
				if(IsFACTURA_RELACIONADA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_relacionada_id;
			}
			set
			{
				_factura_relacionada_idNull = false;
				_factura_relacionada_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_RELACIONADA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_RELACIONADA_IDNull
		{
			get { return _factura_relacionada_idNull; }
			set { _factura_relacionada_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_NROCOMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_NROCOMPROBANTE</c> column value.</value>
		public string FACTURA_NROCOMPROBANTE
		{
			get { return _factura_nrocomprobante; }
			set { _factura_nrocomprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get { return _monto; }
			set { _monto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_IMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_IMPUESTO</c> column value.</value>
		public decimal PORCENTAJE_IMPUESTO
		{
			get { return _porcentaje_impuesto; }
			set { _porcentaje_impuesto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_IMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_IMPUESTO</c> column value.</value>
		public decimal MONTO_IMPUESTO
		{
			get { return _monto_impuesto; }
			set { _monto_impuesto = value; }
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
		/// Gets or sets the <c>ACTIVO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_CODIGO</c> column value.</value>
		public string ACTIVO_CODIGO
		{
			get { return _activo_codigo; }
			set { _activo_codigo = value; }
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
			dynStr.Append("@CBA@NOTA_DEBITO_PROVEEDOR_ID=");
			dynStr.Append(NOTA_DEBITO_PROVEEDOR_ID);
			dynStr.Append("@CBA@FACTURA_RELACIONADA_ID=");
			dynStr.Append(IsFACTURA_RELACIONADA_IDNull ? (object)"<NULL>" : FACTURA_RELACIONADA_ID);
			dynStr.Append("@CBA@FACTURA_NROCOMPROBANTE=");
			dynStr.Append(FACTURA_NROCOMPROBANTE);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@PORCENTAJE_IMPUESTO=");
			dynStr.Append(PORCENTAJE_IMPUESTO);
			dynStr.Append("@CBA@MONTO_IMPUESTO=");
			dynStr.Append(MONTO_IMPUESTO);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@ACTIVO_CODIGO=");
			dynStr.Append(ACTIVO_CODIGO);
			return dynStr.ToString();
		}
	} // End of ND_PROVEEDOR_DET_INFO_COMPLETARow_Base class
} // End of namespace
