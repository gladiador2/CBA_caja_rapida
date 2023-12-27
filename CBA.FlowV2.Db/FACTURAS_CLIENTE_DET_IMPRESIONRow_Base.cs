// <fileinfo name="FACTURAS_CLIENTE_DET_IMPRESIONRow_Base.cs">
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
	/// The base class for <see cref="FACTURAS_CLIENTE_DET_IMPRESIONRow"/> that 
	/// represents a record in the <c>FACTURAS_CLIENTE_DET_IMPRESION</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FACTURAS_CLIENTE_DET_IMPRESIONRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_CLIENTE_DET_IMPRESIONRow_Base
	{
		private decimal _facturas_cliente_id;
		private bool _facturas_cliente_idNull = true;
		private decimal _orden;
		private bool _ordenNull = true;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private string _articulo_descripcion;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private decimal _impuesto_id;
		private bool _impuesto_idNull = true;
		private decimal _total_monto_bruto;
		private bool _total_monto_brutoNull = true;
		private decimal _precio_lista;
		private bool _precio_listaNull = true;
		private decimal _total_monto_impuesto;
		private bool _total_monto_impuestoNull = true;
		private decimal _porcentaje_impuesto;
		private bool _porcentaje_impuestoNull = true;
		private decimal _caso_id;
		private bool _caso_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_CLIENTE_DET_IMPRESIONRow_Base"/> class.
		/// </summary>
		public FACTURAS_CLIENTE_DET_IMPRESIONRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FACTURAS_CLIENTE_DET_IMPRESIONRow_Base original)
		{
			if (this.IsFACTURAS_CLIENTE_IDNull != original.IsFACTURAS_CLIENTE_IDNull) return true;
			if (!this.IsFACTURAS_CLIENTE_IDNull && !original.IsFACTURAS_CLIENTE_IDNull)
				if (this.FACTURAS_CLIENTE_ID != original.FACTURAS_CLIENTE_ID) return true;
			if (this.IsORDENNull != original.IsORDENNull) return true;
			if (!this.IsORDENNull && !original.IsORDENNull)
				if (this.ORDEN != original.ORDEN) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.ARTICULO_DESCRIPCION != original.ARTICULO_DESCRIPCION) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.IsIMPUESTO_IDNull != original.IsIMPUESTO_IDNull) return true;
			if (!this.IsIMPUESTO_IDNull && !original.IsIMPUESTO_IDNull)
				if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.IsTOTAL_MONTO_BRUTONull != original.IsTOTAL_MONTO_BRUTONull) return true;
			if (!this.IsTOTAL_MONTO_BRUTONull && !original.IsTOTAL_MONTO_BRUTONull)
				if (this.TOTAL_MONTO_BRUTO != original.TOTAL_MONTO_BRUTO) return true;
			if (this.IsPRECIO_LISTANull != original.IsPRECIO_LISTANull) return true;
			if (!this.IsPRECIO_LISTANull && !original.IsPRECIO_LISTANull)
				if (this.PRECIO_LISTA != original.PRECIO_LISTA) return true;
			if (this.IsTOTAL_MONTO_IMPUESTONull != original.IsTOTAL_MONTO_IMPUESTONull) return true;
			if (!this.IsTOTAL_MONTO_IMPUESTONull && !original.IsTOTAL_MONTO_IMPUESTONull)
				if (this.TOTAL_MONTO_IMPUESTO != original.TOTAL_MONTO_IMPUESTO) return true;
			if (this.IsPORCENTAJE_IMPUESTONull != original.IsPORCENTAJE_IMPUESTONull) return true;
			if (!this.IsPORCENTAJE_IMPUESTONull && !original.IsPORCENTAJE_IMPUESTONull)
				if (this.PORCENTAJE_IMPUESTO != original.PORCENTAJE_IMPUESTO) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURAS_CLIENTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURAS_CLIENTE_ID</c> column value.</value>
		public decimal FACTURAS_CLIENTE_ID
		{
			get
			{
				if(IsFACTURAS_CLIENTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _facturas_cliente_id;
			}
			set
			{
				_facturas_cliente_idNull = false;
				_facturas_cliente_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURAS_CLIENTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURAS_CLIENTE_IDNull
		{
			get { return _facturas_cliente_idNull; }
			set { _facturas_cliente_idNull = value; }
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
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get
			{
				if(IsARTICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_id;
			}
			set
			{
				_articulo_idNull = false;
				_articulo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_IDNull
		{
			get { return _articulo_idNull; }
			set { _articulo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_DESCRIPCION</c> column value.</value>
		public string ARTICULO_DESCRIPCION
		{
			get { return _articulo_descripcion; }
			set { _articulo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get
			{
				if(IsCANTIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad;
			}
			set
			{
				_cantidadNull = false;
				_cantidad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDADNull
		{
			get { return _cantidadNull; }
			set { _cantidadNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUESTO_ID</c> column value.</value>
		public decimal IMPUESTO_ID
		{
			get
			{
				if(IsIMPUESTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _impuesto_id;
			}
			set
			{
				_impuesto_idNull = false;
				_impuesto_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPUESTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPUESTO_IDNull
		{
			get { return _impuesto_idNull; }
			set { _impuesto_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_BRUTO</c> column value.</value>
		public decimal TOTAL_MONTO_BRUTO
		{
			get
			{
				if(IsTOTAL_MONTO_BRUTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_bruto;
			}
			set
			{
				_total_monto_brutoNull = false;
				_total_monto_bruto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_BRUTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_BRUTONull
		{
			get { return _total_monto_brutoNull; }
			set { _total_monto_brutoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECIO_LISTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECIO_LISTA</c> column value.</value>
		public decimal PRECIO_LISTA
		{
			get
			{
				if(IsPRECIO_LISTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _precio_lista;
			}
			set
			{
				_precio_listaNull = false;
				_precio_lista = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PRECIO_LISTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPRECIO_LISTANull
		{
			get { return _precio_listaNull; }
			set { _precio_listaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_IMPUESTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_IMPUESTO</c> column value.</value>
		public decimal TOTAL_MONTO_IMPUESTO
		{
			get
			{
				if(IsTOTAL_MONTO_IMPUESTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_impuesto;
			}
			set
			{
				_total_monto_impuestoNull = false;
				_total_monto_impuesto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_IMPUESTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_IMPUESTONull
		{
			get { return _total_monto_impuestoNull; }
			set { _total_monto_impuestoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_IMPUESTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_IMPUESTO</c> column value.</value>
		public decimal PORCENTAJE_IMPUESTO
		{
			get
			{
				if(IsPORCENTAJE_IMPUESTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_impuesto;
			}
			set
			{
				_porcentaje_impuestoNull = false;
				_porcentaje_impuesto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_IMPUESTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_IMPUESTONull
		{
			get { return _porcentaje_impuestoNull; }
			set { _porcentaje_impuestoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get
			{
				if(IsCASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id;
			}
			set
			{
				_caso_idNull = false;
				_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_IDNull
		{
			get { return _caso_idNull; }
			set { _caso_idNull = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@FACTURAS_CLIENTE_ID=");
			dynStr.Append(IsFACTURAS_CLIENTE_IDNull ? (object)"<NULL>" : FACTURAS_CLIENTE_ID);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(IsORDENNull ? (object)"<NULL>" : ORDEN);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_DESCRIPCION=");
			dynStr.Append(ARTICULO_DESCRIPCION);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IsIMPUESTO_IDNull ? (object)"<NULL>" : IMPUESTO_ID);
			dynStr.Append("@CBA@TOTAL_MONTO_BRUTO=");
			dynStr.Append(IsTOTAL_MONTO_BRUTONull ? (object)"<NULL>" : TOTAL_MONTO_BRUTO);
			dynStr.Append("@CBA@PRECIO_LISTA=");
			dynStr.Append(IsPRECIO_LISTANull ? (object)"<NULL>" : PRECIO_LISTA);
			dynStr.Append("@CBA@TOTAL_MONTO_IMPUESTO=");
			dynStr.Append(IsTOTAL_MONTO_IMPUESTONull ? (object)"<NULL>" : TOTAL_MONTO_IMPUESTO);
			dynStr.Append("@CBA@PORCENTAJE_IMPUESTO=");
			dynStr.Append(IsPORCENTAJE_IMPUESTONull ? (object)"<NULL>" : PORCENTAJE_IMPUESTO);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			return dynStr.ToString();
		}
	} // End of FACTURAS_CLIENTE_DET_IMPRESIONRow_Base class
} // End of namespace
