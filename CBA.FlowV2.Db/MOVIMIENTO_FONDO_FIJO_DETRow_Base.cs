// <fileinfo name="MOVIMIENTO_FONDO_FIJO_DETRow_Base.cs">
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
	/// The base class for <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/> that 
	/// represents a record in the <c>MOVIMIENTO_FONDO_FIJO_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="MOVIMIENTO_FONDO_FIJO_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MOVIMIENTO_FONDO_FIJO_DETRow_Base
	{
		private decimal _id;
		private decimal _movimiento_fondo_fijo_id;
		private decimal _tipo_texto_predefinido_id;
		private decimal _texto_predefinido_id;
		private decimal _moneda_origen_id;
		private decimal _moneda_destino_id;
		private decimal _cotizacion_origen;
		private decimal _cotizacion_destino;
		private decimal _monto_ingreso_origen;
		private decimal _monto_ingreso_destino;
		private decimal _cantidad;
		private string _comentario;
		private decimal _monto_egreso_origen;
		private decimal _monto_egreso_destino;
		private decimal _sucursal_movimiento_id;
		private bool _sucursal_movimiento_idNull = true;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private string _estado;
		private string _generar_adelanto_func;
		private string _generar_anticipo_proveedor;

		/// <summary>
		/// Initializes a new instance of the <see cref="MOVIMIENTO_FONDO_FIJO_DETRow_Base"/> class.
		/// </summary>
		public MOVIMIENTO_FONDO_FIJO_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(MOVIMIENTO_FONDO_FIJO_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.MOVIMIENTO_FONDO_FIJO_ID != original.MOVIMIENTO_FONDO_FIJO_ID) return true;
			if (this.TIPO_TEXTO_PREDEFINIDO_ID != original.TIPO_TEXTO_PREDEFINIDO_ID) return true;
			if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.MONEDA_ORIGEN_ID != original.MONEDA_ORIGEN_ID) return true;
			if (this.MONEDA_DESTINO_ID != original.MONEDA_DESTINO_ID) return true;
			if (this.COTIZACION_ORIGEN != original.COTIZACION_ORIGEN) return true;
			if (this.COTIZACION_DESTINO != original.COTIZACION_DESTINO) return true;
			if (this.MONTO_INGRESO_ORIGEN != original.MONTO_INGRESO_ORIGEN) return true;
			if (this.MONTO_INGRESO_DESTINO != original.MONTO_INGRESO_DESTINO) return true;
			if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.COMENTARIO != original.COMENTARIO) return true;
			if (this.MONTO_EGRESO_ORIGEN != original.MONTO_EGRESO_ORIGEN) return true;
			if (this.MONTO_EGRESO_DESTINO != original.MONTO_EGRESO_DESTINO) return true;
			if (this.IsSUCURSAL_MOVIMIENTO_IDNull != original.IsSUCURSAL_MOVIMIENTO_IDNull) return true;
			if (!this.IsSUCURSAL_MOVIMIENTO_IDNull && !original.IsSUCURSAL_MOVIMIENTO_IDNull)
				if (this.SUCURSAL_MOVIMIENTO_ID != original.SUCURSAL_MOVIMIENTO_ID) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.GENERAR_ADELANTO_FUNC != original.GENERAR_ADELANTO_FUNC) return true;
			if (this.GENERAR_ANTICIPO_PROVEEDOR != original.GENERAR_ANTICIPO_PROVEEDOR) return true;
			
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
		/// Gets or sets the <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.
		/// </summary>
		/// <value>The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</value>
		public decimal MOVIMIENTO_FONDO_FIJO_ID
		{
			get { return _movimiento_fondo_fijo_id; }
			set { _movimiento_fondo_fijo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TIPO_TEXTO_PREDEFINIDO_ID
		{
			get { return _tipo_texto_predefinido_id; }
			set { _tipo_texto_predefinido_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get { return _texto_predefinido_id; }
			set { _texto_predefinido_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_ID</c> column value.</value>
		public decimal MONEDA_ORIGEN_ID
		{
			get { return _moneda_origen_id; }
			set { _moneda_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_DESTINO_ID</c> column value.</value>
		public decimal MONEDA_DESTINO_ID
		{
			get { return _moneda_destino_id; }
			set { _moneda_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_ORIGEN</c> column value.</value>
		public decimal COTIZACION_ORIGEN
		{
			get { return _cotizacion_origen; }
			set { _cotizacion_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_DESTINO</c> column value.</value>
		public decimal COTIZACION_DESTINO
		{
			get { return _cotizacion_destino; }
			set { _cotizacion_destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_INGRESO_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_INGRESO_ORIGEN</c> column value.</value>
		public decimal MONTO_INGRESO_ORIGEN
		{
			get { return _monto_ingreso_origen; }
			set { _monto_ingreso_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_INGRESO_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_INGRESO_DESTINO</c> column value.</value>
		public decimal MONTO_INGRESO_DESTINO
		{
			get { return _monto_ingreso_destino; }
			set { _monto_ingreso_destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get { return _cantidad; }
			set { _cantidad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMENTARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMENTARIO</c> column value.</value>
		public string COMENTARIO
		{
			get { return _comentario; }
			set { _comentario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_EGRESO_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_EGRESO_ORIGEN</c> column value.</value>
		public decimal MONTO_EGRESO_ORIGEN
		{
			get { return _monto_egreso_origen; }
			set { _monto_egreso_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_EGRESO_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_EGRESO_DESTINO</c> column value.</value>
		public decimal MONTO_EGRESO_DESTINO
		{
			get { return _monto_egreso_destino; }
			set { _monto_egreso_destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_MOVIMIENTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_MOVIMIENTO_ID</c> column value.</value>
		public decimal SUCURSAL_MOVIMIENTO_ID
		{
			get
			{
				if(IsSUCURSAL_MOVIMIENTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_movimiento_id;
			}
			set
			{
				_sucursal_movimiento_idNull = false;
				_sucursal_movimiento_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_MOVIMIENTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_MOVIMIENTO_IDNull
		{
			get { return _sucursal_movimiento_idNull; }
			set { _sucursal_movimiento_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get
			{
				if(IsFUNCIONARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_id;
			}
			set
			{
				_funcionario_idNull = false;
				_funcionario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_IDNull
		{
			get { return _funcionario_idNull; }
			set { _funcionario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get
			{
				if(IsPROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_id;
			}
			set
			{
				_proveedor_idNull = false;
				_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_IDNull
		{
			get { return _proveedor_idNull; }
			set { _proveedor_idNull = value; }
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
		/// Gets or sets the <c>GENERAR_ADELANTO_FUNC</c> column value.
		/// </summary>
		/// <value>The <c>GENERAR_ADELANTO_FUNC</c> column value.</value>
		public string GENERAR_ADELANTO_FUNC
		{
			get { return _generar_adelanto_func; }
			set { _generar_adelanto_func = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GENERAR_ANTICIPO_PROVEEDOR</c> column value.
		/// </summary>
		/// <value>The <c>GENERAR_ANTICIPO_PROVEEDOR</c> column value.</value>
		public string GENERAR_ANTICIPO_PROVEEDOR
		{
			get { return _generar_anticipo_proveedor; }
			set { _generar_anticipo_proveedor = value; }
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
			dynStr.Append("@CBA@MOVIMIENTO_FONDO_FIJO_ID=");
			dynStr.Append(MOVIMIENTO_FONDO_FIJO_ID);
			dynStr.Append("@CBA@TIPO_TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(TIPO_TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@MONEDA_ORIGEN_ID=");
			dynStr.Append(MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@MONEDA_DESTINO_ID=");
			dynStr.Append(MONEDA_DESTINO_ID);
			dynStr.Append("@CBA@COTIZACION_ORIGEN=");
			dynStr.Append(COTIZACION_ORIGEN);
			dynStr.Append("@CBA@COTIZACION_DESTINO=");
			dynStr.Append(COTIZACION_DESTINO);
			dynStr.Append("@CBA@MONTO_INGRESO_ORIGEN=");
			dynStr.Append(MONTO_INGRESO_ORIGEN);
			dynStr.Append("@CBA@MONTO_INGRESO_DESTINO=");
			dynStr.Append(MONTO_INGRESO_DESTINO);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(CANTIDAD);
			dynStr.Append("@CBA@COMENTARIO=");
			dynStr.Append(COMENTARIO);
			dynStr.Append("@CBA@MONTO_EGRESO_ORIGEN=");
			dynStr.Append(MONTO_EGRESO_ORIGEN);
			dynStr.Append("@CBA@MONTO_EGRESO_DESTINO=");
			dynStr.Append(MONTO_EGRESO_DESTINO);
			dynStr.Append("@CBA@SUCURSAL_MOVIMIENTO_ID=");
			dynStr.Append(IsSUCURSAL_MOVIMIENTO_IDNull ? (object)"<NULL>" : SUCURSAL_MOVIMIENTO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@GENERAR_ADELANTO_FUNC=");
			dynStr.Append(GENERAR_ADELANTO_FUNC);
			dynStr.Append("@CBA@GENERAR_ANTICIPO_PROVEEDOR=");
			dynStr.Append(GENERAR_ANTICIPO_PROVEEDOR);
			return dynStr.ToString();
		}
	} // End of MOVIMIENTO_FONDO_FIJO_DETRow_Base class
} // End of namespace
