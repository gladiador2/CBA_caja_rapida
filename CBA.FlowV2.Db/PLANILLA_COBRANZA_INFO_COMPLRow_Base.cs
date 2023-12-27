// <fileinfo name="PLANILLA_COBRANZA_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="PLANILLA_COBRANZA_INFO_COMPLRow"/> that 
	/// represents a record in the <c>PLANILLA_COBRANZA_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANILLA_COBRANZA_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_COBRANZA_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private string _caso_estado;
		private decimal _caso_entidad_id;
		private decimal _caso_usuario_id;
		private bool _caso_usuario_idNull = true;
		private string _caso_usuario_nombre;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private string _sucursal_abreviatura;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private decimal _funcionario_id;
		private string _funcionario_nombre;
		private string _funcionario_codigo;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private System.DateTime _fecha_inicio;
		private System.DateTime _fecha_fin;
		private decimal _autonumeracion_id;
		private string _nro_comprobante;
		private decimal _funcionario_cajero_id;
		private bool _funcionario_cajero_idNull = true;
		private string _funcionario_cajero_nombre;
		private string _funcionnario_cajero_codigo;
		private decimal _ctacte_caja_sucursal_id;
		private bool _ctacte_caja_sucursal_idNull = true;
		private decimal _fc_autonumeracion_id;
		private bool _fc_autonumeracion_idNull = true;
		private string _generar_pago;
		private string _incluir_mora;
		private decimal _monto_comision;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_COBRANZA_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public PLANILLA_COBRANZA_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANILLA_COBRANZA_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO != original.CASO_ESTADO) return true;
			if (this.CASO_ENTIDAD_ID != original.CASO_ENTIDAD_ID) return true;
			if (this.IsCASO_USUARIO_IDNull != original.IsCASO_USUARIO_IDNull) return true;
			if (!this.IsCASO_USUARIO_IDNull && !original.IsCASO_USUARIO_IDNull)
				if (this.CASO_USUARIO_ID != original.CASO_USUARIO_ID) return true;
			if (this.CASO_USUARIO_NOMBRE != original.CASO_USUARIO_NOMBRE) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.SUCURSAL_ABREVIATURA != original.SUCURSAL_ABREVIATURA) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.FUNCIONARIO_CODIGO != original.FUNCIONARIO_CODIGO) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.FECHA_FIN != original.FECHA_FIN) return true;
			if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsFUNCIONARIO_CAJERO_IDNull != original.IsFUNCIONARIO_CAJERO_IDNull) return true;
			if (!this.IsFUNCIONARIO_CAJERO_IDNull && !original.IsFUNCIONARIO_CAJERO_IDNull)
				if (this.FUNCIONARIO_CAJERO_ID != original.FUNCIONARIO_CAJERO_ID) return true;
			if (this.FUNCIONARIO_CAJERO_NOMBRE != original.FUNCIONARIO_CAJERO_NOMBRE) return true;
			if (this.FUNCIONNARIO_CAJERO_CODIGO != original.FUNCIONNARIO_CAJERO_CODIGO) return true;
			if (this.IsCTACTE_CAJA_SUCURSAL_IDNull != original.IsCTACTE_CAJA_SUCURSAL_IDNull) return true;
			if (!this.IsCTACTE_CAJA_SUCURSAL_IDNull && !original.IsCTACTE_CAJA_SUCURSAL_IDNull)
				if (this.CTACTE_CAJA_SUCURSAL_ID != original.CTACTE_CAJA_SUCURSAL_ID) return true;
			if (this.IsFC_AUTONUMERACION_IDNull != original.IsFC_AUTONUMERACION_IDNull) return true;
			if (!this.IsFC_AUTONUMERACION_IDNull && !original.IsFC_AUTONUMERACION_IDNull)
				if (this.FC_AUTONUMERACION_ID != original.FC_AUTONUMERACION_ID) return true;
			if (this.GENERAR_PAGO != original.GENERAR_PAGO) return true;
			if (this.INCLUIR_MORA != original.INCLUIR_MORA) return true;
			if (this.MONTO_COMISION != original.MONTO_COMISION) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ESTADO</c> column value.</value>
		public string CASO_ESTADO
		{
			get { return _caso_estado; }
			set { _caso_estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ENTIDAD_ID</c> column value.</value>
		public decimal CASO_ENTIDAD_ID
		{
			get { return _caso_entidad_id; }
			set { _caso_entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_USUARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_USUARIO_ID</c> column value.</value>
		public decimal CASO_USUARIO_ID
		{
			get
			{
				if(IsCASO_USUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_usuario_id;
			}
			set
			{
				_caso_usuario_idNull = false;
				_caso_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_USUARIO_IDNull
		{
			get { return _caso_usuario_idNull; }
			set { _caso_usuario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_USUARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_USUARIO_NOMBRE</c> column value.</value>
		public string CASO_USUARIO_NOMBRE
		{
			get { return _caso_usuario_nombre; }
			set { _caso_usuario_nombre = value; }
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
		/// Gets or sets the <c>SUCURSAL_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ABREVIATURA
		{
			get { return _sucursal_abreviatura; }
			set { _sucursal_abreviatura = value; }
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
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
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
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get
			{
				if(IsPERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id;
			}
			set
			{
				_persona_idNull = false;
				_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_IDNull
		{
			get { return _persona_idNull; }
			set { _persona_idNull = value; }
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
		/// </summary>
		/// <value>The <c>FECHA_FIN</c> column value.</value>
		public System.DateTime FECHA_FIN
		{
			get { return _fecha_fin; }
			set { _fecha_fin = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get { return _autonumeracion_id; }
			set { _autonumeracion_id = value; }
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
		/// Gets or sets the <c>FUNCIONARIO_CAJERO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_CAJERO_ID</c> column value.</value>
		public decimal FUNCIONARIO_CAJERO_ID
		{
			get
			{
				if(IsFUNCIONARIO_CAJERO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_cajero_id;
			}
			set
			{
				_funcionario_cajero_idNull = false;
				_funcionario_cajero_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_CAJERO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_CAJERO_IDNull
		{
			get { return _funcionario_cajero_idNull; }
			set { _funcionario_cajero_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_CAJERO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_CAJERO_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_CAJERO_NOMBRE
		{
			get { return _funcionario_cajero_nombre; }
			set { _funcionario_cajero_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONNARIO_CAJERO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONNARIO_CAJERO_CODIGO</c> column value.</value>
		public string FUNCIONNARIO_CAJERO_CODIGO
		{
			get { return _funcionnario_cajero_codigo; }
			set { _funcionnario_cajero_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</value>
		public decimal CTACTE_CAJA_SUCURSAL_ID
		{
			get
			{
				if(IsCTACTE_CAJA_SUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_sucursal_id;
			}
			set
			{
				_ctacte_caja_sucursal_idNull = false;
				_ctacte_caja_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_SUCURSAL_IDNull
		{
			get { return _ctacte_caja_sucursal_idNull; }
			set { _ctacte_caja_sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FC_AUTONUMERACION_ID</c> column value.</value>
		public decimal FC_AUTONUMERACION_ID
		{
			get
			{
				if(IsFC_AUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fc_autonumeracion_id;
			}
			set
			{
				_fc_autonumeracion_idNull = false;
				_fc_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FC_AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFC_AUTONUMERACION_IDNull
		{
			get { return _fc_autonumeracion_idNull; }
			set { _fc_autonumeracion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GENERAR_PAGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GENERAR_PAGO</c> column value.</value>
		public string GENERAR_PAGO
		{
			get { return _generar_pago; }
			set { _generar_pago = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INCLUIR_MORA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INCLUIR_MORA</c> column value.</value>
		public string INCLUIR_MORA
		{
			get { return _incluir_mora; }
			set { _incluir_mora = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_COMISION</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_COMISION</c> column value.</value>
		public decimal MONTO_COMISION
		{
			get { return _monto_comision; }
			set { _monto_comision = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@CASO_ESTADO=");
			dynStr.Append(CASO_ESTADO);
			dynStr.Append("@CBA@CASO_ENTIDAD_ID=");
			dynStr.Append(CASO_ENTIDAD_ID);
			dynStr.Append("@CBA@CASO_USUARIO_ID=");
			dynStr.Append(IsCASO_USUARIO_IDNull ? (object)"<NULL>" : CASO_USUARIO_ID);
			dynStr.Append("@CBA@CASO_USUARIO_NOMBRE=");
			dynStr.Append(CASO_USUARIO_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_CODIGO=");
			dynStr.Append(FUNCIONARIO_CODIGO);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(FECHA_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(FECHA_FIN);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FUNCIONARIO_CAJERO_ID=");
			dynStr.Append(IsFUNCIONARIO_CAJERO_IDNull ? (object)"<NULL>" : FUNCIONARIO_CAJERO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_CAJERO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_CAJERO_NOMBRE);
			dynStr.Append("@CBA@FUNCIONNARIO_CAJERO_CODIGO=");
			dynStr.Append(FUNCIONNARIO_CAJERO_CODIGO);
			dynStr.Append("@CBA@CTACTE_CAJA_SUCURSAL_ID=");
			dynStr.Append(IsCTACTE_CAJA_SUCURSAL_IDNull ? (object)"<NULL>" : CTACTE_CAJA_SUCURSAL_ID);
			dynStr.Append("@CBA@FC_AUTONUMERACION_ID=");
			dynStr.Append(IsFC_AUTONUMERACION_IDNull ? (object)"<NULL>" : FC_AUTONUMERACION_ID);
			dynStr.Append("@CBA@GENERAR_PAGO=");
			dynStr.Append(GENERAR_PAGO);
			dynStr.Append("@CBA@INCLUIR_MORA=");
			dynStr.Append(INCLUIR_MORA);
			dynStr.Append("@CBA@MONTO_COMISION=");
			dynStr.Append(MONTO_COMISION);
			return dynStr.ToString();
		}
	} // End of PLANILLA_COBRANZA_INFO_COMPLRow_Base class
} // End of namespace
