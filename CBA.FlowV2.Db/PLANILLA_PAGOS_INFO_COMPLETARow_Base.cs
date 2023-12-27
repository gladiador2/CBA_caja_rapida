// <fileinfo name="PLANILLA_PAGOS_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="PLANILLA_PAGOS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>PLANILLA_PAGOS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANILLA_PAGOS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_PAGOS_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _autonumeracion_id;
		private string _numero_timbrado;
		private string _nro_planilla;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_id;
		private string _usuario;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private decimal _entidad_id;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _cotizacion_moneda;
		private decimal _monto_total;
		private string _observacion;
		private decimal _caja_tesoreria_id;
		private string _caja_nombre;
		private string _op_generada;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_PAGOS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public PLANILLA_PAGOS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANILLA_PAGOS_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NUMERO_TIMBRADO != original.NUMERO_TIMBRADO) return true;
			if (this.NRO_PLANILLA != original.NRO_PLANILLA) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.USUARIO != original.USUARIO) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO_TOTAL != original.MONTO_TOTAL) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.CAJA_TESORERIA_ID != original.CAJA_TESORERIA_ID) return true;
			if (this.CAJA_NOMBRE != original.CAJA_NOMBRE) return true;
			if (this.OP_GENERADA != original.OP_GENERADA) return true;
			
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
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get { return _autonumeracion_id; }
			set { _autonumeracion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_TIMBRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_TIMBRADO</c> column value.</value>
		public string NUMERO_TIMBRADO
		{
			get { return _numero_timbrado; }
			set { _numero_timbrado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_PLANILLA</c> column value.
		/// </summary>
		/// <value>The <c>NRO_PLANILLA</c> column value.</value>
		public string NRO_PLANILLA
		{
			get { return _nro_planilla; }
			set { _nro_planilla = value; }
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
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO</c> column value.</value>
		public string USUARIO
		{
			get { return _usuario; }
			set { _usuario = value; }
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
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
		/// Gets or sets the <c>MONEDA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_NOMBRE</c> column value.</value>
		public string MONEDA_NOMBRE
		{
			get { return _moneda_nombre; }
			set { _moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
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
		/// Gets or sets the <c>MONTO_TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL</c> column value.</value>
		public decimal MONTO_TOTAL
		{
			get { return _monto_total; }
			set { _monto_total = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAJA_TESORERIA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CAJA_TESORERIA_ID</c> column value.</value>
		public decimal CAJA_TESORERIA_ID
		{
			get { return _caja_tesoreria_id; }
			set { _caja_tesoreria_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAJA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CAJA_NOMBRE</c> column value.</value>
		public string CAJA_NOMBRE
		{
			get { return _caja_nombre; }
			set { _caja_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OP_GENERADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OP_GENERADA</c> column value.</value>
		public string OP_GENERADA
		{
			get { return _op_generada; }
			set { _op_generada = value; }
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
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(AUTONUMERACION_ID);
			dynStr.Append("@CBA@NUMERO_TIMBRADO=");
			dynStr.Append(NUMERO_TIMBRADO);
			dynStr.Append("@CBA@NRO_PLANILLA=");
			dynStr.Append(NRO_PLANILLA);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@USUARIO=");
			dynStr.Append(USUARIO);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO_TOTAL=");
			dynStr.Append(MONTO_TOTAL);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@CAJA_TESORERIA_ID=");
			dynStr.Append(CAJA_TESORERIA_ID);
			dynStr.Append("@CBA@CAJA_NOMBRE=");
			dynStr.Append(CAJA_NOMBRE);
			dynStr.Append("@CBA@OP_GENERADA=");
			dynStr.Append(OP_GENERADA);
			return dynStr.ToString();
		}
	} // End of PLANILLA_PAGOS_INFO_COMPLETARow_Base class
} // End of namespace
