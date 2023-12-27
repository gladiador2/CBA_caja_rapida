// <fileinfo name="CTACTE_CHEQUES_REC_ABOG_INFO_CRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CRow"/> that 
	/// represents a record in the <c>CTACTE_CHEQUES_REC_ABOG_INFO_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CHEQUES_REC_ABOG_INFO_CRow_Base
	{
		private decimal _id;
		private decimal _ctacte_cheque_recibido_id;
		private decimal _ctacte_banco_id;
		private string _ctacte_banco_nombre;
		private string _numero_cuenta;
		private string _numero_cheque;
		private string _nombre_emisor;
		private string _nombre_beneficiario;
		private string _numero_documento_emisor;
		private System.DateTime _fecha_creacion;
		private System.DateTime _fecha_posdatado;
		private System.DateTime _fecha_vencimiento;
		private System.DateTime _fecha_cobro;
		private bool _fecha_cobroNull = true;
		private System.DateTime _fecha_rechazo;
		private bool _fecha_rechazoNull = true;
		private decimal _moneda_id;
		private string _monedas_nombre;
		private decimal _cotizacion_moneda;
		private decimal _monto;
		private string _motivo_rechazo;
		private decimal _cheque_estado_id;
		private bool _cheque_estado_idNull = true;
		private string _estado_cheque_nombre;
		private string _cheque_de_terceros;
		private decimal _abogado_id;
		private string _abogado_nombre_completo;
		private string _abogado_nombre_estudio;
		private System.DateTime _fecha_asignacion;
		private System.DateTime _fecha_desasignacion;
		private bool _fecha_desasignacionNull = true;
		private string _observacion_asignacion;
		private string _observacion_desasignacion;
		private decimal _usuario_asignacion_id;
		private System.DateTime _usuario_asignacion_fecha;
		private decimal _usuario_desasignacion_id;
		private bool _usuario_desasignacion_idNull = true;
		private System.DateTime _usuario_desasignacion_fecha;
		private bool _usuario_desasignacion_fechaNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CRow_Base"/> class.
		/// </summary>
		public CTACTE_CHEQUES_REC_ABOG_INFO_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CHEQUES_REC_ABOG_INFO_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.CTACTE_BANCO_ID != original.CTACTE_BANCO_ID) return true;
			if (this.CTACTE_BANCO_NOMBRE != original.CTACTE_BANCO_NOMBRE) return true;
			if (this.NUMERO_CUENTA != original.NUMERO_CUENTA) return true;
			if (this.NUMERO_CHEQUE != original.NUMERO_CHEQUE) return true;
			if (this.NOMBRE_EMISOR != original.NOMBRE_EMISOR) return true;
			if (this.NOMBRE_BENEFICIARIO != original.NOMBRE_BENEFICIARIO) return true;
			if (this.NUMERO_DOCUMENTO_EMISOR != original.NUMERO_DOCUMENTO_EMISOR) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.FECHA_POSDATADO != original.FECHA_POSDATADO) return true;
			if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.IsFECHA_COBRONull != original.IsFECHA_COBRONull) return true;
			if (!this.IsFECHA_COBRONull && !original.IsFECHA_COBRONull)
				if (this.FECHA_COBRO != original.FECHA_COBRO) return true;
			if (this.IsFECHA_RECHAZONull != original.IsFECHA_RECHAZONull) return true;
			if (!this.IsFECHA_RECHAZONull && !original.IsFECHA_RECHAZONull)
				if (this.FECHA_RECHAZO != original.FECHA_RECHAZO) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDAS_NOMBRE != original.MONEDAS_NOMBRE) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.MOTIVO_RECHAZO != original.MOTIVO_RECHAZO) return true;
			if (this.IsCHEQUE_ESTADO_IDNull != original.IsCHEQUE_ESTADO_IDNull) return true;
			if (!this.IsCHEQUE_ESTADO_IDNull && !original.IsCHEQUE_ESTADO_IDNull)
				if (this.CHEQUE_ESTADO_ID != original.CHEQUE_ESTADO_ID) return true;
			if (this.ESTADO_CHEQUE_NOMBRE != original.ESTADO_CHEQUE_NOMBRE) return true;
			if (this.CHEQUE_DE_TERCEROS != original.CHEQUE_DE_TERCEROS) return true;
			if (this.ABOGADO_ID != original.ABOGADO_ID) return true;
			if (this.ABOGADO_NOMBRE_COMPLETO != original.ABOGADO_NOMBRE_COMPLETO) return true;
			if (this.ABOGADO_NOMBRE_ESTUDIO != original.ABOGADO_NOMBRE_ESTUDIO) return true;
			if (this.FECHA_ASIGNACION != original.FECHA_ASIGNACION) return true;
			if (this.IsFECHA_DESASIGNACIONNull != original.IsFECHA_DESASIGNACIONNull) return true;
			if (!this.IsFECHA_DESASIGNACIONNull && !original.IsFECHA_DESASIGNACIONNull)
				if (this.FECHA_DESASIGNACION != original.FECHA_DESASIGNACION) return true;
			if (this.OBSERVACION_ASIGNACION != original.OBSERVACION_ASIGNACION) return true;
			if (this.OBSERVACION_DESASIGNACION != original.OBSERVACION_DESASIGNACION) return true;
			if (this.USUARIO_ASIGNACION_ID != original.USUARIO_ASIGNACION_ID) return true;
			if (this.USUARIO_ASIGNACION_FECHA != original.USUARIO_ASIGNACION_FECHA) return true;
			if (this.IsUSUARIO_DESASIGNACION_IDNull != original.IsUSUARIO_DESASIGNACION_IDNull) return true;
			if (!this.IsUSUARIO_DESASIGNACION_IDNull && !original.IsUSUARIO_DESASIGNACION_IDNull)
				if (this.USUARIO_DESASIGNACION_ID != original.USUARIO_DESASIGNACION_ID) return true;
			if (this.IsUSUARIO_DESASIGNACION_FECHANull != original.IsUSUARIO_DESASIGNACION_FECHANull) return true;
			if (!this.IsUSUARIO_DESASIGNACION_FECHANull && !original.IsUSUARIO_DESASIGNACION_FECHANull)
				if (this.USUARIO_DESASIGNACION_FECHA != original.USUARIO_DESASIGNACION_FECHA) return true;
			
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
		/// Gets or sets the <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</value>
		public decimal CTACTE_CHEQUE_RECIBIDO_ID
		{
			get { return _ctacte_cheque_recibido_id; }
			set { _ctacte_cheque_recibido_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_ID</c> column value.</value>
		public decimal CTACTE_BANCO_ID
		{
			get { return _ctacte_banco_id; }
			set { _ctacte_banco_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_NOMBRE</c> column value.</value>
		public string CTACTE_BANCO_NOMBRE
		{
			get { return _ctacte_banco_nombre; }
			set { _ctacte_banco_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_CUENTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_CUENTA</c> column value.</value>
		public string NUMERO_CUENTA
		{
			get { return _numero_cuenta; }
			set { _numero_cuenta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_CHEQUE</c> column value.
		/// </summary>
		/// <value>The <c>NUMERO_CHEQUE</c> column value.</value>
		public string NUMERO_CHEQUE
		{
			get { return _numero_cheque; }
			set { _numero_cheque = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_EMISOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_EMISOR</c> column value.</value>
		public string NOMBRE_EMISOR
		{
			get { return _nombre_emisor; }
			set { _nombre_emisor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_BENEFICIARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_BENEFICIARIO</c> column value.</value>
		public string NOMBRE_BENEFICIARIO
		{
			get { return _nombre_beneficiario; }
			set { _nombre_beneficiario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_DOCUMENTO_EMISOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_DOCUMENTO_EMISOR</c> column value.</value>
		public string NUMERO_DOCUMENTO_EMISOR
		{
			get { return _numero_documento_emisor; }
			set { _numero_documento_emisor = value; }
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
		/// Gets or sets the <c>FECHA_POSDATADO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_POSDATADO</c> column value.</value>
		public System.DateTime FECHA_POSDATADO
		{
			get { return _fecha_posdatado; }
			set { _fecha_posdatado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO
		{
			get { return _fecha_vencimiento; }
			set { _fecha_vencimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_COBRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_COBRO</c> column value.</value>
		public System.DateTime FECHA_COBRO
		{
			get
			{
				if(IsFECHA_COBRONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_cobro;
			}
			set
			{
				_fecha_cobroNull = false;
				_fecha_cobro = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_COBRO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_COBRONull
		{
			get { return _fecha_cobroNull; }
			set { _fecha_cobroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_RECHAZO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_RECHAZO</c> column value.</value>
		public System.DateTime FECHA_RECHAZO
		{
			get
			{
				if(IsFECHA_RECHAZONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_rechazo;
			}
			set
			{
				_fecha_rechazoNull = false;
				_fecha_rechazo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_RECHAZO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_RECHAZONull
		{
			get { return _fecha_rechazoNull; }
			set { _fecha_rechazoNull = value; }
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
		/// Gets or sets the <c>MONEDAS_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDAS_NOMBRE</c> column value.</value>
		public string MONEDAS_NOMBRE
		{
			get { return _monedas_nombre; }
			set { _monedas_nombre = value; }
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
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get { return _monto; }
			set { _monto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOTIVO_RECHAZO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOTIVO_RECHAZO</c> column value.</value>
		public string MOTIVO_RECHAZO
		{
			get { return _motivo_rechazo; }
			set { _motivo_rechazo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_ESTADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_ESTADO_ID</c> column value.</value>
		public decimal CHEQUE_ESTADO_ID
		{
			get
			{
				if(IsCHEQUE_ESTADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cheque_estado_id;
			}
			set
			{
				_cheque_estado_idNull = false;
				_cheque_estado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CHEQUE_ESTADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCHEQUE_ESTADO_IDNull
		{
			get { return _cheque_estado_idNull; }
			set { _cheque_estado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_CHEQUE_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO_CHEQUE_NOMBRE</c> column value.</value>
		public string ESTADO_CHEQUE_NOMBRE
		{
			get { return _estado_cheque_nombre; }
			set { _estado_cheque_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_DE_TERCEROS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_DE_TERCEROS</c> column value.</value>
		public string CHEQUE_DE_TERCEROS
		{
			get { return _cheque_de_terceros; }
			set { _cheque_de_terceros = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ABOGADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ABOGADO_ID</c> column value.</value>
		public decimal ABOGADO_ID
		{
			get { return _abogado_id; }
			set { _abogado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ABOGADO_NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ABOGADO_NOMBRE_COMPLETO</c> column value.</value>
		public string ABOGADO_NOMBRE_COMPLETO
		{
			get { return _abogado_nombre_completo; }
			set { _abogado_nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ABOGADO_NOMBRE_ESTUDIO</c> column value.
		/// </summary>
		/// <value>The <c>ABOGADO_NOMBRE_ESTUDIO</c> column value.</value>
		public string ABOGADO_NOMBRE_ESTUDIO
		{
			get { return _abogado_nombre_estudio; }
			set { _abogado_nombre_estudio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ASIGNACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_ASIGNACION</c> column value.</value>
		public System.DateTime FECHA_ASIGNACION
		{
			get { return _fecha_asignacion; }
			set { _fecha_asignacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESASIGNACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESASIGNACION</c> column value.</value>
		public System.DateTime FECHA_DESASIGNACION
		{
			get
			{
				if(IsFECHA_DESASIGNACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desasignacion;
			}
			set
			{
				_fecha_desasignacionNull = false;
				_fecha_desasignacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESASIGNACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESASIGNACIONNull
		{
			get { return _fecha_desasignacionNull; }
			set { _fecha_desasignacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_ASIGNACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_ASIGNACION</c> column value.</value>
		public string OBSERVACION_ASIGNACION
		{
			get { return _observacion_asignacion; }
			set { _observacion_asignacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_DESASIGNACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_DESASIGNACION</c> column value.</value>
		public string OBSERVACION_DESASIGNACION
		{
			get { return _observacion_desasignacion; }
			set { _observacion_desasignacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ASIGNACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ASIGNACION_ID</c> column value.</value>
		public decimal USUARIO_ASIGNACION_ID
		{
			get { return _usuario_asignacion_id; }
			set { _usuario_asignacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ASIGNACION_FECHA</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ASIGNACION_FECHA</c> column value.</value>
		public System.DateTime USUARIO_ASIGNACION_FECHA
		{
			get { return _usuario_asignacion_fecha; }
			set { _usuario_asignacion_fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_DESASIGNACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_DESASIGNACION_ID</c> column value.</value>
		public decimal USUARIO_DESASIGNACION_ID
		{
			get
			{
				if(IsUSUARIO_DESASIGNACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_desasignacion_id;
			}
			set
			{
				_usuario_desasignacion_idNull = false;
				_usuario_desasignacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_DESASIGNACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_DESASIGNACION_IDNull
		{
			get { return _usuario_desasignacion_idNull; }
			set { _usuario_desasignacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_DESASIGNACION_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_DESASIGNACION_FECHA</c> column value.</value>
		public System.DateTime USUARIO_DESASIGNACION_FECHA
		{
			get
			{
				if(IsUSUARIO_DESASIGNACION_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_desasignacion_fecha;
			}
			set
			{
				_usuario_desasignacion_fechaNull = false;
				_usuario_desasignacion_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_DESASIGNACION_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_DESASIGNACION_FECHANull
		{
			get { return _usuario_desasignacion_fechaNull; }
			set { _usuario_desasignacion_fechaNull = value; }
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
			dynStr.Append("@CBA@CTACTE_CHEQUE_RECIBIDO_ID=");
			dynStr.Append(CTACTE_CHEQUE_RECIBIDO_ID);
			dynStr.Append("@CBA@CTACTE_BANCO_ID=");
			dynStr.Append(CTACTE_BANCO_ID);
			dynStr.Append("@CBA@CTACTE_BANCO_NOMBRE=");
			dynStr.Append(CTACTE_BANCO_NOMBRE);
			dynStr.Append("@CBA@NUMERO_CUENTA=");
			dynStr.Append(NUMERO_CUENTA);
			dynStr.Append("@CBA@NUMERO_CHEQUE=");
			dynStr.Append(NUMERO_CHEQUE);
			dynStr.Append("@CBA@NOMBRE_EMISOR=");
			dynStr.Append(NOMBRE_EMISOR);
			dynStr.Append("@CBA@NOMBRE_BENEFICIARIO=");
			dynStr.Append(NOMBRE_BENEFICIARIO);
			dynStr.Append("@CBA@NUMERO_DOCUMENTO_EMISOR=");
			dynStr.Append(NUMERO_DOCUMENTO_EMISOR);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@FECHA_POSDATADO=");
			dynStr.Append(FECHA_POSDATADO);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@FECHA_COBRO=");
			dynStr.Append(IsFECHA_COBRONull ? (object)"<NULL>" : FECHA_COBRO);
			dynStr.Append("@CBA@FECHA_RECHAZO=");
			dynStr.Append(IsFECHA_RECHAZONull ? (object)"<NULL>" : FECHA_RECHAZO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDAS_NOMBRE=");
			dynStr.Append(MONEDAS_NOMBRE);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@MOTIVO_RECHAZO=");
			dynStr.Append(MOTIVO_RECHAZO);
			dynStr.Append("@CBA@CHEQUE_ESTADO_ID=");
			dynStr.Append(IsCHEQUE_ESTADO_IDNull ? (object)"<NULL>" : CHEQUE_ESTADO_ID);
			dynStr.Append("@CBA@ESTADO_CHEQUE_NOMBRE=");
			dynStr.Append(ESTADO_CHEQUE_NOMBRE);
			dynStr.Append("@CBA@CHEQUE_DE_TERCEROS=");
			dynStr.Append(CHEQUE_DE_TERCEROS);
			dynStr.Append("@CBA@ABOGADO_ID=");
			dynStr.Append(ABOGADO_ID);
			dynStr.Append("@CBA@ABOGADO_NOMBRE_COMPLETO=");
			dynStr.Append(ABOGADO_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@ABOGADO_NOMBRE_ESTUDIO=");
			dynStr.Append(ABOGADO_NOMBRE_ESTUDIO);
			dynStr.Append("@CBA@FECHA_ASIGNACION=");
			dynStr.Append(FECHA_ASIGNACION);
			dynStr.Append("@CBA@FECHA_DESASIGNACION=");
			dynStr.Append(IsFECHA_DESASIGNACIONNull ? (object)"<NULL>" : FECHA_DESASIGNACION);
			dynStr.Append("@CBA@OBSERVACION_ASIGNACION=");
			dynStr.Append(OBSERVACION_ASIGNACION);
			dynStr.Append("@CBA@OBSERVACION_DESASIGNACION=");
			dynStr.Append(OBSERVACION_DESASIGNACION);
			dynStr.Append("@CBA@USUARIO_ASIGNACION_ID=");
			dynStr.Append(USUARIO_ASIGNACION_ID);
			dynStr.Append("@CBA@USUARIO_ASIGNACION_FECHA=");
			dynStr.Append(USUARIO_ASIGNACION_FECHA);
			dynStr.Append("@CBA@USUARIO_DESASIGNACION_ID=");
			dynStr.Append(IsUSUARIO_DESASIGNACION_IDNull ? (object)"<NULL>" : USUARIO_DESASIGNACION_ID);
			dynStr.Append("@CBA@USUARIO_DESASIGNACION_FECHA=");
			dynStr.Append(IsUSUARIO_DESASIGNACION_FECHANull ? (object)"<NULL>" : USUARIO_DESASIGNACION_FECHA);
			return dynStr.ToString();
		}
	} // End of CTACTE_CHEQUES_REC_ABOG_INFO_CRow_Base class
} // End of namespace
