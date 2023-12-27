// <fileinfo name="GEN_FC_CLIENTES_ARTICULOSRow_Base.cs">
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
	/// The base class for <see cref="GEN_FC_CLIENTES_ARTICULOSRow"/> that 
	/// represents a record in the <c>GEN_FC_CLIENTES_ARTICULOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="GEN_FC_CLIENTES_ARTICULOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class GEN_FC_CLIENTES_ARTICULOSRow_Base
	{
		private decimal _id;
		private decimal _generacion_fc_cliente_id;
		private decimal _articulo_id;
		private decimal _precio;
		private string _observacion;
		private decimal _impuesto_id;
		private bool _impuesto_idNull = true;
		private decimal _porcentaje_dto;
		private bool _porcentaje_dtoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="GEN_FC_CLIENTES_ARTICULOSRow_Base"/> class.
		/// </summary>
		public GEN_FC_CLIENTES_ARTICULOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(GEN_FC_CLIENTES_ARTICULOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.GENERACION_FC_CLIENTE_ID != original.GENERACION_FC_CLIENTE_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.PRECIO != original.PRECIO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsIMPUESTO_IDNull != original.IsIMPUESTO_IDNull) return true;
			if (!this.IsIMPUESTO_IDNull && !original.IsIMPUESTO_IDNull)
				if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.IsPORCENTAJE_DTONull != original.IsPORCENTAJE_DTONull) return true;
			if (!this.IsPORCENTAJE_DTONull && !original.IsPORCENTAJE_DTONull)
				if (this.PORCENTAJE_DTO != original.PORCENTAJE_DTO) return true;
			
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
		/// Gets or sets the <c>GENERACION_FC_CLIENTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>GENERACION_FC_CLIENTE_ID</c> column value.</value>
		public decimal GENERACION_FC_CLIENTE_ID
		{
			get { return _generacion_fc_cliente_id; }
			set { _generacion_fc_cliente_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECIO</c> column value.
		/// </summary>
		/// <value>The <c>PRECIO</c> column value.</value>
		public decimal PRECIO
		{
			get { return _precio; }
			set { _precio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
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
		/// Gets or sets the <c>PORCENTAJE_DTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_DTO</c> column value.</value>
		public decimal PORCENTAJE_DTO
		{
			get
			{
				if(IsPORCENTAJE_DTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_dto;
			}
			set
			{
				_porcentaje_dtoNull = false;
				_porcentaje_dto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_DTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_DTONull
		{
			get { return _porcentaje_dtoNull; }
			set { _porcentaje_dtoNull = value; }
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
			dynStr.Append("@CBA@GENERACION_FC_CLIENTE_ID=");
			dynStr.Append(GENERACION_FC_CLIENTE_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@PRECIO=");
			dynStr.Append(PRECIO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IsIMPUESTO_IDNull ? (object)"<NULL>" : IMPUESTO_ID);
			dynStr.Append("@CBA@PORCENTAJE_DTO=");
			dynStr.Append(IsPORCENTAJE_DTONull ? (object)"<NULL>" : PORCENTAJE_DTO);
			return dynStr.ToString();
		}
	} // End of GEN_FC_CLIENTES_ARTICULOSRow_Base class
} // End of namespace
