// <fileinfo name="ITEMS_INGRESOS_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="ITEMS_INGRESOS_DETALLESRow"/> that 
	/// represents a record in the <c>ITEMS_INGRESOS_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ITEMS_INGRESOS_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_INGRESOS_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _items_ingreso_id;
		private bool _items_ingreso_idNull = true;
		private decimal _consignatario_persona_id;
		private bool _consignatario_persona_idNull = true;
		private string _consignatario_nombre;
		private string _conocimiento;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private string _tipo_bulto;
		private string _mercaderia;
		private decimal _valor_neto;
		private bool _valor_netoNull = true;
		private decimal _valor_moneda_id;
		private bool _valor_moneda_idNull = true;
		private string _es_vehiculo;
		private string _estado_vehiculo;
		private string _observaciones;
		private decimal _items_ingreso_deposito_det_id;
		private bool _items_ingreso_deposito_det_idNull = true;
		private decimal _items_ingreso_detalle_ori_id;
		private bool _items_ingreso_detalle_ori_idNull = true;
		private string _desconsolidado;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_INGRESOS_DETALLESRow_Base"/> class.
		/// </summary>
		public ITEMS_INGRESOS_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ITEMS_INGRESOS_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsITEMS_INGRESO_IDNull != original.IsITEMS_INGRESO_IDNull) return true;
			if (!this.IsITEMS_INGRESO_IDNull && !original.IsITEMS_INGRESO_IDNull)
				if (this.ITEMS_INGRESO_ID != original.ITEMS_INGRESO_ID) return true;
			if (this.IsCONSIGNATARIO_PERSONA_IDNull != original.IsCONSIGNATARIO_PERSONA_IDNull) return true;
			if (!this.IsCONSIGNATARIO_PERSONA_IDNull && !original.IsCONSIGNATARIO_PERSONA_IDNull)
				if (this.CONSIGNATARIO_PERSONA_ID != original.CONSIGNATARIO_PERSONA_ID) return true;
			if (this.CONSIGNATARIO_NOMBRE != original.CONSIGNATARIO_NOMBRE) return true;
			if (this.CONOCIMIENTO != original.CONOCIMIENTO) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.TIPO_BULTO != original.TIPO_BULTO) return true;
			if (this.MERCADERIA != original.MERCADERIA) return true;
			if (this.IsVALOR_NETONull != original.IsVALOR_NETONull) return true;
			if (!this.IsVALOR_NETONull && !original.IsVALOR_NETONull)
				if (this.VALOR_NETO != original.VALOR_NETO) return true;
			if (this.IsVALOR_MONEDA_IDNull != original.IsVALOR_MONEDA_IDNull) return true;
			if (!this.IsVALOR_MONEDA_IDNull && !original.IsVALOR_MONEDA_IDNull)
				if (this.VALOR_MONEDA_ID != original.VALOR_MONEDA_ID) return true;
			if (this.ES_VEHICULO != original.ES_VEHICULO) return true;
			if (this.ESTADO_VEHICULO != original.ESTADO_VEHICULO) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
			if (this.IsITEMS_INGRESO_DEPOSITO_DET_IDNull != original.IsITEMS_INGRESO_DEPOSITO_DET_IDNull) return true;
			if (!this.IsITEMS_INGRESO_DEPOSITO_DET_IDNull && !original.IsITEMS_INGRESO_DEPOSITO_DET_IDNull)
				if (this.ITEMS_INGRESO_DEPOSITO_DET_ID != original.ITEMS_INGRESO_DEPOSITO_DET_ID) return true;
			if (this.IsITEMS_INGRESO_DETALLE_ORI_IDNull != original.IsITEMS_INGRESO_DETALLE_ORI_IDNull) return true;
			if (!this.IsITEMS_INGRESO_DETALLE_ORI_IDNull && !original.IsITEMS_INGRESO_DETALLE_ORI_IDNull)
				if (this.ITEMS_INGRESO_DETALLE_ORI_ID != original.ITEMS_INGRESO_DETALLE_ORI_ID) return true;
			if (this.DESCONSOLIDADO != original.DESCONSOLIDADO) return true;
			
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
		/// Gets or sets the <c>ITEMS_INGRESO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ITEMS_INGRESO_ID</c> column value.</value>
		public decimal ITEMS_INGRESO_ID
		{
			get
			{
				if(IsITEMS_INGRESO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _items_ingreso_id;
			}
			set
			{
				_items_ingreso_idNull = false;
				_items_ingreso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ITEMS_INGRESO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsITEMS_INGRESO_IDNull
		{
			get { return _items_ingreso_idNull; }
			set { _items_ingreso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONSIGNATARIO_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</value>
		public decimal CONSIGNATARIO_PERSONA_ID
		{
			get
			{
				if(IsCONSIGNATARIO_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _consignatario_persona_id;
			}
			set
			{
				_consignatario_persona_idNull = false;
				_consignatario_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONSIGNATARIO_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONSIGNATARIO_PERSONA_IDNull
		{
			get { return _consignatario_persona_idNull; }
			set { _consignatario_persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONSIGNATARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONSIGNATARIO_NOMBRE</c> column value.</value>
		public string CONSIGNATARIO_NOMBRE
		{
			get { return _consignatario_nombre; }
			set { _consignatario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONOCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONOCIMIENTO</c> column value.</value>
		public string CONOCIMIENTO
		{
			get { return _conocimiento; }
			set { _conocimiento = value; }
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
		/// Gets or sets the <c>TIPO_BULTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_BULTO</c> column value.</value>
		public string TIPO_BULTO
		{
			get { return _tipo_bulto; }
			set { _tipo_bulto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MERCADERIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MERCADERIA</c> column value.</value>
		public string MERCADERIA
		{
			get { return _mercaderia; }
			set { _mercaderia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_NETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_NETO</c> column value.</value>
		public decimal VALOR_NETO
		{
			get
			{
				if(IsVALOR_NETONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _valor_neto;
			}
			set
			{
				_valor_netoNull = false;
				_valor_neto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VALOR_NETO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVALOR_NETONull
		{
			get { return _valor_netoNull; }
			set { _valor_netoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_MONEDA_ID</c> column value.</value>
		public decimal VALOR_MONEDA_ID
		{
			get
			{
				if(IsVALOR_MONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _valor_moneda_id;
			}
			set
			{
				_valor_moneda_idNull = false;
				_valor_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VALOR_MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVALOR_MONEDA_IDNull
		{
			get { return _valor_moneda_idNull; }
			set { _valor_moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_VEHICULO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ES_VEHICULO</c> column value.</value>
		public string ES_VEHICULO
		{
			get { return _es_vehiculo; }
			set { _es_vehiculo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_VEHICULO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_VEHICULO</c> column value.</value>
		public string ESTADO_VEHICULO
		{
			get { return _estado_vehiculo; }
			set { _estado_vehiculo = value; }
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
		/// Gets or sets the <c>ITEMS_INGRESO_DEPOSITO_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ITEMS_INGRESO_DEPOSITO_DET_ID</c> column value.</value>
		public decimal ITEMS_INGRESO_DEPOSITO_DET_ID
		{
			get
			{
				if(IsITEMS_INGRESO_DEPOSITO_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _items_ingreso_deposito_det_id;
			}
			set
			{
				_items_ingreso_deposito_det_idNull = false;
				_items_ingreso_deposito_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ITEMS_INGRESO_DEPOSITO_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsITEMS_INGRESO_DEPOSITO_DET_IDNull
		{
			get { return _items_ingreso_deposito_det_idNull; }
			set { _items_ingreso_deposito_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ITEMS_INGRESO_DETALLE_ORI_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ITEMS_INGRESO_DETALLE_ORI_ID</c> column value.</value>
		public decimal ITEMS_INGRESO_DETALLE_ORI_ID
		{
			get
			{
				if(IsITEMS_INGRESO_DETALLE_ORI_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _items_ingreso_detalle_ori_id;
			}
			set
			{
				_items_ingreso_detalle_ori_idNull = false;
				_items_ingreso_detalle_ori_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ITEMS_INGRESO_DETALLE_ORI_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsITEMS_INGRESO_DETALLE_ORI_IDNull
		{
			get { return _items_ingreso_detalle_ori_idNull; }
			set { _items_ingreso_detalle_ori_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCONSOLIDADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCONSOLIDADO</c> column value.</value>
		public string DESCONSOLIDADO
		{
			get { return _desconsolidado; }
			set { _desconsolidado = value; }
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
			dynStr.Append("@CBA@ITEMS_INGRESO_ID=");
			dynStr.Append(IsITEMS_INGRESO_IDNull ? (object)"<NULL>" : ITEMS_INGRESO_ID);
			dynStr.Append("@CBA@CONSIGNATARIO_PERSONA_ID=");
			dynStr.Append(IsCONSIGNATARIO_PERSONA_IDNull ? (object)"<NULL>" : CONSIGNATARIO_PERSONA_ID);
			dynStr.Append("@CBA@CONSIGNATARIO_NOMBRE=");
			dynStr.Append(CONSIGNATARIO_NOMBRE);
			dynStr.Append("@CBA@CONOCIMIENTO=");
			dynStr.Append(CONOCIMIENTO);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@TIPO_BULTO=");
			dynStr.Append(TIPO_BULTO);
			dynStr.Append("@CBA@MERCADERIA=");
			dynStr.Append(MERCADERIA);
			dynStr.Append("@CBA@VALOR_NETO=");
			dynStr.Append(IsVALOR_NETONull ? (object)"<NULL>" : VALOR_NETO);
			dynStr.Append("@CBA@VALOR_MONEDA_ID=");
			dynStr.Append(IsVALOR_MONEDA_IDNull ? (object)"<NULL>" : VALOR_MONEDA_ID);
			dynStr.Append("@CBA@ES_VEHICULO=");
			dynStr.Append(ES_VEHICULO);
			dynStr.Append("@CBA@ESTADO_VEHICULO=");
			dynStr.Append(ESTADO_VEHICULO);
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			dynStr.Append("@CBA@ITEMS_INGRESO_DEPOSITO_DET_ID=");
			dynStr.Append(IsITEMS_INGRESO_DEPOSITO_DET_IDNull ? (object)"<NULL>" : ITEMS_INGRESO_DEPOSITO_DET_ID);
			dynStr.Append("@CBA@ITEMS_INGRESO_DETALLE_ORI_ID=");
			dynStr.Append(IsITEMS_INGRESO_DETALLE_ORI_IDNull ? (object)"<NULL>" : ITEMS_INGRESO_DETALLE_ORI_ID);
			dynStr.Append("@CBA@DESCONSOLIDADO=");
			dynStr.Append(DESCONSOLIDADO);
			return dynStr.ToString();
		}
	} // End of ITEMS_INGRESOS_DETALLESRow_Base class
} // End of namespace
