// <fileinfo name="FUNCIONARIOS_DESCUENTOSRow_Base.cs">
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
	/// The base class for <see cref="FUNCIONARIOS_DESCUENTOSRow"/> that 
	/// represents a record in the <c>FUNCIONARIOS_DESCUENTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FUNCIONARIOS_DESCUENTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNCIONARIOS_DESCUENTOSRow_Base
	{
		private decimal _id;
		private decimal _descuento_id;
		private decimal _funcionario_id;
		private decimal _empresa_seccion_id;
		private bool _empresa_seccion_idNull = true;
		private decimal _moneda_id;
		private decimal _cotizacion_moneda;
		private decimal _monto;
		private bool _montoNull = true;
		private string _utilizar_porcentaje;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_creacion_id;
		private decimal _liquidacion_asociada_id;
		private bool _liquidacion_asociada_idNull = true;
		private string _consumo_visitas;
		private string _observacion;
		private string _estado;
		private decimal _caso_origen_id;
		private bool _caso_origen_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_DESCUENTOSRow_Base"/> class.
		/// </summary>
		public FUNCIONARIOS_DESCUENTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FUNCIONARIOS_DESCUENTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DESCUENTO_ID != original.DESCUENTO_ID) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.IsEMPRESA_SECCION_IDNull != original.IsEMPRESA_SECCION_IDNull) return true;
			if (!this.IsEMPRESA_SECCION_IDNull && !original.IsEMPRESA_SECCION_IDNull)
				if (this.EMPRESA_SECCION_ID != original.EMPRESA_SECCION_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.IsMONTONull != original.IsMONTONull) return true;
			if (!this.IsMONTONull && !original.IsMONTONull)
				if (this.MONTO != original.MONTO) return true;
			if (this.UTILIZAR_PORCENTAJE != original.UTILIZAR_PORCENTAJE) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.IsLIQUIDACION_ASOCIADA_IDNull != original.IsLIQUIDACION_ASOCIADA_IDNull) return true;
			if (!this.IsLIQUIDACION_ASOCIADA_IDNull && !original.IsLIQUIDACION_ASOCIADA_IDNull)
				if (this.LIQUIDACION_ASOCIADA_ID != original.LIQUIDACION_ASOCIADA_ID) return true;
			if (this.CONSUMO_VISITAS != original.CONSUMO_VISITAS) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsCASO_ORIGEN_IDNull != original.IsCASO_ORIGEN_IDNull) return true;
			if (!this.IsCASO_ORIGEN_IDNull && !original.IsCASO_ORIGEN_IDNull)
				if (this.CASO_ORIGEN_ID != original.CASO_ORIGEN_ID) return true;
			
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
		/// Gets or sets the <c>DESCUENTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>DESCUENTO_ID</c> column value.</value>
		public decimal DESCUENTO_ID
		{
			get { return _descuento_id; }
			set { _descuento_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get { return _funcionario_id; }
			set { _funcionario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_SECCION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMPRESA_SECCION_ID</c> column value.</value>
		public decimal EMPRESA_SECCION_ID
		{
			get
			{
				if(IsEMPRESA_SECCION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _empresa_seccion_id;
			}
			set
			{
				_empresa_seccion_idNull = false;
				_empresa_seccion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EMPRESA_SECCION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEMPRESA_SECCION_IDNull
		{
			get { return _empresa_seccion_idNull; }
			set { _empresa_seccion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA</c> column value.</value>
		public decimal COTIZACION_MONEDA
		{
			get { return _cotizacion_moneda; }
			set { _cotizacion_moneda = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get
			{
				if(IsMONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto;
			}
			set
			{
				_montoNull = false;
				_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTONull
		{
			get { return _montoNull; }
			set { _montoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UTILIZAR_PORCENTAJE</c> column value.
		/// </summary>
		/// <value>The <c>UTILIZAR_PORCENTAJE</c> column value.</value>
		public string UTILIZAR_PORCENTAJE
		{
			get { return _utilizar_porcentaje; }
			set { _utilizar_porcentaje = value; }
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
		/// Gets or sets the <c>USUARIO_CREACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_ID</c> column value.</value>
		public decimal USUARIO_CREACION_ID
		{
			get { return _usuario_creacion_id; }
			set { _usuario_creacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LIQUIDACION_ASOCIADA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LIQUIDACION_ASOCIADA_ID</c> column value.</value>
		public decimal LIQUIDACION_ASOCIADA_ID
		{
			get
			{
				if(IsLIQUIDACION_ASOCIADA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _liquidacion_asociada_id;
			}
			set
			{
				_liquidacion_asociada_idNull = false;
				_liquidacion_asociada_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LIQUIDACION_ASOCIADA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLIQUIDACION_ASOCIADA_IDNull
		{
			get { return _liquidacion_asociada_idNull; }
			set { _liquidacion_asociada_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONSUMO_VISITAS</c> column value.
		/// </summary>
		/// <value>The <c>CONSUMO_VISITAS</c> column value.</value>
		public string CONSUMO_VISITAS
		{
			get { return _consumo_visitas; }
			set { _consumo_visitas = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ORIGEN_ID</c> column value.</value>
		public decimal CASO_ORIGEN_ID
		{
			get
			{
				if(IsCASO_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_origen_id;
			}
			set
			{
				_caso_origen_idNull = false;
				_caso_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ORIGEN_IDNull
		{
			get { return _caso_origen_idNull; }
			set { _caso_origen_idNull = value; }
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
			dynStr.Append("@CBA@DESCUENTO_ID=");
			dynStr.Append(DESCUENTO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@EMPRESA_SECCION_ID=");
			dynStr.Append(IsEMPRESA_SECCION_IDNull ? (object)"<NULL>" : EMPRESA_SECCION_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(IsMONTONull ? (object)"<NULL>" : MONTO);
			dynStr.Append("@CBA@UTILIZAR_PORCENTAJE=");
			dynStr.Append(UTILIZAR_PORCENTAJE);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@LIQUIDACION_ASOCIADA_ID=");
			dynStr.Append(IsLIQUIDACION_ASOCIADA_IDNull ? (object)"<NULL>" : LIQUIDACION_ASOCIADA_ID);
			dynStr.Append("@CBA@CONSUMO_VISITAS=");
			dynStr.Append(CONSUMO_VISITAS);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@CASO_ORIGEN_ID=");
			dynStr.Append(IsCASO_ORIGEN_IDNull ? (object)"<NULL>" : CASO_ORIGEN_ID);
			return dynStr.ToString();
		}
	} // End of FUNCIONARIOS_DESCUENTOSRow_Base class
} // End of namespace
