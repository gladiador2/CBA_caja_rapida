// <fileinfo name="CTACTE_CAJAS_SUC_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CAJAS_SUC_INFO_COMPRow"/> that 
	/// represents a record in the <c>CTACTE_CAJAS_SUC_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CAJAS_SUC_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CAJAS_SUC_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private decimal _funcionario_id;
		private string _funcionario_nombre;
		private string _funcionario_codigo;
		private decimal _usuario_abre_id;
		private decimal _usuario_cierra_id;
		private bool _usuario_cierra_idNull = true;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private System.DateTime _fecha_inicio;
		private System.DateTime _fecha_fin;
		private bool _fecha_finNull = true;
		private string _ctacte_caja_sucursal_estado_id;
		private decimal _ctacte_caja_tesoreria_id;
		private string _ctacte_caja_tesoreria_nombre;
		private string _ctacte_caja_tesoreria_abrev;
		private decimal _ctacte_caja_suc_anterior_id;
		private bool _ctacte_caja_suc_anterior_idNull = true;
		private decimal _moneda_principal_id;
		private decimal _moneda_principal_can_decimales;
		private decimal _saldo_cierre;
		private string _existe_caja_siguiente;
		private decimal _region_id;
		private bool _region_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CAJAS_SUC_INFO_COMPRow_Base"/> class.
		/// </summary>
		public CTACTE_CAJAS_SUC_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CAJAS_SUC_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.FUNCIONARIO_CODIGO != original.FUNCIONARIO_CODIGO) return true;
			if (this.USUARIO_ABRE_ID != original.USUARIO_ABRE_ID) return true;
			if (this.IsUSUARIO_CIERRA_IDNull != original.IsUSUARIO_CIERRA_IDNull) return true;
			if (!this.IsUSUARIO_CIERRA_IDNull && !original.IsUSUARIO_CIERRA_IDNull)
				if (this.USUARIO_CIERRA_ID != original.USUARIO_CIERRA_ID) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.IsFECHA_FINNull != original.IsFECHA_FINNull) return true;
			if (!this.IsFECHA_FINNull && !original.IsFECHA_FINNull)
				if (this.FECHA_FIN != original.FECHA_FIN) return true;
			if (this.CTACTE_CAJA_SUCURSAL_ESTADO_ID != original.CTACTE_CAJA_SUCURSAL_ESTADO_ID) return true;
			if (this.CTACTE_CAJA_TESORERIA_ID != original.CTACTE_CAJA_TESORERIA_ID) return true;
			if (this.CTACTE_CAJA_TESORERIA_NOMBRE != original.CTACTE_CAJA_TESORERIA_NOMBRE) return true;
			if (this.CTACTE_CAJA_TESORERIA_ABREV != original.CTACTE_CAJA_TESORERIA_ABREV) return true;
			if (this.IsCTACTE_CAJA_SUC_ANTERIOR_IDNull != original.IsCTACTE_CAJA_SUC_ANTERIOR_IDNull) return true;
			if (!this.IsCTACTE_CAJA_SUC_ANTERIOR_IDNull && !original.IsCTACTE_CAJA_SUC_ANTERIOR_IDNull)
				if (this.CTACTE_CAJA_SUC_ANTERIOR_ID != original.CTACTE_CAJA_SUC_ANTERIOR_ID) return true;
			if (this.MONEDA_PRINCIPAL_ID != original.MONEDA_PRINCIPAL_ID) return true;
			if (this.MONEDA_PRINCIPAL_CAN_DECIMALES != original.MONEDA_PRINCIPAL_CAN_DECIMALES) return true;
			if (this.SALDO_CIERRE != original.SALDO_CIERRE) return true;
			if (this.EXISTE_CAJA_SIGUIENTE != original.EXISTE_CAJA_SIGUIENTE) return true;
			if (this.IsREGION_IDNull != original.IsREGION_IDNull) return true;
			if (!this.IsREGION_IDNull && !original.IsREGION_IDNull)
				if (this.REGION_ID != original.REGION_ID) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
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
		/// Gets or sets the <c>FUNCIONARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_NOMBRE
		{
			get { return _funcionario_nombre; }
			set { _funcionario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_CODIGO</c> column value.</value>
		public string FUNCIONARIO_CODIGO
		{
			get { return _funcionario_codigo; }
			set { _funcionario_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ABRE_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ABRE_ID</c> column value.</value>
		public decimal USUARIO_ABRE_ID
		{
			get { return _usuario_abre_id; }
			set { _usuario_abre_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CIERRA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_CIERRA_ID</c> column value.</value>
		public decimal USUARIO_CIERRA_ID
		{
			get
			{
				if(IsUSUARIO_CIERRA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_cierra_id;
			}
			set
			{
				_usuario_cierra_idNull = false;
				_usuario_cierra_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_CIERRA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_CIERRA_IDNull
		{
			get { return _usuario_cierra_idNull; }
			set { _usuario_cierra_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get
			{
				if(IsAUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_id;
			}
			set
			{
				_autonumeracion_idNull = false;
				_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_IDNull
		{
			get { return _autonumeracion_idNull; }
			set { _autonumeracion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get { return _fecha_inicio; }
			set { _fecha_inicio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FIN</c> column value.</value>
		public System.DateTime FECHA_FIN
		{
			get
			{
				if(IsFECHA_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_fin;
			}
			set
			{
				_fecha_finNull = false;
				_fecha_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FINNull
		{
			get { return _fecha_finNull; }
			set { _fecha_finNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_SUCURSAL_ESTADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_SUCURSAL_ESTADO_ID</c> column value.</value>
		public string CTACTE_CAJA_SUCURSAL_ESTADO_ID
		{
			get { return _ctacte_caja_sucursal_estado_id; }
			set { _ctacte_caja_sucursal_estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</value>
		public decimal CTACTE_CAJA_TESORERIA_ID
		{
			get { return _ctacte_caja_tesoreria_id; }
			set { _ctacte_caja_tesoreria_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_NOMBRE</c> column value.</value>
		public string CTACTE_CAJA_TESORERIA_NOMBRE
		{
			get { return _ctacte_caja_tesoreria_nombre; }
			set { _ctacte_caja_tesoreria_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_ABREV</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_ABREV</c> column value.</value>
		public string CTACTE_CAJA_TESORERIA_ABREV
		{
			get { return _ctacte_caja_tesoreria_abrev; }
			set { _ctacte_caja_tesoreria_abrev = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_SUC_ANTERIOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_SUC_ANTERIOR_ID</c> column value.</value>
		public decimal CTACTE_CAJA_SUC_ANTERIOR_ID
		{
			get
			{
				if(IsCTACTE_CAJA_SUC_ANTERIOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_suc_anterior_id;
			}
			set
			{
				_ctacte_caja_suc_anterior_idNull = false;
				_ctacte_caja_suc_anterior_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_SUC_ANTERIOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_SUC_ANTERIOR_IDNull
		{
			get { return _ctacte_caja_suc_anterior_idNull; }
			set { _ctacte_caja_suc_anterior_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_PRINCIPAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_PRINCIPAL_ID</c> column value.</value>
		public decimal MONEDA_PRINCIPAL_ID
		{
			get { return _moneda_principal_id; }
			set { _moneda_principal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_PRINCIPAL_CAN_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_PRINCIPAL_CAN_DECIMALES</c> column value.</value>
		public decimal MONEDA_PRINCIPAL_CAN_DECIMALES
		{
			get { return _moneda_principal_can_decimales; }
			set { _moneda_principal_can_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_CIERRE</c> column value.
		/// </summary>
		/// <value>The <c>SALDO_CIERRE</c> column value.</value>
		public decimal SALDO_CIERRE
		{
			get { return _saldo_cierre; }
			set { _saldo_cierre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EXISTE_CAJA_SIGUIENTE</c> column value.
		/// </summary>
		/// <value>The <c>EXISTE_CAJA_SIGUIENTE</c> column value.</value>
		public string EXISTE_CAJA_SIGUIENTE
		{
			get { return _existe_caja_siguiente; }
			set { _existe_caja_siguiente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGION_ID</c> column value.</value>
		public decimal REGION_ID
		{
			get
			{
				if(IsREGION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _region_id;
			}
			set
			{
				_region_idNull = false;
				_region_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REGION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREGION_IDNull
		{
			get { return _region_idNull; }
			set { _region_idNull = value; }
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
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_CODIGO=");
			dynStr.Append(FUNCIONARIO_CODIGO);
			dynStr.Append("@CBA@USUARIO_ABRE_ID=");
			dynStr.Append(USUARIO_ABRE_ID);
			dynStr.Append("@CBA@USUARIO_CIERRA_ID=");
			dynStr.Append(IsUSUARIO_CIERRA_IDNull ? (object)"<NULL>" : USUARIO_CIERRA_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(FECHA_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(IsFECHA_FINNull ? (object)"<NULL>" : FECHA_FIN);
			dynStr.Append("@CBA@CTACTE_CAJA_SUCURSAL_ESTADO_ID=");
			dynStr.Append(CTACTE_CAJA_SUCURSAL_ESTADO_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ID=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_NOMBRE=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_NOMBRE);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ABREV=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_ABREV);
			dynStr.Append("@CBA@CTACTE_CAJA_SUC_ANTERIOR_ID=");
			dynStr.Append(IsCTACTE_CAJA_SUC_ANTERIOR_IDNull ? (object)"<NULL>" : CTACTE_CAJA_SUC_ANTERIOR_ID);
			dynStr.Append("@CBA@MONEDA_PRINCIPAL_ID=");
			dynStr.Append(MONEDA_PRINCIPAL_ID);
			dynStr.Append("@CBA@MONEDA_PRINCIPAL_CAN_DECIMALES=");
			dynStr.Append(MONEDA_PRINCIPAL_CAN_DECIMALES);
			dynStr.Append("@CBA@SALDO_CIERRE=");
			dynStr.Append(SALDO_CIERRE);
			dynStr.Append("@CBA@EXISTE_CAJA_SIGUIENTE=");
			dynStr.Append(EXISTE_CAJA_SIGUIENTE);
			dynStr.Append("@CBA@REGION_ID=");
			dynStr.Append(IsREGION_IDNull ? (object)"<NULL>" : REGION_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_CAJAS_SUC_INFO_COMPRow_Base class
} // End of namespace
