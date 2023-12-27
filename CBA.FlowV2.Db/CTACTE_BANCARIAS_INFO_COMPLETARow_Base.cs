// <fileinfo name="CTACTE_BANCARIAS_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="CTACTE_BANCARIAS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>CTACTE_BANCARIAS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_BANCARIAS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_BANCARIAS_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private string _numero_cuenta;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _entidad_id;
		private bool _entidad_idNull = true;
		private string _sucursal_nombre;
		private decimal _ctacte_banco_id;
		private string _banco_nombre;
		private string _banco_abreviatura;
		private decimal _banco_pais_id;
		private decimal _moneda_id;
		private string _moneda;
		private decimal _saldo_inicial;
		private decimal _saldo_extracto;
		private bool _saldo_extractoNull = true;
		private decimal _monto_linea_credito;
		private decimal _monto_sobregiro;
		private string _estado;
		private string _titular;
		private decimal _saldo_actual;
		private bool _saldo_actualNull = true;
		private decimal _saldo_conciliado;
		private bool _saldo_conciliadoNull = true;
		private decimal _reporte_id;
		private string _reporte_nombre;
		private decimal _reporte_para_banco_id;
		private bool _reporte_para_banco_idNull = true;
		private decimal _tipo_id;
		private bool _tipo_idNull = true;
		private string _tipos_ctacte_bancaria_descr;
		private decimal _orden;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_BANCARIAS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public CTACTE_BANCARIAS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_BANCARIAS_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NUMERO_CUENTA != original.NUMERO_CUENTA) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsENTIDAD_IDNull != original.IsENTIDAD_IDNull) return true;
			if (!this.IsENTIDAD_IDNull && !original.IsENTIDAD_IDNull)
				if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.CTACTE_BANCO_ID != original.CTACTE_BANCO_ID) return true;
			if (this.BANCO_NOMBRE != original.BANCO_NOMBRE) return true;
			if (this.BANCO_ABREVIATURA != original.BANCO_ABREVIATURA) return true;
			if (this.BANCO_PAIS_ID != original.BANCO_PAIS_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA != original.MONEDA) return true;
			if (this.SALDO_INICIAL != original.SALDO_INICIAL) return true;
			if (this.IsSALDO_EXTRACTONull != original.IsSALDO_EXTRACTONull) return true;
			if (!this.IsSALDO_EXTRACTONull && !original.IsSALDO_EXTRACTONull)
				if (this.SALDO_EXTRACTO != original.SALDO_EXTRACTO) return true;
			if (this.MONTO_LINEA_CREDITO != original.MONTO_LINEA_CREDITO) return true;
			if (this.MONTO_SOBREGIRO != original.MONTO_SOBREGIRO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.TITULAR != original.TITULAR) return true;
			if (this.IsSALDO_ACTUALNull != original.IsSALDO_ACTUALNull) return true;
			if (!this.IsSALDO_ACTUALNull && !original.IsSALDO_ACTUALNull)
				if (this.SALDO_ACTUAL != original.SALDO_ACTUAL) return true;
			if (this.IsSALDO_CONCILIADONull != original.IsSALDO_CONCILIADONull) return true;
			if (!this.IsSALDO_CONCILIADONull && !original.IsSALDO_CONCILIADONull)
				if (this.SALDO_CONCILIADO != original.SALDO_CONCILIADO) return true;
			if (this.REPORTE_ID != original.REPORTE_ID) return true;
			if (this.REPORTE_NOMBRE != original.REPORTE_NOMBRE) return true;
			if (this.IsREPORTE_PARA_BANCO_IDNull != original.IsREPORTE_PARA_BANCO_IDNull) return true;
			if (!this.IsREPORTE_PARA_BANCO_IDNull && !original.IsREPORTE_PARA_BANCO_IDNull)
				if (this.REPORTE_PARA_BANCO_ID != original.REPORTE_PARA_BANCO_ID) return true;
			if (this.IsTIPO_IDNull != original.IsTIPO_IDNull) return true;
			if (!this.IsTIPO_IDNull && !original.IsTIPO_IDNull)
				if (this.TIPO_ID != original.TIPO_ID) return true;
			if (this.TIPOS_CTACTE_BANCARIA_DESCR != original.TIPOS_CTACTE_BANCARIA_DESCR) return true;
			if (this.ORDEN != original.ORDEN) return true;
			
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
		/// Gets or sets the <c>NUMERO_CUENTA</c> column value.
		/// </summary>
		/// <value>The <c>NUMERO_CUENTA</c> column value.</value>
		public string NUMERO_CUENTA
		{
			get { return _numero_cuenta; }
			set { _numero_cuenta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get
			{
				if(IsENTIDAD_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _entidad_id;
			}
			set
			{
				_entidad_idNull = false;
				_entidad_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ENTIDAD_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsENTIDAD_IDNull
		{
			get { return _entidad_idNull; }
			set { _entidad_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
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
		/// Gets or sets the <c>BANCO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>BANCO_NOMBRE</c> column value.</value>
		public string BANCO_NOMBRE
		{
			get { return _banco_nombre; }
			set { _banco_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BANCO_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>BANCO_ABREVIATURA</c> column value.</value>
		public string BANCO_ABREVIATURA
		{
			get { return _banco_abreviatura; }
			set { _banco_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BANCO_PAIS_ID</c> column value.
		/// </summary>
		/// <value>The <c>BANCO_PAIS_ID</c> column value.</value>
		public decimal BANCO_PAIS_ID
		{
			get { return _banco_pais_id; }
			set { _banco_pais_id = value; }
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
		/// Gets or sets the <c>MONEDA</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA</c> column value.</value>
		public string MONEDA
		{
			get { return _moneda; }
			set { _moneda = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_INICIAL</c> column value.
		/// </summary>
		/// <value>The <c>SALDO_INICIAL</c> column value.</value>
		public decimal SALDO_INICIAL
		{
			get { return _saldo_inicial; }
			set { _saldo_inicial = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_EXTRACTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO_EXTRACTO</c> column value.</value>
		public decimal SALDO_EXTRACTO
		{
			get
			{
				if(IsSALDO_EXTRACTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo_extracto;
			}
			set
			{
				_saldo_extractoNull = false;
				_saldo_extracto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO_EXTRACTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDO_EXTRACTONull
		{
			get { return _saldo_extractoNull; }
			set { _saldo_extractoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_LINEA_CREDITO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_LINEA_CREDITO</c> column value.</value>
		public decimal MONTO_LINEA_CREDITO
		{
			get { return _monto_linea_credito; }
			set { _monto_linea_credito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_SOBREGIRO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_SOBREGIRO</c> column value.</value>
		public decimal MONTO_SOBREGIRO
		{
			get { return _monto_sobregiro; }
			set { _monto_sobregiro = value; }
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
		/// Gets or sets the <c>TITULAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TITULAR</c> column value.</value>
		public string TITULAR
		{
			get { return _titular; }
			set { _titular = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_ACTUAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO_ACTUAL</c> column value.</value>
		public decimal SALDO_ACTUAL
		{
			get
			{
				if(IsSALDO_ACTUALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo_actual;
			}
			set
			{
				_saldo_actualNull = false;
				_saldo_actual = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO_ACTUAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDO_ACTUALNull
		{
			get { return _saldo_actualNull; }
			set { _saldo_actualNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_CONCILIADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO_CONCILIADO</c> column value.</value>
		public decimal SALDO_CONCILIADO
		{
			get
			{
				if(IsSALDO_CONCILIADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo_conciliado;
			}
			set
			{
				_saldo_conciliadoNull = false;
				_saldo_conciliado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO_CONCILIADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDO_CONCILIADONull
		{
			get { return _saldo_conciliadoNull; }
			set { _saldo_conciliadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REPORTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>REPORTE_ID</c> column value.</value>
		public decimal REPORTE_ID
		{
			get { return _reporte_id; }
			set { _reporte_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REPORTE_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>REPORTE_NOMBRE</c> column value.</value>
		public string REPORTE_NOMBRE
		{
			get { return _reporte_nombre; }
			set { _reporte_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REPORTE_PARA_BANCO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REPORTE_PARA_BANCO_ID</c> column value.</value>
		public decimal REPORTE_PARA_BANCO_ID
		{
			get
			{
				if(IsREPORTE_PARA_BANCO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reporte_para_banco_id;
			}
			set
			{
				_reporte_para_banco_idNull = false;
				_reporte_para_banco_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REPORTE_PARA_BANCO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREPORTE_PARA_BANCO_IDNull
		{
			get { return _reporte_para_banco_idNull; }
			set { _reporte_para_banco_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_ID</c> column value.</value>
		public decimal TIPO_ID
		{
			get
			{
				if(IsTIPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_id;
			}
			set
			{
				_tipo_idNull = false;
				_tipo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_IDNull
		{
			get { return _tipo_idNull; }
			set { _tipo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPOS_CTACTE_BANCARIA_DESCR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPOS_CTACTE_BANCARIA_DESCR</c> column value.</value>
		public string TIPOS_CTACTE_BANCARIA_DESCR
		{
			get { return _tipos_ctacte_bancaria_descr; }
			set { _tipos_ctacte_bancaria_descr = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public decimal ORDEN
		{
			get { return _orden; }
			set { _orden = value; }
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
			dynStr.Append("@CBA@NUMERO_CUENTA=");
			dynStr.Append(NUMERO_CUENTA);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(IsENTIDAD_IDNull ? (object)"<NULL>" : ENTIDAD_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@CTACTE_BANCO_ID=");
			dynStr.Append(CTACTE_BANCO_ID);
			dynStr.Append("@CBA@BANCO_NOMBRE=");
			dynStr.Append(BANCO_NOMBRE);
			dynStr.Append("@CBA@BANCO_ABREVIATURA=");
			dynStr.Append(BANCO_ABREVIATURA);
			dynStr.Append("@CBA@BANCO_PAIS_ID=");
			dynStr.Append(BANCO_PAIS_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA=");
			dynStr.Append(MONEDA);
			dynStr.Append("@CBA@SALDO_INICIAL=");
			dynStr.Append(SALDO_INICIAL);
			dynStr.Append("@CBA@SALDO_EXTRACTO=");
			dynStr.Append(IsSALDO_EXTRACTONull ? (object)"<NULL>" : SALDO_EXTRACTO);
			dynStr.Append("@CBA@MONTO_LINEA_CREDITO=");
			dynStr.Append(MONTO_LINEA_CREDITO);
			dynStr.Append("@CBA@MONTO_SOBREGIRO=");
			dynStr.Append(MONTO_SOBREGIRO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@TITULAR=");
			dynStr.Append(TITULAR);
			dynStr.Append("@CBA@SALDO_ACTUAL=");
			dynStr.Append(IsSALDO_ACTUALNull ? (object)"<NULL>" : SALDO_ACTUAL);
			dynStr.Append("@CBA@SALDO_CONCILIADO=");
			dynStr.Append(IsSALDO_CONCILIADONull ? (object)"<NULL>" : SALDO_CONCILIADO);
			dynStr.Append("@CBA@REPORTE_ID=");
			dynStr.Append(REPORTE_ID);
			dynStr.Append("@CBA@REPORTE_NOMBRE=");
			dynStr.Append(REPORTE_NOMBRE);
			dynStr.Append("@CBA@REPORTE_PARA_BANCO_ID=");
			dynStr.Append(IsREPORTE_PARA_BANCO_IDNull ? (object)"<NULL>" : REPORTE_PARA_BANCO_ID);
			dynStr.Append("@CBA@TIPO_ID=");
			dynStr.Append(IsTIPO_IDNull ? (object)"<NULL>" : TIPO_ID);
			dynStr.Append("@CBA@TIPOS_CTACTE_BANCARIA_DESCR=");
			dynStr.Append(TIPOS_CTACTE_BANCARIA_DESCR);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(ORDEN);
			return dynStr.ToString();
		}
	} // End of CTACTE_BANCARIAS_INFO_COMPLETARow_Base class
} // End of namespace
